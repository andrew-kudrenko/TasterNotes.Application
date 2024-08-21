using Microsoft.EntityFrameworkCore;

using TasterNotes.Application.Models.Auth;
using TasterNotes.Persistence;
using TasterNotes.Persistence.Models.Auth;
using TasterNotes.Persistence.Models.Users;

namespace TasterNotes.Application.Services.Auth
{
    public class AuthService(AppDbContext db, CryptoService cryptoService)
    {
        public async Task<RefreshSession> AddRefreshSessionAsync(RefreshSession session)
        {
            var userSessions = db.RefreshSessions.Where(s => s.UserId.Equals(session.UserId));
            
            if (await userSessions.CountAsync() >= 5)
            {
                await userSessions.ExecuteDeleteAsync();
                await db.SaveChangesAsync();
            }

            await db.RefreshSessions.AddAsync(session);
            await db.SaveChangesAsync();

            var addedSession = await db.RefreshSessions
                .AsNoTracking()
                .Where(s => s.RefreshSessionId == session.RefreshSessionId)
                .Include(s => s.User)
                .FirstAsync();

            return addedSession;
        }

        public async Task<User?> AuthenticateAsync(LoginDto model)
        {
            var user = await db.Users
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.Nickname == model.Nickname || u.Email == model.Email);

            if (user is null || !cryptoService.VerifyPassword(model.Password, user.HashedPassword))
            {
                return null;
            }

            return user;
        }

        public async Task<bool> AnyUserAsync(RegisterDto model)
        {
            return await db.Users
                .AsNoTracking()
                .AnyAsync(u => u.Nickname == model.Nickname || u.Email == model.Email);
        }

        public async Task<User> CreateUserAsync(RegisterDto model)
        {
            var user = await db.Users.AddAsync(new()
            {
                Email = model.Email,
                Nickname = model.Nickname,
                HashedPassword = cryptoService.HashPassword(model.Password),

                IsEmailConfirmed = false,
                CreatedOn = DateTime.UtcNow,
                RemovedOn = null,
                AvatarUrl = null,
                Role = UserRole.Ordinary,
                Status = UserStatus.Active,
            });

            await db.SaveChangesAsync();

            return user.Entity;
        }
    }
}

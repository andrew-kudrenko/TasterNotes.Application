using Microsoft.EntityFrameworkCore;
using TasterNotes.Application.Models.Request.Auth;
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

            var addedSession = await db.RefreshSessions.AddAsync(session);
            await db.SaveChangesAsync();

            return addedSession.Entity;
        }

        public async Task<User?> AuthenticateAsync(LoginRequest model)
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

        public async Task<bool> AnyUserAsync(RegisterRequest model)
        {
            return await db.Users
                .AsNoTracking()
                .AnyAsync(u => u.Nickname == model.Nickname || u.Email == model.Email);
        }

        public async Task<User> CreateUserAsync(RegisterRequest model)
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

        public async Task RemoveRefreshSession(Guid token)
        {
            var session = await db.RefreshSessions.SingleOrDefaultAsync(s => s.RefreshSessionId.Equals(token));

            if (session is not null)
            {
                db.Remove(session);
                await db.SaveChangesAsync();
            }
        }
    }
}

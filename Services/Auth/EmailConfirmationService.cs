using TasterNotes.Persistence;
using TasterNotes.Persistence.Models.Users;

namespace TasterNotes.Application.Services.Auth
{
    public class EmailConfirmationService(AppDbContext db)
    {
        private readonly AppDbContext _db = db;

        public async Task Send(User user)
        {
            if (user.IsEmailConfirmed)
            {
                throw new ApplicationException("Already confirmed");
            }

            await Task.FromResult(true);
        }

        public async Task<bool> TryAccept(User user, string code)
        {
            return await Task.FromResult(true);
        }
    }
}

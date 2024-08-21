using TasterNotes.Application.Models.User;
using TasterNotes.Application.Services.Auth;
using TasterNotes.Persistence;
using TasterNotes.Persistence.Models;

namespace TasterNotes.Application.Services.Users
{
    public class UserService(AppDbContext db, EmailConfirmationService emailConfirmationService, CryptoService cryptoService)
    {
        private readonly AppDbContext _db = db;
        private readonly CryptoService _cryptoService = cryptoService;
        private readonly EmailConfirmationService _emailConfirmationService = emailConfirmationService;
    }
}

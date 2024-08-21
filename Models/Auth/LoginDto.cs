namespace TasterNotes.Application.Models.Auth
{
    public class LoginDto
    {
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Fingerprint { get; set; } = string.Empty;
    }
}

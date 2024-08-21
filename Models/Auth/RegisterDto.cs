using System.ComponentModel.DataAnnotations;

namespace TasterNotes.Application.Models.Auth
{
    public class RegisterDto
    {
        [Required]
        [Length(3, 24)]
        public string Nickname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Compare(nameof(Password))]
        public string PasswordRepeat { get; set; } = string.Empty;
    }
}

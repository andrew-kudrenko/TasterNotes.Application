using TasterNotes.Persistence.Models.Users;

namespace TasterNotes.Application.Models.Response.Users
{
    public class UserMeResponse
    {
        public Guid UserId { get; set; }
        public string Nickname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool IsEmailConfirmed { get; set; }
        public string? AvatarUrl { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? RemovedOn { get; set; }
        public UserRole Role { get; set; } = UserRole.Ordinary;
        public UserStatus Status { get; set; } = UserStatus.Active;

        public static UserMeResponse FromUser(User source)
        {
            return new()
            {
                UserId = source.UserId,
                Nickname = source.Nickname,
                Email = source.Email,
                AvatarUrl = source.AvatarUrl,
                Role = source.Role,
                Status = source.Status,
                CreatedOn = source.CreatedOn,
                IsEmailConfirmed = source.IsEmailConfirmed,
                RemovedOn = source.RemovedOn,
            };
        }
    }
}

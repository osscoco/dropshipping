using Models.Identity;

namespace API.Dtos.Responses.Auth
{
    public class RegisterResponse
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? ContactPhone { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required int RoleId { get; set; }
    }
}

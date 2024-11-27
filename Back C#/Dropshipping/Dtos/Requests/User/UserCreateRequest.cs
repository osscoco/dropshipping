using API.Validators;

namespace API.Dtos.Requests.User
{
    public class UserCreateRequest
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        [CustomEmailValidator]
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string? ContactPhone { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }
    }
}

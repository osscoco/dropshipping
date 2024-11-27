using Models.Identity;

namespace API.Dtos.Responses.User
{
    public class UserResponse
    {
        public required int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? ContactPhone { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public int RoleId { get; set; }

        public UserResponse() { }
    } 
}

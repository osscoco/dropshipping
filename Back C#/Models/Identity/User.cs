namespace Models.Identity
{
    public class User
    {
        public int UserId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? ContactPhone { get; set; }
        public string? ContactEmail { get; set; }
        public required DateTime DateOfBirth { get; set; }
        public required int RoleId { get; set; }
        public required Role Role { get; set; }
        
    }
}

using System.Text.Json.Serialization;

namespace Models.Identity
{
    public class Role
    {
        public int RoleId { get; set; }
        public required string Name { get; set; }
        [JsonIgnore]
        public ICollection<User>? Users { get; set; }
    }
}

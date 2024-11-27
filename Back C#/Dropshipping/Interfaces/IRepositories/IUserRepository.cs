using API.Dtos.Requests.User;
using API.Dtos.Responses.User;
using Models.Identity;

namespace API.Interfaces.IRepositories
{
    public interface IUserRepository
    {
        Task<int> CountAllUsersQuery();
        Task<List<UserResponse>> GetAllUsersByPageIndexAndPageSizeQuery(int pageIndex, int pageSize);

        Task<User?> GetUserById(int id);
        Task<User> CreateUser(UserCreateRequest user);
        Task<UserResponse> UpdateUser(int id, User user);
        Task<bool> DeleteUser(int id);
        Task<bool> UserExists(int id);
        Task<bool> UserExistsByEmail(string email);
        public string HashString(string input);
    }
}

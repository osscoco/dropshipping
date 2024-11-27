using API.Dtos.Requests.User;
using API.Dtos.Responses.User;
using Models.Common;

namespace API.Interfaces.IServices
{
    public interface IUserService
    {
        Task<ResponseApi<PaginatedListUserResponse<UserResponse>>> GetUsers(int pageIndex, int pageSize);
        Task<ResponseApi<UserResponse>> GetUserById(int id);
        Task<ResponseApi<UserResponse>> CreateUser(UserCreateRequest user);
        Task<ResponseApi<UserResponse>> UpdateUser(int id, UserUpdateRequest user);
        Task<ResponseApi<UserResponse>> DeleteUser(int id);
    }
}

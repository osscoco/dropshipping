using API.Dtos.Requests.User;
using API.Dtos.Responses.User;
using API.Interfaces.IServices;
using API.Repositories;
using Models.Common;
using Models.Identity;

namespace API.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResponseApi<PaginatedListUserResponse<UserResponse>>> GetUsers(int pageIndex, int pageSize)
        {
            int totalCount = await _userRepository.CountAllUsersQuery();
            List<UserResponse> users = await _userRepository.GetAllUsersByPageIndexAndPageSizeQuery(pageIndex, pageSize);
            return new ResponseApi<PaginatedListUserResponse<UserResponse>>(true, new PaginatedListUserResponse<UserResponse>(users, totalCount, pageIndex, pageSize), "");
        }


        public async Task<ResponseApi<UserResponse>> GetUserById(int id)
        {
            var user = await _userRepository.GetUserById(id);
            if (user == null)
            {
                return new ResponseApi<UserResponse>(false, null, "Utilisateur non trouvé");
            }

            UserResponse userResponse = new UserResponse()
            { 
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactPhone = user.ContactPhone,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId
            };

            return new ResponseApi<UserResponse>(true, userResponse, "Utilisateur récupéré avec succès");
        }

        public async Task<ResponseApi<UserResponse>> CreateUser(UserCreateRequest user)
        {
            if (await _userRepository.UserExistsByEmail(user.Email))
            {
                return new ResponseApi<UserResponse>(false, null, "L'utilisateur existe déjà");
            }

            var createdUser = await _userRepository.CreateUser(user);

            UserResponse userResponse = new UserResponse()
            {
                UserId = createdUser.UserId,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email,
                ContactPhone = createdUser.ContactPhone,
                DateOfBirth= createdUser.DateOfBirth,
                RoleId = createdUser.RoleId
            };

            return new ResponseApi<UserResponse>(true, userResponse, "Utilisateur créé avec succès");
        }

        public async Task<ResponseApi<UserResponse>> UpdateUser(int id, UserUpdateRequest user)
        {
            User? userExist = await _userRepository.GetUserById(id);
            if (userExist == null)
            {
                return new ResponseApi<UserResponse>(false, null, "Utilisateur non trouvé");
            }

            if (!string.IsNullOrWhiteSpace(user.FirstName))
            {
                userExist.FirstName = user.FirstName;
            }

            if (!string.IsNullOrWhiteSpace(user.LastName))
            {
                userExist.LastName = user.LastName;
            }

            if (!string.IsNullOrEmpty(user.Email))
            {
                bool? userEmailExist = await _userRepository.UserExistsByEmail(user.Email);

                if (userEmailExist != null)
                {
                    return new ResponseApi<UserResponse>(false, null, "L'utilisateur existe déjà");
                }

                userExist.Email = user.Email;
            }

            if (!string.IsNullOrWhiteSpace(user.ContactPhone))
            {
                userExist.ContactPhone = user.ContactPhone;
            }

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                userExist.PasswordHash = _userRepository.HashString(user.Password);
            }

            if (user.RoleId.HasValue)
            {
                userExist.RoleId = user.RoleId.Value;
            }

            var updatedUser = await _userRepository.UpdateUser(id, userExist);

            return new ResponseApi<UserResponse>(true, updatedUser, "Utilisateur mis à jour avec succès");
        }

        public async Task<ResponseApi<UserResponse>> DeleteUser(int id)
        {
            var success = await _userRepository.DeleteUser(id);
            if (!success)
            {
                return new ResponseApi<UserResponse>(false, null, "Utilisateur non trouvé");
            }

            return new ResponseApi<UserResponse>(true, null, "Utilisateur supprimé avec succès");
        }
    }
}

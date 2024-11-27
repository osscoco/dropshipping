using System.Collections;
using System.Text;
using System.Security.Cryptography;
using API.Repositories;
using EFCore;
using Models.Common;
using API.Interfaces.IServices;
using Models.Identity;
using API.Dtos.Responses.User;
using API.Dtos.Requests.User;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private UserRepository _userRepository;

        public AuthService(
            AppDbContext context, 
            IConfiguration configuration,
            UserRepository userRepository
            )
        {
            _context = context;
            _configuration = configuration;
            _userRepository = userRepository;
        }

        public ArrayList? AuthenticateUserAsync(string email, string password)
        {
            var passwordHash = HashString(password);

            User? user = _userRepository.GetUserByEmailAndPassword(email, passwordHash);

            return user != null ? _userRepository.GetBearerTokenByUser(user) : null;
        }

        public async Task<ResponseApi<UserResponse>> PostOneUser(UserCreateRequest userRequest)
        {
            User user = new()
            {
                FirstName = userRequest.FirstName,
                LastName = userRequest.LastName,
                Email = userRequest.Email,
                PasswordHash = HashString(userRequest.Password),
                ContactPhone = userRequest.ContactPhone,
                DateOfBirth = userRequest.DateOfBirth,
                RoleId = userRequest.RoleId
            };

            _context.Users.Add(user);

            var result = await _context.SaveChangesAsync();
            bool isSuccess = result > 0;

            if (isSuccess)
            {
                return new ResponseApi<UserResponse>(true, null, "Utilisateur créé avec succès");
            }
            else
            {
                return new ResponseApi<UserResponse>(false, null, "Erreur de création de l'utilisateur");
            }
        }

        public string HashString(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);

                byte[] hashBytes = sha256.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();

                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}

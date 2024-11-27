using API.Validators;
using API.Interfaces.IRepositories;
using EFCore;
using Microsoft.EntityFrameworkCore;
using Models.Identity;
using System.Security.Cryptography;
using System.Text;
using API.Dtos.Requests.User;
using API.Dtos.Responses.User;
using Microsoft.IdentityModel.Tokens;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public UserRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public User? GetUserByEmailAndPassword(string email, string passwordHash)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email && u.PasswordHash == passwordHash);
        }

        public ArrayList GetBearerTokenByUser(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: _configuration["Jwt:Issuer"], audience: _configuration["Jwt:Audience"], claims: claims, expires: DateTime.UtcNow.AddMinutes(60), signingCredentials: signin);
            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            ArrayList arraylist = new ArrayList();
            arraylist.Add(user);
            arraylist.Add(tokenValue);

            return arraylist;
        }

        public Task<int> CountAllUsersQuery()
        {
            return _context.Users.AsQueryable().Include(user => user.Role).CountAsync();
        }

        public Task<List<UserResponse>> GetAllUsersByPageIndexAndPageSizeQuery(int pageIndex, int pageSize)
        {
            return _context.Users.AsQueryable()
                .Include(user => user.Role)
                .Select(u => new UserResponse
                {
                    UserId = u.UserId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    ContactPhone = u.ContactPhone,
                    DateOfBirth = u.DateOfBirth,
                    RoleId = u.RoleId
                })
                .Skip(pageIndex * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUser(UserCreateRequest user)
        {
            User newUser = new User 
            { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PasswordHash = HashString(user.Password),
                ContactPhone = user.ContactPhone,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }

        public async Task<UserResponse> UpdateUser(int id, User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            var userResponse = new UserResponse
            {
                UserId = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactPhone = user.ContactPhone,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId
            };

            return userResponse;
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _context.Users.AnyAsync(u => u.UserId == id);
        }

        public async Task<bool> UserExistsByEmail(string email)
        {
            return await _context.Users.AnyAsync(u =>u.Email == email);
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

using API.Dtos.Requests.User;
using API.Dtos.Responses.User;
using API.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Common;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/User 
        [HttpGet]
        public async Task<ResponseApi<PaginatedListUserResponse<UserResponse>>> GetAllUsersPaginated(int pageIndex, int pageSize)
        {
            return await _userService.GetUsers(pageIndex, pageSize);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<ResponseApi<UserResponse>> GetUser(int id)
        {
            return await _userService.GetUserById(id);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<ResponseApi<UserResponse>>> CreateUser([FromBody] UserCreateRequest user)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseApi<UserResponse>(false, null, "Les données fournies sont invalides");
            }

            return await _userService.CreateUser(user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<ResponseApi<UserResponse>>> UpdateUser(int id, [FromBody] UserUpdateRequest updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseApi<UserResponse>(false, null, "Les données fournies sont invalides");
            }

            return await _userService.UpdateUser(id, updatedUser);
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<ResponseApi<UserResponse>>> DeleteUser(int id)
        {
            return await _userService.DeleteUser(id);
        }
    }
}

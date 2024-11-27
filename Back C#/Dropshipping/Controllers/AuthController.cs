using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Collections;
using API.Dtos.Requests.Auth;
using API.Interfaces.IServices;
using Models.Common;
using API.Middlewares;
using API.Dtos.Requests.User;
using Models.Identity;
using API.Dtos.Responses.User;
using System.Security.Claims;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;

        public AuthController(IAuthService authService, IUserService userService, ITokenService tokenService)
        {
            _authService = authService;
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpGet("me")]
        public async Task<ResponseApi<object>> GetAuthMe()
        {
            // Récupérer l'utilisateur actuel depuis le contexte de la requête.
            var user = HttpContext.User;

            // Vérifier si l'utilisateur est authentifié.
            if (!user.Identity.IsAuthenticated)
            {
                return new ResponseApi<object>(false, Unauthorized(new { message = "Vous n'êtes pas authentifié." }), "Vous n'êtes pas authentifié");
            }

            var emailUserInfo = "";

            foreach (var (item, index) in user.Claims.Select((value, i) => (value, i)))
            {
                if (index == 0)
                    emailUserInfo = item.Value;
            }

            // Retourner les informations.
            return new ResponseApi<object>(true, Ok(emailUserInfo), "Vous êtes authentifié");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ResponseApi<UserResponse>> PostOneUser([FromBody] UserCreateRequest user)
        {
            if (!ModelState.IsValid)
            {
                return new ResponseApi<UserResponse>(false, null, "Les données fournies sont invalides");
            }
            return await _userService.CreateUser(user);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public Task<ResponseApi<object>> Login([FromBody] LoginRequest loginModel)
        {
            try
            {
                ArrayList? arrayListResult = _authService.AuthenticateUserAsync(loginModel.Email, loginModel.Password);

                if (arrayListResult != null)
                {
                    AuthenticateUserResponse response = new AuthenticateUserResponse();
                    response.User = MapToUserResponse((User)arrayListResult[0]);

                    if (response.User != null)
                    {
                        response.Token = arrayListResult[1].ToString();

                        return
                            Task.FromResult(
                                new ResponseApi<object>(
                                    true,
                                    new AuthenticateUserResponse
                                    {
                                        User = response.User,
                                        Token = response.Token
                                    },
                                    "Vous êtes connecté"
                                )
                            );
                    }
                }
                
                return
                    Task.FromResult(
                        new ResponseApi<object>(
                            false,
                            Unauthorized(),
                            "Echec de l'authentification"
                        )
                    );
            }
            catch (Exception ex)
            {
                return
                    Task.FromResult(
                        new ResponseApi<object>(
                            false,
                            StatusCode(500, new { error = ex.Message }),
                            "Une erreur est survenue lors de la connexion"
                        )
                    );
            }
        }

        [HttpGet("logout")]
        public Task<ResponseApi<object>> Logout()
        {
            try
            {
                var token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                if (string.IsNullOrEmpty(token))
                {
                    return Task.FromResult(
                        new ResponseApi<object>(
                            false,
                            BadRequest("Aucun jeton fourni"),
                            "Aucun jeton fourni"
                        )
                    );
                }

                _tokenService.RevokeToken(token);

                return Task.FromResult(
                    new ResponseApi<object>(
                        true,
                        Ok("Vous êtes déconnecté"),
                        "Vous êtes déconnecté"
                    )
                );

            }
            catch (Exception ex)
            {
                return
                    Task.FromResult(
                        new ResponseApi<object>(
                            false,
                            StatusCode(500, new { error = ex.Message }),
                            "Une erreur est survenue lors de la déconnexion"
                        )
                    );
            }
        }

        public static UserResponse MapToUserResponse(User user)
        {
            return new UserResponse
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                ContactPhone = user.ContactPhone,
                DateOfBirth = user.DateOfBirth,
                RoleId = user.RoleId
            };
        }
    }
    public class AuthenticateUserResponse
    {
        public UserResponse User { get; set; }
        public string Token { get; set; }
    }
}

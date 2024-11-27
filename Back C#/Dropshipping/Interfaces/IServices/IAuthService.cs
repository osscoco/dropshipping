using API.Dtos.Requests.Auth;
using Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Models.Common;
using API.Dtos.Requests.User;
using API.Dtos.Responses.User;

namespace API.Interfaces.IServices
{
    public interface IAuthService
    {
        public ArrayList? AuthenticateUserAsync(string email, string password);
        public Task<ResponseApi<UserResponse>> PostOneUser(UserCreateRequest userRequest);
        public string HashString(string input);
    }
}

namespace API.Interfaces.IServices
{
    public interface ITokenService
    {
        void RevokeToken(string token);
        bool IsTokenRevoked(string token);
    }
}

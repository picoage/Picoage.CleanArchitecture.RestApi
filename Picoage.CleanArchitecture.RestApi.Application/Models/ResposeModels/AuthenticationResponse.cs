namespace Picoage.CleanArchitecture.RestApi.Application.Models.ResposeModels
{
    public class AuthenticationResponse
    {
        public string UserName { get; set; }
        public int ExpireTime { get; set; }
        public string Token { get; set; }
    }
}

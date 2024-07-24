namespace GameSphereAPI.Models.Viewmodels.Registration
{
    public class AccessTokenResponse
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string? RefreshToken { get; set; }
    }
}
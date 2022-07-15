namespace Movies.Api.JWT
{
    public interface IJWTHelper
    {
        public string GenerateToken(string username);
    }
}

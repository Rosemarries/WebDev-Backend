namespace Backend.Config;

public class Constant
{
    public static class Name
    {
        public const string AccessToken = "accessToken";
        public const string RefreshToken = "refreshToken";
    }

    public static class Number
    {
        public const double AccessTokenExpiresInSec = 15; // InSec type => double

        public const double AccessTokenExpiresInDay = 1;
        public const int RefreshTokenExpiresInMonths = 1; // InMonth type => int
    }
}
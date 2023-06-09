using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Backend.Models;
using Backend.Config;

namespace Backend.Utilities;

public class TokenUtils
{
    public static TokenValidationParameters tokensValidatorParam { get; } = new TokenValidationParameters
  {
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = Configuration.StaticConfig["Jwt:Issuer"],
    ValidAudience = Configuration.StaticConfig["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.StaticConfig["Jwt:SecretKey"])),
    ClockSkew = TimeSpan.Zero
  };

  public static JwtSecurityTokenHandler tokenHandler { get; } = new JwtSecurityTokenHandler();
  public static string GenerateAccessToken(User user)
  {
    Claim[] claims = new Claim[] {
      new Claim("id", user.Id),
      new Claim("username", user.Username),
      new Claim(ClaimTypes.Role, user.Role),
      new Claim("display_name", user.Name),
      new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
      new Claim(JwtRegisteredClaimNames.Exp, DateTime.UtcNow.AddDays(Constant.Number.AccessTokenExpiresInDay).ToString())
    };

    return GenerateToken(DateTime.UtcNow.AddDays(Constant.Number.AccessTokenExpiresInDay), claims);

  }

  public static string GenerateRefreshToken(User user)
  {
    Claim[] claims = new Claim[] {
      new Claim("username", user.Username)
    };
    return GenerateToken(DateTime.UtcNow.AddMonths(Constant.Number.RefreshTokenExpiresInMonths), claims);
  }

  private static string GenerateToken(DateTime expires, Claim[]? claims = null)
  {
    SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.StaticConfig["Jwt:SecretKey"]));
    SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

    JwtSecurityToken token = new JwtSecurityToken(
      Configuration.StaticConfig["Jwt:Issuer"],
      Configuration.StaticConfig["Jwt:Audience"],
      claims,
      expires: expires,
      signingCredentials: credentials
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  public static bool ValidateToken(string token)
  {
    try
    {
      tokenHandler.ValidateToken(token, tokensValidatorParam, out SecurityToken validatedToken);
    }
    catch (Exception)
    {
      return false;
    }
    return true;
  }
}
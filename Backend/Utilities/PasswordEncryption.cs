using System.Text;
using System.Security.Cryptography;
using Backend.Config;

namespace Backend.Utilities;

public static class PasswordEncryption
{
    public static string Encrypt(string password)
    {
        byte[] textBytes = Encoding.UTF8.GetBytes(password);
        byte[] keyBytes = Encoding.UTF8.GetBytes(Configuration.StaticConfig["Hmac:Key"]!);

        byte[] hashBytes;
        using (HMACSHA256 hash = new HMACSHA256(keyBytes))
        {
            hashBytes = hash.ComputeHash(textBytes);
        }

        string encrypted = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

        return encrypted;
    }

    public static bool Validate(string pass, string encrypted)
    {
        string encryptedpass = Encrypt(pass);

        if (encryptedpass != encrypted)
            return false;

        return true;
    }
}
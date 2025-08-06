using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.Services.Criptography;

public class PasswordEncripter
{
    public string Encript(string password)
    {
        var chaveAdicional = "ABC";

        var saltPassword = $"{password}{chaveAdicional}";

        var bytes = Encoding.UTF8.GetBytes(saltPassword);
        var hashBytes = SHA512.HashData(bytes);

        return ConvertBytesToString(hashBytes);
    }

    private static string ConvertBytesToString(byte[] bytes)
    {
        var sb = new StringBuilder();
        foreach (var b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }

        return sb.ToString();
    }
}

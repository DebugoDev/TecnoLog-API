namespace Infrastructure.Services;

using System.Security.Cryptography;
using System.Text;
using Application.Entities;
using Application.Interfaces.Services.Core.Auth;
using Application.Models.Entities;

public class ProfileService : IProfileService
{
    public ProfileDto GetProfileDto(User entity)
    {
        return new ProfileDto(
            GetNameAbbreviation(entity.Name),
            GetNameHexColor(entity.Name)
        );
    }

    private static string GetNameAbbreviation(string name)
    {
        var names = name.Split(" ");

        if (names.Length == 0)
            return "?";

        return $"{names.First().First()}{names.Last().First()}".ToUpper();
    }

    private static string GetNameHexColor(string name)
    {
        byte[] inputBytes = Encoding.UTF8.GetBytes(name);
        byte[] hashBytes = MD5.HashData(inputBytes);

        StringBuilder hexColor = new(7);
        hexColor.Append('#');

        hexColor.Append(hashBytes[0].ToString("X2"));
        hexColor.Append(hashBytes[1].ToString("X2"));
        hexColor.Append(hashBytes[2].ToString("X2"));

        return hexColor.ToString();
    }
}
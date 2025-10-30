namespace Infrastructure.Services;

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
        var bytes = Encoding.UTF8.GetBytes(name);
        return BitConverter.ToString(bytes).Replace("-", "");
    }
}
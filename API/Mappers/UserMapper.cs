using API.DTOs;
using Domain.Models;
using Infrastructure.Extensions;
using TheUltimateStrictLibrary.Extensions;

namespace API.Mappers;

public static class UserMapper
{
    /// <summary>
    /// Converts the User DTO to User Entity object.
    /// 
    /// It can throw exceptions
    /// </summary>
    /// <param name="userDto"></param>
    /// <returns></returns>
    public static User ToUser(this UserDto userDto)
    {
        var user = new User
        {
            Username = userDto.Username,
            Email = new(userDto.Email),
            CreationDate = userDto.CreationDate.ToUniversalDateTimeOffset(),
        };

        if (!userDto.PhoneNumber.IsBlank())
        {
            user.PhoneNumber = new(userDto.PhoneNumber);
        }

        return user;
    }

    public static UserDto ToUserDto(this User user)
    {
        var userDto = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email.Value,
            CreationDate = user.CreationDate.ToLocalTimezone(),
        };

        if (user.PhoneNumber is not null)
        {
            userDto.PhoneNumber = new(user.PhoneNumber.Value);
        }

        return userDto;
    }  
}

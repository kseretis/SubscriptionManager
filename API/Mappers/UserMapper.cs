using API.DTOs;
using Domain.Models;

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
        return new User
        {
            Id = userDto.Id,
            Username = userDto.Username,
            Email = new (userDto.Email),
            CreationDate = DateTimeOffset.Now
        };  
    }
}

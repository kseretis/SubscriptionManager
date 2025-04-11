using API.DataTransferObjects;
using SubscriptionManager.Domain.Entities;

namespace API.Mappers
{
    public static class UserMapper
    {
        public static User ToUser(this UserDto userDto)
        {
            return new User
            {
                Id = userDto.Id,
                Name = userDto.Name,
                Email = userDto.Email
            };  
        }
    }
}

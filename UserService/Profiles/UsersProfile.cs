using AutoMapper;
using UserService.DTOs;
using UserService.Models;

namespace UserService.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            // Source -> Target
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
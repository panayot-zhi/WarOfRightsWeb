using AutoMapper;
using Discord.WebSocket;
using WarOfRightsWeb.Models;

namespace WarOfRightsWeb.Utility
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SocketRole, CompanyRole>();
            CreateMap<SocketGuildUser, CompanyMember>();
        }
    }
}

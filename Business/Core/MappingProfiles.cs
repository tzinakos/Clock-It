using AutoMapper;
using Domain;

namespace Business.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, User>();
        }
    }
}

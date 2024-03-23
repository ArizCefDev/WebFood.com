using AutoMapper;
using DataAccess.Entity;
using DTO.EntityDTO;

namespace Business.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AboutDTO, About>();
            CreateMap<About, AboutDTO>();

            CreateMap<MenuDTO, Menu>();
            CreateMap<Menu, MenuDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();

            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();

            //CreateMap<GroupJoinDTO, GroupJoin>();
            //CreateMap<GroupJoin, GroupJoinDTO>()
            //    .ForMember(dest => dest.LanguageName, opt => opt.MapFrom(c => c.GroupJoinCategory.Language))
            //    .ForMember(dest => dest.StartDateName, opt => opt.MapFrom(c => c.GroupJoinCategory.StartDate));

        }
    }
}

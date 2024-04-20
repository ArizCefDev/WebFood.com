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
            CreateMap<Menu, MenuDTO>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(c => c.Category.Name));

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();

            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();

            CreateMap<SocialMediaDTO, SocialMedia>();
            CreateMap<SocialMedia, SocialMediaDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();


            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();


        }
    }
}

using AutoMapper;
using PlantNursery.API.Models;
using PlantNursery.API.Models.OrderRequests;
using PlantNursery.API.Models.UserModels;
using PlantNursery.DAL.Entities;
using PlantNursery.DTO;
using PlantNursery.DTO.OrderDto;

using PlantNursery.DTO.UserDto;

namespace PlantNursery.API.Mapping
{
    public class ApiMappingProfile : Profile
    {
        public ApiMappingProfile() {

            CreateMap<Product, ProductDto>();
            CreateMap<ProductRequest, ProductDto>().ReverseMap();

 CreateMap<User, UserResponseDto>();
            CreateMap<UserCreateDto, User>()
           .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            CreateMap<UserUpdatedDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

           CreateMap<User, UserResponseDto>();
            CreateMap<User, UserCreateDto>();
            CreateMap<User, UserLoginDto>();

           CreateMap<UserCreateRequest, UserCreateDto>().ReverseMap();
          CreateMap<UserResponseRequest, UserResponseDto>().ReverseMap();
          CreateMap<UserUpdatedDto, UserUpdatedDto>().ReverseMap();

            CreateMap<CreateOrderDto, Order>()
             .ForMember(dest => dest.Id, opt => opt.Ignore())          // חובה
             .ForMember(dest => dest.OrderDate, opt => opt.Ignore())   // חובה
             .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderItems));



            CreateMap<OrderItemDto, OrderDetail>().ForMember(dest => dest.Id, opt => opt.Ignore());;


    
            // Entity -> DTO
            CreateMap<Order, OrderResponseDto>()
                .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.OrderDetails));
           // CreateMap<OrderDetail, OrderItemDto>();
            CreateMap<OrderDetail, OrderDetailsResponseDto>();


        }
    }

   
}

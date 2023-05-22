using AutoMapper;
using HotelBooking.Data;
using HotelBooking.Models.Hotels;
using HotelBooking.Models.Rooms;
using System.Diagnostics.Metrics;

namespace HotelBooking.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            //CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Hotel, HotelDto>().ReverseMap();

            CreateMap<Room, RoomDto>().ReverseMap();

            //CreateMap<Basket, BasketDto>().ReverseMap();
            //CreateMap<Basket, GetBasketDto>().ReverseMap();
            //CreateMap<Basket, BasketPostDto>().ReverseMap();
        }
    }
}

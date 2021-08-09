using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClientService.Models;
using ClientService.DtoModels;

namespace ClientService.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Guest, GuestDTO>().ReverseMap();
            CreateMap<Reservation, ReservationDTO>().ReverseMap();
        }
    }
}
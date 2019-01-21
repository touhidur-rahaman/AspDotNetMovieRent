using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplicationVidly.Dtos;
using WebApplicationVidly.Models;

namespace WebApplicationVidly.App_Start
{
    public class MapingProfile:Profile
    {
        public MapingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}
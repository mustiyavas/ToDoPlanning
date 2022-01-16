using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoPlanning.Entity.Concrete;
using ToDoPlanning.Entity.Dto;

namespace ToDoPlanning.Service.AutoMapper.Profiles
{
    public class ToDoProviderProfile : Profile
    {
        public ToDoProviderProfile()
        {
            CreateMap<ToDoProviderAddDto, ToDoProvider>().ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(x => DateTime.Now));
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Core.DTOs;
using ToDo.Core.Entities;

namespace ToDo.Core.Maping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Source, Destination>();
            CreateMap<ToDoItem, ToDodto>();
            CreateMap<UpdateToDodto, ToDoItem>();
            CreateMap<CreateToDodto, ToDoItem>();
        }
    }
}

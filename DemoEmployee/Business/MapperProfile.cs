using AutoMapper;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoEmployee.Business
{
    public class MapperProfile :Profile
    {
        public MapperProfile()
        {
            CreateMap<DemoEmployee.Data.Models.Employee, DemoEmployee.Data.DTO.Employee>();

            CreateMap<List<DemoEmployee.Data.Models.Employee>, List<DemoEmployee.Data.DTO.Employee>>();
        }
    }
}

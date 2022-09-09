using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ExampleAPIWithEF.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Configuración para diferentes entidades (mapeo customizado de propiedades)
            //CreateMap<Estudiante, EstudianteDTO>
        }
    }
}

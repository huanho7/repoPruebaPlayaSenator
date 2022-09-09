using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PruebaPlayaSenator.Application.Dto;
using PruebaPlayaSenator.Application.Entities;

namespace ExampleAPIWithEF.Application
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Configuración para diferentes entidades (mapeo customizado de propiedades)
            //CreateMap<Estudiante, EstudianteDTO>
            
            CreateMap<Hotel, HotelDto>()
                .ForMember(hdto => hdto.Id, h => h.MapFrom(h => h.Id))
                .ForMember(hdto => hdto.Name, h => h.MapFrom(h => h.Name))
                .ForMember(hdto => hdto.Description, h => h.MapFrom(h => h.Description))
                .ForMember(hdto => hdto.IdCategory, h => h.MapFrom(h => h.IdCategory))
                .ForMember(hdto => hdto.IdCity, h => h.MapFrom(h => h.IdCity))
                .ForMember(hdto => hdto.IdRelevance, h => h.MapFrom(h => h.IdRelevance))
                .ForMember(hdto => hdto.RelevanceName, h => h.MapFrom(h => h.Relevance.Name))
                .ForMember(hdto => hdto.CategoryName, h => h.MapFrom(haux => haux.Category.Name))
                .ForMember(hdto => hdto.CityName, h => h.MapFrom(haux => haux.City.Name))
                .ForMember(hdto => hdto.ShortImageTitle, h => h.MapFrom(haux => haux.ShortImageTitle))
                .ForMember(hdto => hdto.ShortImageData, h => h.MapFrom(haux => Encoding.ASCII.GetString(haux.ShortImageData)))
                .ForMember(hdto => hdto.LargeImageTitle, h => h.MapFrom(haux => haux.LargeImageTitle))
                .ForMember(hdto => hdto.LargeImageData, h => h.MapFrom(haux => Encoding.ASCII.GetString(haux.LargeImageData)))
                .ForAllOtherMembers(x => x.Ignore());
        }
    }
}

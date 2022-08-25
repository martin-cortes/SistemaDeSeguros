using AutoMapper;
using Domain.Model.DTOs;
using Domain.Model.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntryPoints.ReactiveWeb.AutoMapper
{
    internal class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeo Usuarios

            CreateMap<UsuarioDTO, Usuario>().ReverseMap();

            CreateMap<CreacionUsuarioDTO, Usuario>()
                .BeforeMap((src, dest) =>
                {
                    TextInfo myTI = new CultureInfo("es-Es", false).TextInfo;

                    dest.Nombre = myTI.ToTitleCase(src.Nombre.ToLower());
                    dest.Apellido = myTI.ToTitleCase(src.Apellido.ToLower());
                    dest.Direccion = myTI.ToTitleCase(src.Direccion.ToLower());
                })
                .ForMember(x => x.Nombre, options => options.Ignore())
                .ForMember(x => x.Apellido, options => options.Ignore())
                .ForMember(x => x.Direccion, options => options.Ignore());



            // Mapeo PolizaSeguros

            CreateMap<PolizaSeguros, PolizaSegurosDTO>().ReverseMap();

            CreateMap<CreacionPolizaSegurosDTO, PolizaSeguros>()
                 .BeforeMap((src, dest) =>
                 {
                     TextInfo myTI = new CultureInfo("es-Es", false).TextInfo;

                     dest.NombrePoliza = myTI.ToTitleCase(src.NombrePoliza.ToLower());
                 })
                 .ForMember(x => x.NombrePoliza, options => options.Ignore());



        }

    }
}

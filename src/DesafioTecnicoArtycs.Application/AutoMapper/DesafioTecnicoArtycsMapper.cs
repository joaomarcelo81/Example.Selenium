using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using DesafioTecnicoArtycs.Domain.Dto.Request;
using DesafioTecnicoArtycs.Domain.Entities;

namespace DesafioTecnicoArtycs.Application.AutoMapper
{
    public class DesafioTecnicoArtycsMapper : Profile
    {
        public DesafioTecnicoArtycsMapper()
        {
            CreateMap<Curso, CursoRequest>().ReverseMap();
            CreateMap<Curso, CursoResponse>().ReverseMap();
        }
    }
}

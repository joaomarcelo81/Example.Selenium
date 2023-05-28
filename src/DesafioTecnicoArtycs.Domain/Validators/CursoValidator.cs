using DesafioTecnicoArtycs.Domain.Dto.Request;
using DesafioTecnicoArtycs.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Validators
{
    public class CursoValidator : AbstractValidator<CursoRequest>
    {
        public CursoValidator()
        {         
            RuleFor(curso => curso.Titulo).NotEmpty().WithMessage("Titulo é obrigatorio.");
            RuleFor(curso => curso.Professor).NotEmpty().WithMessage("Professor é obrigatorio.");
            RuleFor(curso => curso.CargaHoraria).NotEmpty().WithMessage("CargaHoraria é obrigatorio.");
            RuleFor(curso => curso.Descricao).NotEmpty().WithMessage("Descricao é obrigatorio.");
        }
    }
}
using DesafioTecnicoArtycs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Interfaces.Services
{
    public interface ICursoService
    {

        Task<Curso> Atualizar(Curso curso);
        Task<Curso> Adicionar(Curso curso);
        Task<IList<Curso>> listaCursos();

        Task BuscarDadosAlura(string nomeCurso);
    }
}

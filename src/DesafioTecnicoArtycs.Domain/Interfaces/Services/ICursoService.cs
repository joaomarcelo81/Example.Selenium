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
        Task<Curso> Adicionar(Curso curso);
        Task<IList<Curso>> listaCursos();

        void BuscarDadosAlura();
    }
}

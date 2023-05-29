using DesafioTecnicoArtycs.Domain.Dto.Reponse;
using DesafioTecnicoArtycs.Domain.Dto.Request;
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
        Task<CursoResponse> ObterCurso(int Id);
        Task<int> Atualizar(int Id, CursoRequest curso);
        Task<int> Adicionar(CursoRequest curso);
        Task<IList<CursoResponse>> listaCursos();
        Task<int> RemoverCurso(int Id);
        Task<int> BuscarDadosAlura(string nomeCurso);
    }
}

using DesafioTecnicoArtycs.Domain.Entities;
using DesafioTecnicoArtycs.Infra.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Infra.Repository
{
    public class CursoRepository : BaseRepository<Curso, DataContext>
    {
        public CursoRepository(DataContext context) : base(context)
        {

        }
    }
}

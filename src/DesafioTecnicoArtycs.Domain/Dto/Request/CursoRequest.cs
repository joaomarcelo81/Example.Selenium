using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Dto.Request
{
    /// <summary>
    /// DTO Curso para as Requisições
    /// </summary>
    public class CursoRequest
    {
       
        public string Titulo { get; set; }
        public string Professor { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }
     
    }
}

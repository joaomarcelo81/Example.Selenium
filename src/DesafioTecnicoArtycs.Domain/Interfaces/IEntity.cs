using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Interfaces
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime DataCadastro { get; set; }
    }
}

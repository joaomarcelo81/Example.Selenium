﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioTecnicoArtycs.Domain.Dto.Reponse
{
    /// <summary>
    /// DTO Curso para as Respostas
    /// </summary>
    public class CursoResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Professor { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}

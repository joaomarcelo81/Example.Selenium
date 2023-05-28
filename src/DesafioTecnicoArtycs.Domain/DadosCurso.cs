namespace DesafioTecnicoArtycs.Domain
{
    public class DadosCurso
    {

        public string Titulo { get; set; }
        public string Professor { get; set; }
        public string CargaHoraria { get; set; }
        public string Descricao { get; set; }

        public override string ToString()
        {
            return @$"
                    ------------------------------------
                    Titulo :              {Titulo} 
                    Professor :           {Professor} 
                    CargaHoraria :        {CargaHoraria} 
                    Descricao :           {Descricao}
                    -----------------------------------";
        }

    }
}
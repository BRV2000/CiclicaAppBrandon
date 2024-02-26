using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class DatosBiomarcadores
    {
        public DateTime bioFecha { get; set; }
        public string bioNotas { get; set; }
        public decimal bioTemp_Basal { get; set; }
        public string bioLibido { get; set; }
        public string cambioCervix_Altura { get; set; }
        public string cambioCervix_Apertura { get; set; }
        public string cambioCervix_Descripcion { get; set; }
        public string EstadoAnimo_Nombre { get; set; }
        public string Sint_Nombre { get; set; }
        public string T_Sang_Nombre { get; set; }
        public string Cant_Menstruacion_Nombre { get; set; }
        public string MocoC_Olor { get; set; }
        public string MocoC_Cantidad { get; set; }
        public string TipoF_Cantidad { get; set; }
        public string TipoF_Olor { get; set; }
    }

}

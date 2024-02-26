using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entidades
{
    public class Biomarcadores
    {   
        //Registro Diario
        public int Reg_UserID { get; set; }
        public DateTime Fecha { get; set; }
        public string? Notas { get; set; }
        public decimal Temp_Basal { get; set; }
        public string Libido { get; set; }
        //Cambio cervical
        public int CamCervixId { get; set; }
        //Estado Animo
        public int EstadoAnimo_ID { get; set; }
        //Tipo Sintomas
        public int Sint_Id { get; set; }
        // tipo sangrado
        public int T_Sang_Id { get; set; }
        //cantidad menstruacion
        public int Cant_MenstruacionId { get; set; }
        // Moco Cervix
        public int MocoCervixId { get; set; }
        //Tipo de flujo
        public int Tipo_FlujoId { get; set; }
    }
}

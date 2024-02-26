using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Notifi_Anticonceptivos
    {
        public string Anti_Concep_Nombre { get; set; }
        public DateTime Notifi_Start_Date { get; set; }
        public DateTime? Notifi_Fecha_Final { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entidades
{
    public class Notificaciones
    {
        public int Notifi_ID { get; set; }
        public int Notifi_User_ID { get; set; }
        public int Notifi_Anti_Concep_ID { get; set; }
        public Boolean Notifi_Estado { get; set; }
        public DateTime Notifi_Start_Date { get; set; }
        public DateTime Notifi_Start_Time { get; set; }
    }
}

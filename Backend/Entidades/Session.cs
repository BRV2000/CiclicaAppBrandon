using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class Session
    {

        public int SessionId { get; set; }
        public int Session_User_Id {  get; set; }
        public String SessionCod {  get; set; }
        public DateTime Session_Fecha_Inicio {  get; set; }
        public DateTime? Session_Fecha_Final { get; set; }
        public Boolean Session_Estado { get; set; }

    }
}

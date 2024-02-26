using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class CicloMenstrual
    {
        public int MenstruacionId { get; set; }
        public int UsuarioId { get; set; } 
        public DateTime FechaInicioCiclo { get; set; }
        public int DuracionCiclo { get; set; }
        public int DuracionMenstruacion { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ResHistorialAnticonceptivos : ResBase
    {
        public List<Notifi_Anticonceptivos> HistorialAnticonceptivo { get; set; }
    }
}

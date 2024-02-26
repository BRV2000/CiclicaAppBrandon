using Frontend.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.CapturarDatos
{
   public static class ObtenerDatosAEnviar
    {
        //Sesion Global
        public static string Session { get; set; }

        // Salud sexual
        public static int IdAnticoncep { get; set; }
        public static List<Anticonceptivos> anticonceptivos { get; set; }
        public static List<Notifi_Anticonceptivos> historialAnticoncep { get; set; }
        public static List<Consejos> consejos { get; set; }

        //Salud intima
        public static List<CicloMenstrual> cicloMenstruals { get; set; }
        public static List<DatosBiomarcadores> historialbiomarcadors { get; set; }

        //Biomarcadores

        public static int IdEstadoAnimo { get; set; }
        public static int IdCamCervix { get; set; }
        public static int IdSintomas { get; set; }
        public static int IdSTang { get; set; }
        public static int IdSangradoMenstr { get; set; }
        public static string Libido { get; set; }
        public static int IdMocoCervix { get; set; }
        public static int IdTF { get; set; }

        //Productos
        public static List<Producto> ListaProductos { get; set; }
        public static int CategoriaProductoId { get; set; }

    }
}

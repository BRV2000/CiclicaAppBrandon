using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entidades
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string skuProducto { get; set; }
        public string nombre { get; set; }
        public int cantidad { get; set; }
        public decimal precio { get; set; }
        public DateTime fechaIngreso { get; set; }
        public Boolean status { get; set; }
        public int idTipo { get; set; }

        public string RutaImagen { get; set; }
    }
}

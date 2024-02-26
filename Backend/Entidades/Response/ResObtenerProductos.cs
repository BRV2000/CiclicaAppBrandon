using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Entidades
{
    public class ResObtenerProductos : ResBase
    {
        public List<Producto> listaProductos { get; set; }
    }
}

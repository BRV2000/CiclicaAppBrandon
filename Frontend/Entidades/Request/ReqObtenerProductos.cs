using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Entidades
{
    public class ReqObtenerProductos : ReqBase
    {
        public int categoriaProductoId { get; set; }
    }
}

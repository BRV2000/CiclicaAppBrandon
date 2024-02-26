using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Frontend.Entidades
{
    public class ResLoginUsuario : ResBase
    {
        public string session { get; set; }
    }
}

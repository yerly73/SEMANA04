using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEMANA04
{
    public class Producto
    {
        public string nombreProducto { get; internal set; }
        public string cantidadPorUnidad { get; internal set; }
        public double precioUnidad { get; internal set; }
        public string categoriaProducto { get; internal set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_Accesorios_Belén.CapaEntidades
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        public int IdProveedor { get; set; }
    }
}

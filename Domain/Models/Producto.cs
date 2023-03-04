using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Activo { get; set; }

        public List<VentaDetalle> VentaDetalles { get; set; }
    }
}

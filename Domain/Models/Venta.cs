using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Venta
    {
        public int Id { get; set; }
        public decimal Total { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaVenta { get; set; }
        public int Activo { get; set; }


        public Usuario Usuario { get; set; }
        public List<VentaDetalle> VentaDetalles { get; set; }
    }
}

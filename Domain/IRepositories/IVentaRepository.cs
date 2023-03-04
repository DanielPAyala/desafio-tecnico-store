using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IVentaRepository
    {
        Task Createventa(Venta venta);
        Task<List<Venta>> GetListVentas();
        Task<List<Venta>> GetListVentasByUser(int idUsuario);
        Task<Venta> GetVentaById(int id);
        Task DeleteVenta(Venta venta);
        Task UpdateVenta(Venta venta);
    }
}

using Domain.IRepositories;
using Domain.IServices;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _ventaRepository;
        public VentaService(IVentaRepository ventaRepository)
        {
            _ventaRepository = ventaRepository;
        }

        public async Task Createventa(Venta venta)
        {
            await _ventaRepository.Createventa(venta);
        }

        public async Task DeleteVenta(Venta venta)
        {
            await _ventaRepository.DeleteVenta(venta);
        }

        public async Task<List<Venta>> GetListVentas()
        {
            return await _ventaRepository.GetListVentas();
        }

        public async Task<List<Venta>> GetListVentasByUser(int idUsuario)
        {
            return await _ventaRepository.GetListVentasByUser(idUsuario);
        }

        public async Task<Venta> GetVentaById(int id)
        {
            return await _ventaRepository.GetVentaById(id);
        }

        public async Task UpdateVenta(Venta venta)
        {
            await _ventaRepository.UpdateVenta(venta);
        }
    }
}

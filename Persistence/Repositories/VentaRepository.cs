using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class VentaRepository : IVentaRepository
    {
        public VentaRepository()
        {
            using (var context = new ApiContext())
            {
                /*var productos = new List<Producto>
                {
                    new Producto {Id = 1, Name="Memoria RAM 8GB", Description="Corsair Vengeance LPX DDR4", Precio= 75, Stock =10, Activo=1},
                    new Producto {Id = 2,Name="SSD 225GB", Description="Disco Externo 225 Gb", Precio= 105, Stock =8, Activo=2},
                    new Producto {Id = 3,Name="Teclado mecánico", Description="Teclado Gamer HA -K616", Precio= 150, Stock =7, Activo=3}
                };
                context.Productos.AddRange(productos);
                context.SaveChanges();*/

                var ventas = new List<Venta>
                {
                    new Venta {
                        Total = 255, FechaVenta = DateTime.Now, UsuarioId = 1, Activo = 1,
                        VentaDetalles =  new List<VentaDetalle>
                        {
                            new VentaDetalle{ VentaId = 1, ProductoId = 1, Cantidad = 2, Precio = 150 , Producto = new Producto {
                                    Name="Memoria RAM 8GB", Description="Corsair Vengeance LPX DDR4", Precio= 75, Stock =10, Activo=1
                                }
                            },
                            new VentaDetalle{ VentaId= 1, ProductoId=2, Cantidad = 1, Precio = 105, Producto = new Producto {
                                    Name="SSD 225GB", Description="Disco Externo 225 Gb", Precio= 105, Stock =8, Activo=1
                                }
                            }
                        }
                    },
                    new Venta {
                        Total = 150, FechaVenta = DateTime.Parse("12/01/2022"), UsuarioId = 2, Activo = 1,
                        VentaDetalles = new List<VentaDetalle>
                        {
                            new VentaDetalle{VentaId = 2, ProductoId=3, Cantidad=1, Precio = 150, Producto =new Producto {
                                Name="Teclado mecánico", Description="Teclado Gamer HA -K616", Precio= 150, Stock =7, Activo=1}  
                            }
                        }
                    },
                };
                context.Ventas.AddRange(ventas);
                context.SaveChanges();
            }
        }

        public async Task Createventa(Venta venta)
        {
            using (var context = new ApiContext())
            {
                context.Add(venta);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteVenta(Venta venta)
        {
            using (var context = new ApiContext())
            {
                venta.Activo = 0;
                context.Entry(venta).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Venta>> GetListVentas()
        {
            using (var context = new ApiContext())
            {
                return await context.Ventas.Where(x => x.Activo == 1).Include(x => x.VentaDetalles).ToListAsync();
            }
        }

        public async Task<List<Venta>> GetListVentasByUser(int idUsuario)
        {
            using (var context = new ApiContext())
            {
                return await context.Ventas.Where(x => x.Activo == 1 && x.UsuarioId == idUsuario).Include(x => x.VentaDetalles).ToListAsync();
            }
        }

        public async Task<Venta> GetVentaById(int id)
        {
            using (var context = new ApiContext())
            {
                return await context.Ventas.Where(x => x.Activo == 1 && x.Id == id).FirstOrDefaultAsync();
            }
        }

        public async Task UpdateVenta(Venta venta)
        {
            using (var context = new ApiContext())
            {
                context.Update(venta);
                await context.SaveChangesAsync();
            }
        }
    }
}

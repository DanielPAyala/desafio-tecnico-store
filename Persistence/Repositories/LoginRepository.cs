using Domain.IRepositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace Persistence.Repositories
{
    public class LoginRepository : ILoginRepository
    {
        public LoginRepository()
        {
            using (var context = new ApiContext())
            {
                var users = new List<Usuario>
                {
                    new Usuario{NombreUsuario = "Carlos124", Password = Encriptar.EncriptarPassword("1234567"), Activo = 1 },
                    new Usuario{NombreUsuario = "Daniel98", Password = Encriptar.EncriptarPassword("daniel123"), Activo = 1 }
                };
                context.Usuarios.AddRange(users);
                context.SaveChanges();
            }
        }

        public async Task<Usuario> ValidateUser(Usuario usuario)
        {
            using var context = new ApiContext();
            var user = await context.Usuarios.Where(x => x.NombreUsuario == usuario.NombreUsuario && x.Password == usuario.Password).FirstOrDefaultAsync();
            return user;
        }
    }
}

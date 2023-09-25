using DAL;
using Entities;
using Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN
{
    public class UsuarioLN
    {
        public bool CrearUsuario(Usuario usuario)
        {
            using (var dbContext = new DatabaseContext())
            {
                var usuariosOperations = new UsuariosOperations(dbContext);

                // Aquí puedes encriptar la contraseña antes de guardarla en la base de datos
                usuario.Contrasenia = Encriptacion.Encriptar(usuario.Contrasenia, 3);

                Console.WriteLine(usuario.Contrasenia);

                // Continuar con la creación del usuario en la base de datos
                return usuariosOperations.CrearUsuario(usuario);
            }
        }

        public bool LoginUsuario(Usuario usuario)
        {
            using (var dbContext = new DatabaseContext())
            {
                var usuariosOperations = new UsuariosOperations(dbContext);

                try
                {
                    bool result = usuariosOperations.LoginUsuario(usuario);
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    }
                    return false;
                }
            }
        }


    }
}

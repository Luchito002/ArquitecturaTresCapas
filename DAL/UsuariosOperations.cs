using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace DAL
{
    public class UsuariosOperations
    {
        private readonly DatabaseContext _context;

        public UsuariosOperations(DatabaseContext context)
        {
            _context = context;
        }

        public bool CrearUsuario(Usuario usuario)
        {
            try
            {
                _context.Usuarios.Add(usuario);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool LoginUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new ArgumentNullException(nameof(usuario));
                }
                // Busca un usuario con el nombre de usuario proporcionado en la base de datos
                var usuarioEncontrado = _context.Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre);

                if (usuarioEncontrado != null)
                {
                    string contraseniaDesencriptada = Encriptacion.Desencriptar(usuarioEncontrado.Contrasenia, 3);

                    // Verifica si la contraseña coincide
                    if (contraseniaDesencriptada == usuario.Contrasenia)
                    {
                        // Inicio de sesión exitoso
                        return true;
                    }
                }
                // Inicio de sesión fallido
                return false;
            }
            catch (Exception ex)
            {
                // Puedes manejar excepciones específicas aquí, por ejemplo, problemas con la base de datos.
                return false;
            }
        }
    }
}

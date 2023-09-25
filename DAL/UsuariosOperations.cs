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
                // Verifica si ya existe un usuario con el mismo nombre
                var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre);

                if (usuarioExistente != null)
                {
                    // Ya existe un usuario con el mismo nombre, no se puede crear otro
                    return false;
                }

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
            // Busca un usuario con el nombre de usuario proporcionado en la base de datos
            var usuarioEncontrado = _context.Usuarios.FirstOrDefault(u => u.Nombre == usuario.Nombre);

            Console.WriteLine(usuarioEncontrado.Contrasenia);
            Console.WriteLine(Encriptacion.Desencriptar(usuarioEncontrado.Contrasenia, 3));

            // Verifica si se encontró un usuario y si la contraseña coincide
            if (usuarioEncontrado != null && Encriptacion.Desencriptar(usuarioEncontrado.Contrasenia, 3) == usuario.Contrasenia)
            {
                // Inicio de sesión exitoso
                return true;
            }

            // Inicio de sesión fallido
            return false;
        }
    }
}

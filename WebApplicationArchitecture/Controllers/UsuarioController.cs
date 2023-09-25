using Entities;
using LN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationArchitecture.Contratos;

namespace WebApplicationArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioLN usuarioLn;
        public UsuarioController()
        {
            usuarioLn = new UsuarioLN();
        }

        [HttpPost("login")]
        public Response LoginUsuario(Usuario usuario)
        {
            string message = "Algo salio mal";
            bool result = usuarioLn.LoginUsuario(usuario);
            if(result)
           {
                // Crear una instancia de la clase Request y almacenarla en la sesión
                var request = new Request("session_id_value");
                HttpContext.Session.SetString("SessionId", "idsesioncurrent");

                message = "Se inicio sesion correctamente";
            }
            return new Response(
                message: message,
                details: "Sin detalles",
                codigoEstado: 200
            );
        }

        [HttpPost("crear")]
        public Response CrearUsuario(Usuario usuario)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionId")))
            {
                return new Response(
                    "Algo salio mal",
                    "No tienes el Id sesion",
                    200
                );
            }
            string message = "Algo salio mal";
            bool respuesta = usuarioLn.CrearUsuario(usuario);
            if (respuesta) message = "Se inserto el usuario correctamente";

            return new Response(
                message,
                details: "Sin detalles",
                200
            );
        }
    }
}

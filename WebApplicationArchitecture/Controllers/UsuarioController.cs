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

        [HttpPost]
        public Response LoginUsuario(Usuario usuario)
        {
            string message = "Algo salio mal";
            bool result = usuarioLn.LoginUsuario(usuario);
            if(result)
            {
                // Crear una instancia de la clase Request y almacenarla en la sesión
                var request = new Request("session_id_value");
                HttpContext.Session.SetString("SessionId", "asdfasdf");

                message = "Se inicio sesion correctamente";
            }
            return new Response(
                message: message,
                details: "Sin detalles",
                codigoEstado: 200
            );
        }
    }
}

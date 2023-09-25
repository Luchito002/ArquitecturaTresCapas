using LN;
using Entities;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using WebApplicationArchitecture.Contratos;
using static LN.PersonaLN;

namespace WebApplicationArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaLN personaLn;

        public PersonaController()
        {
            personaLn = new PersonaLN(); // Asegúrate de que esta línea inicialice correctamente personaLn
        }

        [HttpPost("agregarPersona")]
        public Response Post(Persona persona)
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("SessionId")))
            {
                return new Response(
                    "Algo salió mal",
                    "No tienes el ID de sesión",
                    200
                );
            }

            string respuesta = personaLn.InsertarPersona(persona);
            return new Response(
                respuesta,
                "Sin detalles",
                200
            );
        }
        [HttpGet]
        public IActionResult ListarPersonas()
        {
            var personas = personaLn.ListarPersonas();
            return Ok(personas);
        }
    }

}

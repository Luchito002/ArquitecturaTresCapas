using LN;
using Entities;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using WebApplicationArchitecture.Contratos;

namespace WebApplicationArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly PersonaLN personaLn;

        public PersonaController()
        {
            personaLn = new PersonaLN();
        }

        // POST api/<PersonaController>
        [HttpPost]
        public Response Post(Persona persona)
        {
            string sessionId = HttpContext.Session.GetString("SessionId");
            if(string.IsNullOrEmpty(sessionId))
            {
                return new Response(
                    "Algo salio mal",
                    "No tienes el Id sesion",
                    200
                );
            }

            Console.WriteLine(sessionId);

            string respuesta = personaLn.InsertarPersona(persona);
            return new Response(
                respuesta,
                "Sin detalles",
                200
            );
        }
    }
}

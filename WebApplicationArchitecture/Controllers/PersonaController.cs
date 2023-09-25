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

        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PersonaController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PersonaController>
        /*[HttpPost]
        public void Post([FromBody] string value)
        {
        }*/

        // POST api/<PersonaController>
        [HttpPost]
        public Response Post(Persona persona)
        {
            //if (persona.SessionId.Length < 0 || persona.SessionId == "")
            //{
            //    return new Response(
            //        "Ha ocurrido un error",
            //        "No tienes permisos",
            //        200
            //    );
            //} 
            string respuesta = personaLn.InsertarPersona(persona);
            return new Response(
                respuesta,
                "Sin detalles",
                200
            );
        }

        // PUT api/<PersonaController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

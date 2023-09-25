using Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class PersonasOperations
    {
        private readonly DatabaseContext _context;

        public PersonasOperations(DatabaseContext context)
        {
            _context = context;
        }

        public void InsertarPersona(Persona persona)
        {
            try
            {
                _context.Personas.Add(persona);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Maneja las excepciones específicas de Entity Framework Core aquí
                // Puedes registrar el error o realizar otra acción adecuada según tus necesidades
                Console.WriteLine("Error al insertar la persona en la base de datos: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones generales aquí
                // Puedes registrar el error o realizar otra acción adecuada según tus necesidades
                Console.WriteLine("Error general al insertar la persona: " + ex.Message);
            }
        }

        public List<Persona> ListarPersonas()
        {
            return _context.Set<Persona>().ToList();
        }
    }
}

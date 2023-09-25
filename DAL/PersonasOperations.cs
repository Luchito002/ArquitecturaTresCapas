using Entities;

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
            _context.Personas.Add(persona);
            _context.SaveChanges();
        }
    }
}

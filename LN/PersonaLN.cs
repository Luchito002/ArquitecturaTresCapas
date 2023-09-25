using DAL;
using Entities;

namespace LN
{
    public class PersonaLN
    {
        public string InsertarPersona(Persona persona)
        {
            // Validación del nombre
            if (string.IsNullOrEmpty(persona.Nombre))
            {
                return "El nombre no puede estar vacío.";
            }

            // Validación de la dirección
            if (string.IsNullOrEmpty(persona.Direccion))
            {
                return "La dirección no puede estar vacía.";
            }

            // Crear una instancia de DatabaseContext
            using (var dbContext = new DatabaseContext())
            {
                var personasOperations = new PersonasOperations(dbContext);

                try
                {
                    // Llama al método InsertarPersona de PersonasOperations
                    personasOperations.InsertarPersona(persona);
                    return "Se ha insertado una nueva persona correctamente.";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    }
                    return $"Error al insertar la persona: {ex.Message}";
                }
            }
        }
    }
}
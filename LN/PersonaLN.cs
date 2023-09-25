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
            //using (var dbContext = new DatabaseContext(DatabaseContext.GetOptions()))
            using (var dbContext = new DatabaseContext())
            {
                try
                {
                    // Llama al método InsertPersona de la DAL
                    dbContext.InsertarPersona(persona);
                    return "Se insertó correctamente.";
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
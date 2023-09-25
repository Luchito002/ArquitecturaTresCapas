using DAL;
using Entities;

namespace LN
{
    public class PersonaLN
    {
        public string InsertarPersona(Persona persona)
        {
            // Validación del nombre
            if (string.IsNullOrWhiteSpace(persona.Nombre))
            {
                return "El nombre no puede estar vacío.";
            }

            // Validación de la dirección
            if (string.IsNullOrWhiteSpace(persona.Direccion))
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

        public List<Persona> ListarPersonas()
        {
            using (var dbContext = new DatabaseContext())
            {
                var personasOperations = new PersonasOperations(dbContext);

                try
                {
                    // Llama al método ListarPersonas de PersonasOperations
                    List<Persona> listaPersonas = personasOperations.ListarPersonas();

                    if (listaPersonas.Count > 0)
                    {
                        return listaPersonas; // Devolver la lista de personas encontradas
                    }
                    else
                    {
                        return null; // Devolver null o una lista vacía si no se encontraron personas
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.InnerException != null)
                    {
                        Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                    }

                    // Manejar cualquier error y devolver un mensaje de error apropiado
                    return null;
                }
            }
        }

    }
}
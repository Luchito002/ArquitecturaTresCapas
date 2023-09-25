using Entities;

namespace WebApplicationArchitecture.Contratos
{
    public class Response
    {
        public Response(string message, string details, int codigoEstado)
        {
            Messsage = message;
            Details = details;
            CodigoEstado = codigoEstado;
        }

        public Response(string v1, List<Persona> listaPersonas, int v2)
        {
            V1 = v1;
            ListaPersonas = listaPersonas;
            V2 = v2;
        }

        public string Messsage { get; set; }    
        public string Details {  get; set; }    
        public int CodigoEstado {  get; set; }
        public string V1 { get; }
        public List<Persona> ListaPersonas { get; }
        public int V2 { get; }
    }
}

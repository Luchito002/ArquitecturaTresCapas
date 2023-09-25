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
        public string Messsage { get; set; }    
        public string Details {  get; set; }    
        public int CodigoEstado {  get; set; } 
    }
}

namespace WebApplicationArchitecture.Contratos
{
    public class Request
    {
        public Request(string sessionId)
        {
            SessionId = sessionId;
        }

        public string SessionId { get; set; }
    }
}

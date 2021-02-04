using Newtonsoft.Json;

namespace ServicioSMC.ConfigureApp.ExceptionMiddleware
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string Mensaje { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

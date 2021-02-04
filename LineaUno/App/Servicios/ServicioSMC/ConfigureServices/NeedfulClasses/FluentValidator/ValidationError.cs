using Newtonsoft.Json;

namespace ServicioSMC.ConfigureServices.NeedfulClasses.FluentValidator
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Campo { get; }

        public string Mensaje { get; }

        public ValidationError(string field, string message)
        {
            Campo = field != string.Empty ? field : null;
            Mensaje = message;
        }
    }
}

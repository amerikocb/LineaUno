using System;

namespace LineaUno.App.Servicios.Modelo.SMC.v1.Response
{
    public class RecursoResponse
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Start_date { get; set; }
        public decimal Duration { get; set; }
        public string Tipo { get; set; }
        public Boolean Inconveniente { get; set; }
        public Boolean Supervisor { get; set; }
        public Boolean Tecnico { get; set; }
        public Boolean Open { get; set; }
        public int Parent { get; set; }
        public Boolean Urgencia { get; set; }
    }
}

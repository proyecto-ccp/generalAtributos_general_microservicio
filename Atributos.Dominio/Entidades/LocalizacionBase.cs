
namespace Atributos.Dominio.Entidades
{
    public abstract class LocalizacionBase
    {
        public int Idpais { get; set; }
        public string NombrePais { get; set; }
        public int Ididioma { get; set; }
        public string NombreIdioma { get; set; }
        public int Idmoneda { get; set; }
        public string Moneda { get; set; }
        public string AcronimoMoneda { get; set; }
        public int Idregion { get; set; }
        public string Region { get; set; }
        public Guid Idciudad { get; set; }
        public string Ciudad { get; set; }
    }
}

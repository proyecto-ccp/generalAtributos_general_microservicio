
namespace Atributos.Dominio.Entidades
{
    public class Pais
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int IdIdioma { get; set; }
        public string Idioma { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda { get; set; }
        public string AcronimoMoneda { get; set; }
        public string Indicativo { get; set; }
    }
}

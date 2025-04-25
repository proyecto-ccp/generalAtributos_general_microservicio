namespace Atributos.Aplicacion.Dto.Zonas
{
    public class ZonaDto
    {
        public Guid Id { get; set; }
        public Guid IdCiudad { get; set; }
        public string? Ciudad { get; set; }
        public string Nombre { get; set; }
        public string Limites { get; set; }
    }

    public class ZonaOut : BaseOut
    {
        public ZonaDto Zona { get; set; }
    }

    public class ZonaOutList : BaseOut
    {
        public List<ZonaDto> Zonas { get; set; }
    }
}

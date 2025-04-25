namespace Atributos.Aplicacion.Dto.Ciudades
{
    public class CiudadDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Poblacion { get; set; }
        
    }

    public class CiudadOut : BaseOut
    { 
        public CiudadDto Ciudad { get; set; }
    }

    public class CiudadOutList: BaseOut
    {
        public List<CiudadDto> Ciudades { get; set; }
    }
}

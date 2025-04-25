
using System.ComponentModel.DataAnnotations.Schema;

namespace Atributos.Dominio.Entidades
{
    [Table("tbl_ciudades")]
    public class Ciudad: EntidadBase
    {
        [Column("idregion")]
        public int IdRegion { get; set; }

        [Column("poblacion")]
        public int Poblacion { get; set; }

        [Column("nombre")]
        public  string Nombre { get; set; }
    }
}

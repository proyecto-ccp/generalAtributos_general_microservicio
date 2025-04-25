using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Atributos.Dominio.Entidades
{
    [Table("tbl_zonas")]
    public class Zona : EntidadBase
    {
        [Column("idciudad")]
        public int IdCiudad { get; set; }

        [NotMapped]
        public string Ciudad { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("limites")]
        public string Limites { get; set; }
    
    

    }
}

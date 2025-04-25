using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atributos.Dominio.Entidades
{
    [Table("tbl_tipodocumento")]
    public class TipoDocumento : EntidadBase
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }

        [Column("codigo")]
        public string Codigo { get; set; }
    }
}

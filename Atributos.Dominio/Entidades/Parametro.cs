using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Atributos.Dominio.Entidades
{
    [Table("tbl_parametros")]
    public class Parametro
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("valor")]
        public string Valor { get; set; }

        [Column("descripcion")]
        public string Descripcion { get; set; }
    }
}

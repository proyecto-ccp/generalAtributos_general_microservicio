using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Atributos.Dominio.Entidades
{
    public class EntidadBase
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
    }
}

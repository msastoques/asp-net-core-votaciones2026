using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVotaciones2026.Models
{
    public class Sede
    {
        [Key]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        // Relación: una sede tiene muchos votos
        public ICollection<Voto> Votos { get; set; }
    }
}


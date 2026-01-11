using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspNetCoreVotaciones2026.Models
{
    public class Voto
    {
        [Key]
        public int VotoId { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Clave foránea
        [ForeignKey("Candidato")]
        public int CandidatoId { get; set; }

        // Navegación
        public Candidato Candidato { get; set; }
    }
}

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

        // FK Candidato
        public int CandidatoId { get; set; }
        public Candidato Candidato { get; set; }

        // FK Sede
        public string SedeId { get; set; }
        public Sede Sede { get; set; }
    }
}

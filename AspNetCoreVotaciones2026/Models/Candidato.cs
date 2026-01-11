using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVotaciones2026.Models
{
    public class Candidato
    {
        
        public int Id { get; set; }

        public string NumeroTarjeton { get; set; }

        [Required]
        [MaxLength(150)]
        public string Nombre { get; set; }        

        [MaxLength(200)]
        public string Propuesta { get; set; }

        // Relación: un candidato tiene muchos votos
        public int Votos { get; set; }
    }
}

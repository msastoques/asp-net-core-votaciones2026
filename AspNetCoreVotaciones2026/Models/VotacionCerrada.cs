using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVotaciones2026.Models
{
    public class VotacionCerrada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public bool Cerrado { get; set; }
    }
}


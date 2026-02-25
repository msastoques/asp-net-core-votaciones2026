using System.ComponentModel.DataAnnotations;

namespace AspNetCoreVotaciones2026.Models
{
    public class IniciarVotacionViewModel
    {
        public string Id { get; set; }

        public string Nombre { get; set; }

        [Required(ErrorMessage = "El código es obligatorio")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
    }
}

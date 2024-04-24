using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace Proyecto_Resenas_CQS.Models
{
    public class Juego
    {
        [Key]
        public int JuegoId { get; set; }
        [Required]
        public String? NombreJuego { get; set; }
        [Required]
        public String Categoria { get; set; }
        [MaxLength(500), MinLength(50)]
        [Required]
        public String? Descripcion { get; set; }
        [Required]
        public decimal Precio { get; set; }
        [Required]
        public String Imagen { get; set; }

        [Required(ErrorMessage = "Escoja Una imagen")]
        [Display(Name = "Front Image")]

        [NotMapped]
        //public IFormFile FrontImage { get; set; }
        public List<Destacado>? Destacados { get; set; }
    }
}

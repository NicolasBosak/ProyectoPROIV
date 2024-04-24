using System.ComponentModel.DataAnnotations;

namespace Proyecto_Resenas_CQS.Models
{
    public class Resena
    {
        [Key]
        public int ResenaId { get; set; }

        [Required]
        public int JuegoId { get; set; }
        public Juego Juego { get; set; }

        [Required]
        public string UsuarioId { get; set; }
        //public Usuario Usuario { get; set; }

        [Required]
        public int Puntuacion { get; set; } // La puntuación del juego, de 1 a 5

        [MaxLength(500)]
        public string Comentario { get; set; } // El comentario asociado a la reseña
    }
}

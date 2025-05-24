using System.ComponentModel.DataAnnotations;

namespace PC3_Progra1.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required]
        public int PostId { get; set; }

        [Required]
        public string Sentimiento { get; set; } // "like" o "dislike"

        public DateTime Fecha { get; set; } = DateTime.UtcNow;
    }
}

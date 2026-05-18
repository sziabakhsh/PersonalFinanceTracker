using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace PersonalFinanceTracker.Entities
{
    public class RefreshToken
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }
        public User? User { get; set; } = null!;
        [Required]
        public string Token { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [Required]
        [Column(TypeName = "timestamp with time zone")]
        public DateTime ExpiredAt { get; set; }
        public DateTime? RevokedAt { get; set; }
    }
}

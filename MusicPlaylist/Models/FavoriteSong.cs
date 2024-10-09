using System.ComponentModel.DataAnnotations;

namespace CoreEntityFramework.Models
{
    public class FavoriteSong
    {
        [Key]
        public int UserId { get; set; }
        public virtual User? User { get; set; }

      
        public int SongId { get; set; }
        public virtual Song? Song { get; set; }
    }
}

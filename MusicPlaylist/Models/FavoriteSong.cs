using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreEntityFramework.Models
{
    public class FavoriteSong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // Identity column
        public int FavoriteSongId { get; set; }

        public int UserId { get; set; }
        public int SongId { get; set; }
    }
}

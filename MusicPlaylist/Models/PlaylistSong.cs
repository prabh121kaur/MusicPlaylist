using System.ComponentModel.DataAnnotations;

namespace CoreEntityFramework.Models
{
    public class PlaylistSong
    {
        [Key]
        public int PlaylistId { get; set; }
        public virtual Playlist? Playlist { get; set; }

      
        public int SongId { get; set; }
        public virtual Song? Song { get; set; }
    }
}

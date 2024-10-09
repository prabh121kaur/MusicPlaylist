using System.ComponentModel.DataAnnotations;

namespace CoreEntityFramework.Models
{
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string PlaylistColor { get; set; }

        public bool IsPrivate { get; set; }

        public DateTime CreatedDate { get; set; }

        // A playlist belongs to one user
        public int UserId { get; set; }
        public virtual User? User { get; set; }

        // A playlist can contain many songs
        public ICollection<PlaylistSong>? PlaylistSongs { get; set; }
    }

    public class PlaylistDto
    {
        public int PlaylistId { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public required string PlaylistColor { get; set; }

        public bool IsPrivate { get; set; }
    }
}

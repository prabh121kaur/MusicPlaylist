using System.ComponentModel.DataAnnotations;

namespace CoreEntityFramework.Models
{
    public class Song
    {
        [Key]
        public int SongId { get; set; }

        public required string Title { get; set; }

        public required string Artist { get; set; }

        public string? Album { get; set; }

        public string? Genre { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime ReleaseDate { get; set; }

        // A song can appear in many playlists
        public ICollection<PlaylistSong>? PlaylistSong { get; set; }

        // A song can be marked as a favorite by many users
        public ICollection<FavoriteSong>? FavoriteSongs { get; set; }
    }

    public class SongDto
    {
        public int SongId { get; set; }

        public required string Title { get; set; }

        public required string Artist { get; set; }

        public string? Album { get; set; }

        public string? Genre { get; set; }
    }
}

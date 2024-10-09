using System.ComponentModel.DataAnnotations;

namespace CoreEntityFramework.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public string? ProfilePicture { get; set; }

        // A user can create multiple playlists
        public ICollection<Playlist>? Playlists { get; set; }

        // A user can mark multiple songs as favorites
        public ICollection<FavoriteSong>? FavoriteSongs { get; set; }
    }

    public class UserDto
    {
        public int UserId { get; set; }

        public required string Username { get; set; }

        public required string Email { get; set; }

        public string? ProfilePicture { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Reflection;
using CoreEntityFramework.Models;

namespace CoreEntityFramework
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Playlist> Playlists { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<PlaylistSong> PlaylistSongs { get; set; }

        public DbSet<FavoriteSong> FavoriteSongs { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

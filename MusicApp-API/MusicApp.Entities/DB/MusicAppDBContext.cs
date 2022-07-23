using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MusicApp.Entities.Models;

#nullable disable

namespace MusicApp.Entities.DB
{
    public partial class MusicAppDBContext : IdentityDbContext<ApplicationUser>
    {
        public MusicAppDBContext(DbContextOptions<MusicAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Artist> Artists { get; set; }
        public virtual DbSet<ArtistsUser> ArtistsUsers { get; set; }
        public virtual DbSet<Coutry> Coutries { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<Song> Songs { get; set; }
        public virtual DbSet<SongPlayedLog> SongPlayedLogs { get; set; }
        public virtual DbSet<SongsUser> SongsUsers { get; set; }

        //       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

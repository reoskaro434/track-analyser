using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackAnalyser.Models;

namespace TrackAnalyser.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       
        public DbSet<Artist> Artists { get; set; } 
        public DbSet<Canal> Canals { get; set; } 
        public DbSet<Track> Tracks { get; set; } 
        public DbSet<TrackEmission> TrackEmissions { get; set; } 
        public DbSet<TrackStatistic> TrackStatistics { get; set; } 
        public DbSet<DayStatistic> DayStatistics { get; set; } 
        public DbSet<CanalTrack> CanalTracks { get; set; } 
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<CanalTrack>()
                .HasKey(ct => new { ct.CanalId, ct.TrackId });
            builder.Entity<CanalTrack>()
                .HasOne(ct => ct.Canal)
                .WithMany(ct => ct.Tracks)
                .HasForeignKey(ct => ct.CanalId);
            builder.Entity<CanalTrack>()
                .HasOne(ct => ct.Track)
                .WithMany(ct => ct.Canals)
                .HasForeignKey(ct => ct.TrackId);
        }
    } 
    
}

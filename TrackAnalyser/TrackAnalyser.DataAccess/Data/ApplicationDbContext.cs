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
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        { }
    
    } 
    
}

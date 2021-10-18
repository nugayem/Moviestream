using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieDbContext : DbContext
    {
        
        public MovieDbContext( DbContextOptions<MovieDbContext>  options) : base(options)
        {

        }
        public DbSet<Movie> Movies {get;set;}
        public DbSet<Genre> Genres {get;set;}
        public DbSet<Cast> Casts {get;set;}
        public DbSet<Rating> Ratings {get;set;}
        public DbSet<SpokenLanguage> SpokenLanguage { get;set;}
        
    }        
    

}
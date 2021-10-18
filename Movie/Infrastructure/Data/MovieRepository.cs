using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class MovieRepository : IMovieRepository
    { 
        private readonly MovieDbContext _movieContext;
        public MovieRepository(MovieDbContext movieContext)
        {
            _movieContext = movieContext; 
        }

        public async Task<IReadOnlyList<Movie>> GetProductsAsync()
        {
            return await _movieContext.Movies
                
                .ToListAsync();
        }

        
    }
}
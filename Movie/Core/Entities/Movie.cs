using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Movie:  BaseEntity
    {
        public Movie()
        { 
            this.Casts = new HashSet<Cast>();
            this.Genres = new HashSet<Genre>();
            this.Ratings = new HashSet<Rating>(); 
            this.ProductionCompany = new HashSet<ProductionCompany>();
        }
        public string ImdbID { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Budget {get; set;}
        public string Plot { get; set; }
        public int Popularity { get; set; }
        public string PosterPath { get; set; }
        public DateTime ReleasedDate { get; set; }        
        public string Title { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal Revenue { get; set; }
        public string Runtime { get; set; }
        public string Tagline { get; set; }
        public bool Video { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }          
        public virtual ICollection<SpokenLanguage> SpokenLanguage { get; set; }
        public virtual ICollection<ProductionCompany> ProductionCompany { get; set; }
        public virtual ICollection<Cast> Casts { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }     
        public ICollection<Rating> Ratings {get;set;}
    
    }

    public class Cast:BaseEntity
    {
        public Cast()
        {            
            this.Roles = new HashSet<Role>();
        } 
        public int MovieId { get; set; }
        public Movie Movies { get; set; } 
        public int ProdileId { get; set; }
        public Profile Profile { get; set; }
        public string Character { get; set; }
        
        public virtual ICollection<Role> Roles { get; set; }   
        
    }

    
    public class Role :  BaseEntity
    {
        public string  Name { get; set; }
    }
}
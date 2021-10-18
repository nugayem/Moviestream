using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Genre:BaseEntity
    { 
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
        }
        public string Name { get; set; }
        public virtual ICollection<Movie> Movies { get; set; }

    }
}
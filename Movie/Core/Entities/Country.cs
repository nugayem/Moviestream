using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Code { get; set; }
        public string Alias { get; set; }
    }
}
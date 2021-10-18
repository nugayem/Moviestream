using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Profile  :  BaseEntity
    { 
        public string Nickname {get; set;}
        public string Firstname {get; set;}
        public string Lastname {get; set;}
        public DateTime DateOfBirth { get; set; }
        public string Picture {get; set;}
        public string State {get; set;}
        public string Country {get; set;}
        public string PhoneNumber {get; set;}
        public string EmailAddress {get; set;} 
    }
    public class Rating: BaseEntity
    {        
        public string code { get; set; }
        public string Description { get; set; }
    }

    public class ProductionCompany : BaseEntity
    { 
        public string LogoPath { get; set; }
        public string Name { get; set; }
        public int CountryID { get; set; }
        public Country Country { get; set; }
    }

    public class SpokenLanguage:  BaseEntity
    {
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
    }

}
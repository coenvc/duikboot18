using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Duikboot.Data.Models;

namespace Duikboot.Registration.Web.Models
{
    public class MeerijderDay
    { 
        public Meerijder Meerijder { get; set; } 
        public List<Dag> Days { get; set; }

        public MeerijderDay()
        {
            
        }
    }
}
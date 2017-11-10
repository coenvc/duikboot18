using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Models;

namespace Duikboot.Data.Repositories
{
    public class MeerijderRepository
    {
        private DuikbootDBEntities Db = new DuikbootDBEntities(); 

        public List<Meerijder> GetAll()
        {
            return Db.Meerijder.ToList(); 
        } 

        public Meerijder GetById(int id)
        {
            return Db.Meerijder.Find(id); 
        }

        public bool Add(Meerijder meerijder)
        {
            Db.Meerijder.Add(meerijder);
            return true;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Live.Models;

namespace Duikboot.Data.Live
{
    public class MeerijderRepository
    {
        private DuikbootDBEntities Db = new DuikbootDBEntities();
        public List<Meerijder> GetAll()
        {
            return Db.Meerijder.ToList();
        }

        public void Add(Meerijder meerijder)
        {
            Db.Meerijder.Add(meerijder);
            Db.SaveChanges();
        }

        public Meerijder GetById(int id)
        {
            return Db.Meerijder.Find(id);
        }

        public bool SpotsAvailableSaturday()
        {
            var spots = Db.Meerijder.Count(x => x.Zaterdag == true);

            if (spots <= 42)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableSunday()
        {
            var spots = Db.Meerijder.Count(x => x.Zondag == true);

            if (spots <= 42)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableMonday()
        {
            var spots = Db.Meerijder.Count(x => x.Maandag == true);

            if (spots <= 43)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableTuesday()
        {
            var spots = Db.Meerijder.Count(x => x.Dinsdag == true);

            if (spots <= 43)
            {
                return true;
            }
            return false;
        }
    }
}

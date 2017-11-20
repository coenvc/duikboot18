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
        private DBContext Db = new DBContext();
        public List<Meerijder> GetAll()
        {
            return Db.Meerijder.ToList();
        }

        public void Add(Meerijder meerijder)
        {
            Db.Meerijder.Add(meerijder);

            var spotsSaturday = Db.Meerijder.Count(x => x.Zaterdag == true);
            Capacity capactiySaturday = Db.Capacity.FirstOrDefault(x => x.Name == "zaterdag");
            capactiySaturday.Meerijders = spotsSaturday;

            var spotsSunday = Db.Meerijder.Count(x => x.Zaterdag == true);
            Capacity capactiySunday = Db.Capacity.FirstOrDefault(x => x.Name == "zondag");
            capactiySunday.Meerijders = spotsSunday;

            var spotsMonday = Db.Meerijder.Count(x => x.Zaterdag == true);
            Capacity capactiyMonday = Db.Capacity.FirstOrDefault(x => x.Name == "maandag");
            capactiyMonday.Meerijders = spotsMonday;

            var spotsTuesday = Db.Meerijder.Count(x => x.Zaterdag == true);
            Capacity capactiyTuesday = Db.Capacity.FirstOrDefault(x => x.Name == "dinsdag");
            capactiyMonday.Meerijders = spotsMonday;


            Db.SaveChanges();
        }

        public Meerijder GetById(int id)
        {
            return Db.Meerijder.Find(id);
        }

        public List<Meerijder> GetMeerijderByDay(string day)
        { 
            
            var meerijders = Db.Meerijder.SqlQuery($"select * from meerijder where {day} = 1").ToList();

            return meerijders;
        }

        public bool SpotsAvailableSaturday()
        {
            var spots = Db.Meerijder.Count(x => x.Zaterdag == true);

            if (spots >= 42)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableSunday()
        {
            var spots = Db.Meerijder.Count(x => x.Zondag == true);

            if (spots >= 42)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableMonday()
        {
            var spots = Db.Meerijder.Count(x => x.Maandag == true);

            if (spots >= 43)
            {
                return true;
            }
            return false;
        }

        public bool SpotsAvailableTuesday()
        {
            var spots = Db.Meerijder.Count(x => x.Dinsdag == true);

            if (spots >= 43)
            {
                return true;
            }
            return false;
        }

        public Dictionary<string, bool> GetAvailableDates()
        {
            var availableDates = new Dictionary<string, bool>
            {
                {"zaterdag", SpotsAvailableSaturday()},
                {"zondag", SpotsAvailableSunday()},
                {"maandag", SpotsAvailableMonday()},
                {"dinsdag", SpotsAvailableTuesday()}
            }; 

            return availableDates;
        } 
    }
}

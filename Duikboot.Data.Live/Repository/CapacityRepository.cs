using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Live.Models;

namespace Duikboot.Data.Live.Repository
{
    public class CapacityRepository
    {
        private DBContext Db = new DBContext();

        public int GetPercentage(string day)
        {
            var saturday = Db.Capacity.FirstOrDefault(x => x.Name == day);

            var meerijders = saturday.Meerijders;
            var leden = saturday.Leden;
            var totaal = saturday.MaxCapacity;

            var percentage = (meerijders + leden) * 100 / totaal;

            return (int) percentage;
        }

    }
}

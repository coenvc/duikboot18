using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Models;

namespace Duikboot.Data.Repositories
{
    class DagRepository
    {
        private DuikbootDBEntities Db = new DuikbootDBEntities();

        public List<Dag> GetAll()
        {
            return Db.Dag.ToList(); 
        }

        public Dag GetById(int id)
        {
            return Db.Dag.Find(id); 
        }

        public bool Add(Dag dag)
        {
            Db.Dag.Add(dag);
            return true;
        }
    }
}

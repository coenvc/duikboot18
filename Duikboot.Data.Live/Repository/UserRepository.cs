using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Live.Models;

namespace Duikboot.Data.Live.Repository
{
    public class UserRepository
    {
        private DBContext Context = new DBContext();

        public bool Login(User loginUser)
        {

            var user = Context.User.FirstOrDefault(x => x.Username == loginUser.Username && x.Password == loginUser.Password);

            return user != null;
        }

        public User GetByUsernameAndPassword(User loginUser)
        {
            var user = Context.User.FirstOrDefault(x => x.Username == loginUser.Username && x.Password == loginUser.Password);

            return user;
        }
    }
}

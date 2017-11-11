using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Duikboot.Data.Live.Models;

namespace Duikboot.Data.Live.ExtensionMethods
{
    public static class Extension
    {
        public static Meerijder NullToBool(this Meerijder meerijder)
        {

            if (meerijder.Zaterdag == null)
            {
                meerijder.Zaterdag = true;

            }
            else
            {
                meerijder.Zaterdag = false;
            }
            if (meerijder.Zondag == null)
            {
                meerijder.Zondag = true;
            }
            else
            {
                meerijder.Zondag = false;
            }
            if (meerijder.Maandag == null)
            {
                meerijder.Maandag = true;
            }
            else
            {
                meerijder.Maandag = false;
            }
            if (meerijder.Dinsdag == null)
            {
                meerijder.Dinsdag = true;
            }
            else
            {
                meerijder.Dinsdag = false;
            }

            return meerijder;
        }
    }
}

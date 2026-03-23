using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple
{
    public class JoUserRepository
    {
        public void DbUserMentes(JoUser joUser)
        {
            Console.WriteLine("User adat mentése");
        }

        public void DbUjUser(JoUser joUser)
        {
            Console.WriteLine("Új felhasználó felvitele.");
        }
    }
}

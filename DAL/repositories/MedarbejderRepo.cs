using DAL.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class MedarbejderRepo
    {
        public static void GetMedarbejdere()
        {
            using (var context = new WorkLoggerContext())
            {
                // Trigger database creation
                var count = context.Afdelinger.Count();  
            }
        }
    }
}

using DAL.context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class MedarbejderRepo
    {
        public static List<model.Medarbejder> GetMedarbejdere()
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from m in context.Medarbejdere
                        .Include(m => m.Afdeling)
                        .Include(m => m.Tidsregistreringer)
                        select m).ToList();

            }
        }
    }
}

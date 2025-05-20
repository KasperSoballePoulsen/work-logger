using DAL.context;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public class TidsregistreringRepo
    {
        public static List<Tidsregistrering> GetTidsregistreringer(int medarbejderID)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from m in context.Medarbejdere
                        where m.Id == medarbejderID
                        from t in m.Tidsregistreringer
                        select t).ToList();


            }
        }
    }
}

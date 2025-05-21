using DAL.context;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL.repositories
{
    public static class TidsregistreringRepo
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

        public static void OpretTidsregistrering(DateTime startTidspunkt, DateTime slutTidspunkt, int? sagsId, int medarbejderId)
        {
            using (var context = new WorkLoggerContext())
            {
                
                var medarbejder = context.Medarbejdere
                    .Include(m => m.Tidsregistreringer)
                    .FirstOrDefault(m => m.Id == medarbejderId);

                

                
                var nyTidsregistrering = new Tidsregistrering
                {
                    StartTidspunkt = startTidspunkt,
                    SlutTidspunkt = slutTidspunkt,
                    SagsId = sagsId
                };

                
                medarbejder.Tidsregistreringer.Add(nyTidsregistrering);

                
                context.SaveChanges();
            }
        }

    }
}

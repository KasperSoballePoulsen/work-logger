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

        public static List<Tidsregistrering> GetTidsregistreringerPaaDato(DateTime startTidspunkt, int medarbejderId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                var medarbejder = context.Medarbejdere
                    .Include(m => m.Tidsregistreringer)
                    .FirstOrDefault(m => m.Id == medarbejderId);

                if (medarbejder == null)
                    return new List<Tidsregistrering>();

                DateTime dato = startTidspunkt.Date;

                return medarbejder.Tidsregistreringer
                    .Where(t => t.StartTidspunkt.Date == dato)
                    .ToList();
            }
        }

        public static List<Tidsregistrering> GetTidsregistreringerPaaUge(DateTime startTidspunkt, int medarbejderId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                
                var kultur = System.Globalization.CultureInfo.CurrentCulture;
                int offset = kultur.DateTimeFormat.FirstDayOfWeek == DayOfWeek.Monday
                    ? ((int)startTidspunkt.DayOfWeek + 6) % 7
                    : (int)startTidspunkt.DayOfWeek;

                DateTime ugeStart = startTidspunkt.Date.AddDays(-offset);
                DateTime ugeSlut = ugeStart.AddDays(7);

                
                var medarbejder = context.Medarbejdere
                    .Include(m => m.Tidsregistreringer)
                    .FirstOrDefault(m => m.Id == medarbejderId);

                if (medarbejder == null)
                {
                    return new List<Tidsregistrering>();
                }

                return medarbejder.Tidsregistreringer
                    .Where(t => t.StartTidspunkt >= ugeStart && t.StartTidspunkt < ugeSlut)
                    .ToList();
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

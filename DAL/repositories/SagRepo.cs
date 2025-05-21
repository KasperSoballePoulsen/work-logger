using DAL.context;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public static class SagRepo
    {
        public static void AddSag(Sag sagDAL, int afdelingId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                
                var afdeling = context.Afdelinger
                    .Include(a => a.Sager)
                    .FirstOrDefault(a => a.Id == afdelingId);

                
                afdeling.Sager.Add(sagDAL);

                context.SaveChanges();
            }
        }

        public static List<Sag> GetSagerByAfdelingId(int afdelingId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                var afdeling = context.Afdelinger
                    .Include(afd => afd.Sager)
                    .FirstOrDefault(afd => afd.Id == afdelingId);

                return afdeling?.Sager ?? new List<Sag>();
            }
        }

        public static string GetSagOverskriftById(int id)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {

                return context.Sager
                      .Where(sag => sag.Id == id)
                      .Select(sag => sag.Overskrift)
                      .FirstOrDefault();

            }
        }

        public static void OpdaterSag(string updatedOverskrift, string updatedBeskrivelse, int sagId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                DAL.model.Sag sag = context.Sager.FirstOrDefault(s => s.Id == sagId);

                
                sag.Overskrift = updatedOverskrift;
                sag.Beskrivelse = updatedBeskrivelse;

                context.SaveChanges();
            }
        }

    }
}

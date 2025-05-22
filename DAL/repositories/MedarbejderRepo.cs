using DAL.context;
using DAL.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public static class MedarbejderRepo
    {
        public static void AddMedarbejder(Medarbejder medarbejderDAL)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                
                context.Afdelinger.Attach(medarbejderDAL.Afdeling);
                context.Medarbejdere.Add(medarbejderDAL);
                context.SaveChanges();

            }

        }

        public static List<Medarbejder> GetMedarbejdereFraAfdeling(int afdelingId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return context.Medarbejdere
                    .Include(m => m.Afdeling)
                    .Where(m => m.Afdeling.Id == afdelingId)
                    .ToList();
            }
        }

        public static List<model.Medarbejder> GetMedarbejdereWithoutTidsregistreringer()
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from m in context.Medarbejdere
                        .Include(m => m.Afdeling)
                        
                        select m).ToList();

            }
        }

       
        public static List<string> GetMedarbejderInitialer()
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from m in context.Medarbejdere
                        select m.Initialer).ToList();

            }
        }

        public static void OpdaterMedarbejder(string updatedInitialer, string updatedNavn, string updatedCprNr, int medarbejderId)
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                DAL.model.Medarbejder medarbejder = context.Medarbejdere.FirstOrDefault(m => m.Id == medarbejderId);
                medarbejder.Initialer = updatedInitialer;
                medarbejder.Navn = updatedNavn;
                medarbejder.CPRNummer = updatedCprNr;

                context.SaveChanges();
            }

        }
    }
}

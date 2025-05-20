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


        public static List<string> GetMedarbejderInitialer()
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from m in context.Medarbejdere
                        select m.Initialer).ToList();

            }
        }
        
    }
}

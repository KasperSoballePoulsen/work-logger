using DAL.context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public static class AfdelingRepo
    {
        public static List<model.Afdeling> GetAfdelinger()
        {
            using (WorkLoggerContext context = new WorkLoggerContext())
            {
                return (from afd in context.Afdelinger
                        .Include(afd => afd.Sager)
                        select afd).ToList();

            }
        }
    }
}

using DAL.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.repositories
{
    public static class SagRepo
    {
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
    }
}

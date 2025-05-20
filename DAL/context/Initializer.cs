using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.context
{
    internal class Initializer : CreateDatabaseIfNotExists<WorkLoggerContext>
    {
        protected override void Seed(DAL.context.WorkLoggerContext context)
        {
            model.Afdeling afdeling1 = new model.Afdeling("IT & Udvikling", 101);
            model.Afdeling afdeling2 = new model.Afdeling("Økonomi", 102);
            model.Afdeling afdeling3 = new model.Afdeling("HR & Personale", 103);

            context.Afdelinger.Add(afdeling1);
            context.Afdelinger.Add(afdeling2);
            context.Afdelinger.Add(afdeling3);

            
            model.Medarbejder kasper = new model.Medarbejder("KSP", "200802-1234", "Kasper", afdeling1);
            model.Medarbejder malthe = new model.Medarbejder("MWTB", "271002-4321", "Malthe", afdeling3);

            
            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 1, 8, 0, 0),
                new DateTime(2024, 5, 1, 16, 0, 0),
                null
            ));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 2, 9, 0, 0),
                new DateTime(2024, 5, 2, 17, 0, 0),
                null
            ));

            context.Medarbejdere.Add(kasper);
            context.Medarbejdere.Add(malthe);

            context.SaveChanges();
        }

    }
}

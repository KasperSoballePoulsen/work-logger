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

            model.Sag sag1 = new model.Sag(
                "Intern IT-support",
                "Håndtering af daglige supporthenvendelser fra medarbejdere vedrørende hardwareproblemer, softwarefejl og netværksadgang. Omfatter fejlsøgning, dokumentation og evt. kontakt til eksterne leverandører."
            );

            model.Sag sag2 = new model.Sag(
                "Systemopgradering",
                "Planlægning og implementering af opgradering af virksomhedens servere og operativsystemer. Omfatter test af kompatibilitet, backup af data, koordinering med brugere og nedetidshåndtering."
            );

            model.Sag sag3 = new model.Sag(
                "Udvikling af nyt system",
                "Analyse, design og udvikling af et internt tidsregistreringssystem til medarbejdere. Projektet inkluderer kravspecifikation, brugergrænseflade, databaseintegration og testforløb frem mod udrulning."
            );



            afdeling1.Sager.Add(sag1);
            afdeling1.Sager.Add(sag2);
            afdeling1.Sager.Add(sag3);

            context.SaveChanges();

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

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 8, 10, 9, 0, 0),
                new DateTime(2025, 8, 10, 17, 0, 0),
                sag1.Id
            ));
            context.Medarbejdere.Add(kasper);
            context.Medarbejdere.Add(malthe);


            

            

            context.SaveChanges();
        }

    }
}

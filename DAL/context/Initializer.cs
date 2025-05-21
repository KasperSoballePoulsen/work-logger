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

            context.Afdelinger.AddRange(new[] { afdeling1, afdeling2, afdeling3 });





            var sag1 = new model.Sag(
            "Intern IT-support",
            "Håndtering af daglige supporthenvendelser fra medarbejdere vedrørende hardwareproblemer, softwarefejl og netværksadgang. Omfatter fejlsøgning, dokumentation og evt. kontakt til eksterne leverandører."
            );

            var sag2 = new model.Sag(
            "Systemopgradering",
            "Planlægning og implementering af opgradering af virksomhedens servere og operativsystemer. Omfatter test af kompatibilitet, backup af data, koordinering med brugere og nedetidshåndtering."
            );

            var sag3 = new model.Sag(
            "Udvikling af nyt system",
            "Analyse, design og udvikling af et internt tidsregistreringssystem til medarbejdere. Projektet inkluderer kravspecifikation, brugergrænseflade, databaseintegration og testforløb frem mod udrulning."
            );

            var sag4 = new model.Sag("Dokumentation og onboarding", "Skabe teknisk dokumentation...");
            var sag5 = new model.Sag("Vedligeholdelse af databaser", "Performance tuning og backupstrategi...");

            afdeling1.Sager.AddRange(new[] { sag1, sag2, sag3, sag4, sag5 });
            



            context.SaveChanges();

            var kasper = new model.Medarbejder("KSP", "200802-1234", "Kasper", afdeling1);
            var jonas = new model.Medarbejder("JNS", "199508-4455", "Jonas", afdeling1);
            var louise = new model.Medarbejder("LSN", "199012-1233", "Louise", afdeling1);
            var malthe = new model.Medarbejder("MWTB", "271002-4321", "Malthe", afdeling3);
            var frederik = new model.Medarbejder("FHK", "199403-1111", "Frederik", afdeling3);
            var emil = new model.Medarbejder("ELH", "19950202-1111", "Emil", afdeling2);

            // Tidsregistreringer for Kasper
            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 8, 0, 0),
                new DateTime(2024, 5, 6, 12, 0, 0),
                sag1.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 12, 30, 0),
                new DateTime(2024, 5, 6, 16, 0, 0),
                sag2.Id));

            
            jonas.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 7, 9, 0, 0),
                new DateTime(2024, 5, 7, 11, 30, 0),
                sag2.Id));

            jonas.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 7, 12, 30, 0),
                new DateTime(2024, 5, 7, 15, 30, 0),
                sag3.Id));

            
            louise.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 8, 8, 30, 0),
                new DateTime(2024, 5, 8, 12, 0, 0),
                sag1.Id));

           
            malthe.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 8, 0, 0),
                new DateTime(2024, 5, 6, 12, 0, 0),
                null));

            malthe.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 12, 30, 0),
                new DateTime(2024, 5, 6, 15, 0, 0),
                null));

            
            frederik.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 9, 9, 0, 0),
                new DateTime(2024, 5, 9, 14, 0, 0),
                null));

            context.Medarbejdere.AddRange(new[] { kasper, jonas, louise, malthe, frederik, emil });
            context.SaveChanges();


        }

    }
}

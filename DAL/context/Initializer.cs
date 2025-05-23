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

            var sag6 = new model.Sag(
                "Budgetopfølgning og analyse",
                "Løbende opfølgning på afdelingens budgetter, afvigelsesanalyse samt udarbejdelse af rapporter til ledelsen. Omfatter også møder med budgetansvarlige og justering af forecast."
            );

            var sag7 = new model.Sag(
                "Debitorstyring",
                "Overvågning af kundetilgodehavender, udsendelse af rykkere, afstemning af betalinger og kontakt med kunder for at sikre rettidig betaling."
            );

            var sag8 = new model.Sag(
                "Månedsafslutning",
                "Gennemførsel af månedsafslutning herunder bogføring af bilag, afstemning af konti, og udarbejdelse af regnskabsrapport til koncernøkonomi."
            );

            afdeling2.Sager.AddRange(new[] { sag6, sag7, sag8 });

            var sag9 = new model.Sag(
                "Rekruttering og onboarding",
                "Planlægning og gennemførelse af rekrutteringsforløb, herunder stillingsopslag, samtaler og udvælgelse. Omfatter også onboarding af nye medarbejdere og introduktion til virksomheden."
            );

            var sag10 = new model.Sag(
                "Medarbejderudvikling og trivsel",
                "Koordinering af MUS-samtaler, udarbejdelse af udviklingsplaner samt initiativer til forbedring af medarbejdertrivsel og arbejdsmiljø. Omfatter også opfølgning på APV."
            );

            afdeling3.Sager.AddRange(new[] { sag9, sag10});

            context.SaveChanges();

            var kasper = new model.Medarbejder("KSP", "200802-1234", "Kasper", afdeling1);
            var jonas = new model.Medarbejder("JNS", "199508-4455", "Jonas", afdeling1);
            var louise = new model.Medarbejder("LSN", "199012-1233", "Louise", afdeling1);
            var malthe = new model.Medarbejder("MWTB", "271002-4321", "Malthe", afdeling3);
            var frederik = new model.Medarbejder("FHK", "199403-1111", "Frederik", afdeling3);
            var emil = new model.Medarbejder("ELH", "19950202-1111", "Emil", afdeling2);
            var sofie = new model.Medarbejder("SHJ", "199801-5678", "Sofie", afdeling3); 
            var mads = new model.Medarbejder("MMN", "198707-3344", "Mads", afdeling2);    
            var ida = new model.Medarbejder("IEH", "199311-9988", "Ida", afdeling3);      
            var niels = new model.Medarbejder("NBO", "198609-5566", "Niels", afdeling1);  
            var camilla = new model.Medarbejder("CMR", "199912-7788", "Camilla", afdeling2); 


            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 5, 8, 0, 0),   
                new DateTime(2025, 5, 5, 12, 0, 0),  
                sag1.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 6, 8, 0, 0),   
                new DateTime(2025, 5, 6, 16, 0, 0),  
                sag2.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 7, 8, 0, 0),   
                new DateTime(2025, 5, 7, 16, 0, 0), 
                sag1.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 8, 8, 0, 0),   
                new DateTime(2025, 5, 8, 16, 0, 0),  
                sag2.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 9, 8, 0, 0),   
                new DateTime(2025, 5, 9, 16, 0, 0),  
                sag1.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 6, 3, 8, 0, 0),    
                new DateTime(2025, 6, 3, 16, 0, 0),
                sag3.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 6, 4, 8, 0, 0),    
                new DateTime(2025, 6, 4, 12, 0, 0),
                sag2.Id));

            kasper.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 6, 6, 8, 0, 0),    
                new DateTime(2025, 6, 6, 14, 0, 0),
                sag5.Id));



            jonas.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 7, 9, 0, 0),
                new DateTime(2025, 5, 7, 11, 30, 0),
                sag2.Id));

            jonas.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 7, 12, 30, 0),
                new DateTime(2025, 5, 7, 15, 30, 0),
                sag3.Id));

            
            louise.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 5, 8, 8, 30, 0),
                new DateTime(2025, 5, 8, 12, 0, 0),
                sag1.Id));

           
            malthe.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 8, 0, 0),
                new DateTime(2024, 5, 6, 12, 0, 0),
                null));

            malthe.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 6, 12, 30, 0),
                new DateTime(2024, 5, 6, 15, 0, 0),
                sag9.Id));

            
            frederik.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 9, 9, 0, 0),
                new DateTime(2024, 5, 9, 14, 0, 0),
                sag10.Id));

            frederik.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2024, 5, 10, 9, 0, 0),
                new DateTime(2024, 5, 10, 16, 0, 0),
                sag10.Id));

            emil.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 4, 15, 8, 0, 0),
                new DateTime(2025, 4, 15, 12, 0, 0),
                sag6.Id)); 

            emil.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 4, 16, 9, 0, 0),
                new DateTime(2025, 4, 16, 15, 0, 0),
                sag7.Id)); 

            emil.Tidsregistreringer.Add(new model.Tidsregistrering(
                new DateTime(2025, 4, 18, 8, 30, 0),
                new DateTime(2025, 4, 18, 14, 30, 0),
                sag8.Id)); 


            context.Medarbejdere.AddRange(new[] { kasper, jonas, louise, malthe, frederik, emil, sofie, ida, mads, niels, camilla });

            context.SaveChanges();


        }

    }
}

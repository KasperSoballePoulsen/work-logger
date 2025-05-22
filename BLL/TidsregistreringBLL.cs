using DAL.mappers;
using DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class TidsregistreringBLL
    {

        public static List<DTO.model.Tidsregistrering> GetTidsregistreringer(int medarbejderID)
        {
            List<DTO.model.Tidsregistrering> tidsregistreringerDTO = new List<DTO.model.Tidsregistrering>();

            List<DAL.model.Tidsregistrering> tidsregistreringerDAL = TidsregistreringRepo.GetTidsregistreringer(medarbejderID);

            foreach (var tidsregistrering in tidsregistreringerDAL)
            {
                tidsregistreringerDTO.Add(TidsregistreringMapper.Map(tidsregistrering));
            }

            return tidsregistreringerDTO;
        }


        public static void OpretTidsregistrering(DateTime startTidspunkt, DateTime slutTidspunkt, int? sagsId, int medarbejderId)
        {
            if (startTidspunkt >= slutTidspunkt)
            {
                throw new ArgumentException("Starttidspunkt skal ligge før sluttidspunkt");
            }

            CheckForOverlapPaaTidsregistrering(startTidspunkt, slutTidspunkt, medarbejderId);

            CheckAntalTimerPaaUge(startTidspunkt, slutTidspunkt, medarbejderId);
            
            



            
            TidsregistreringRepo.OpretTidsregistrering(startTidspunkt, slutTidspunkt, sagsId, medarbejderId);
        }

        private static void CheckAntalTimerPaaUge(DateTime startTidspunkt, DateTime slutTidspunkt, int medarbejderId)
        {
            List<DAL.model.Tidsregistrering> tidsregistreringerPaaUge = TidsregistreringRepo.GetTidsregistreringerPaaUge(startTidspunkt, medarbejderId);

            TimeSpan samletTid = TimeSpan.Zero;

            foreach (var t in tidsregistreringerPaaUge)
            {
                samletTid += t.SlutTidspunkt - t.StartTidspunkt;
            }

            TimeSpan nyVarighed = slutTidspunkt - startTidspunkt;
            samletTid += nyVarighed;

            int grænseTimer = 37;
            if (samletTid.TotalHours > grænseTimer)
            {
                TimeSpan overskud = samletTid - TimeSpan.FromHours(grænseTimer);
                string overskudTekst = $"{(int)overskud.TotalHours} timer og {overskud.Minutes} minutter";

                throw new InvalidOperationException(
                    $"Tidsregistreringen vil bringe medarbejderens ugearbejdstid op på {samletTid.TotalHours:F1} timer, hvilket overskrider grænsen på {grænseTimer} timer med {overskudTekst}.");
            }
        }



        private static void CheckForOverlapPaaTidsregistrering(DateTime startTidspunkt, DateTime slutTidspunkt, int medarbejderId)
        {
            List<DAL.model.Tidsregistrering> tidsregistreringerPaaDato = TidsregistreringRepo.GetTidsregistreringerPaaDato(startTidspunkt, medarbejderId);


            foreach (var eksisterendePaaDato in tidsregistreringerPaaDato)
            {
                bool overlapper = startTidspunkt < eksisterendePaaDato.SlutTidspunkt && slutTidspunkt > eksisterendePaaDato.StartTidspunkt;
                if (overlapper)
                {
                    string fejlbesked = $"Tidsregistreringen overlapper med en eksisterende registrering fra {eksisterendePaaDato.StartTidspunkt:HH:mm} til {eksisterendePaaDato.SlutTidspunkt:HH:mm}.";
                    throw new ArgumentException(fejlbesked);
                }
            }

        }

    }
}

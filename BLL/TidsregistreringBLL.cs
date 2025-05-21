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
            TidsregistreringRepo.OpretTidsregistrering(startTidspunkt, slutTidspunkt, sagsId, medarbejderId);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.mappers
{
    public static class TidsregistreringMapper
    {
        //Fra DAL til DTO
        public static DTO.model.Tidsregistrering Map(model.Tidsregistrering tidsregistrering)
        {
            DTO.model.Tidsregistrering tidsregistreringDTO = new DTO.model.Tidsregistrering(tidsregistrering.StartTidspunkt, tidsregistrering.SlutTidspunkt, tidsregistrering.SagsId);
            if (tidsregistrering.Id > 0)
            {
                tidsregistreringDTO.Id = tidsregistrering.Id;
            }
            return tidsregistreringDTO;
            
        }

        //Fra DAL til DTO
        public static model.Tidsregistrering Map(DTO.model.Tidsregistrering tidsregistrering)
        {
            model.Tidsregistrering tidsregistreringDAL = new model.Tidsregistrering(tidsregistrering.StartTidspunkt, tidsregistrering.SlutTidspunkt, tidsregistrering.SagsId);
            if (tidsregistrering.Id > 0)
            {
                tidsregistreringDAL.Id = tidsregistrering.Id;
            }
            return tidsregistreringDAL;

        }
    }
}

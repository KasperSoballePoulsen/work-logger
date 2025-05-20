using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AfdelingBLL
    {
        public static List<DTO.model.Afdeling> GetAfdelinger()
        {
            List<DAL.model.Afdeling> afdelingerDAL = DAL.repositories.AfdelingRepo.GetAfdelinger();
            List<DTO.model.Afdeling> afdelingerDTO = new List<DTO.model.Afdeling>();

            foreach (var afdelingDAL in afdelingerDAL)
            {
                DTO.model.Afdeling afdelingDTO = DAL.mappers.AfdelingMapper.Map(afdelingDAL);
                afdelingerDTO.Add(afdelingDTO);

            }

            return afdelingerDTO;
        }
    }
}

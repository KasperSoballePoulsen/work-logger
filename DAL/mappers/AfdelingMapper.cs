using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.mappers
{
    public static class AfdelingMapper
    {
        //Fra DAL til DTO
        public static DTO.model.Afdeling Map(model.Afdeling afdeling)
        {
            DTO.model.Afdeling afdelingDTO = new DTO.model.Afdeling(afdeling.Navn, afdeling.Nummer);
            if (afdeling.Id > 0)
            {
                afdelingDTO.Id = afdeling.Id;
            }
            return afdelingDTO;
        }

        //Fra DTO til DAL
        public static model.Afdeling Map(DTO.model.Afdeling afdeling)
        {
            model.Afdeling afdelingDAL = new model.Afdeling(afdeling.Navn, afdeling.Nummer);
            if (afdeling.Id > 0)
            {
                afdelingDAL.Id = afdeling.Id;
            }
            return afdelingDAL;
        }
    }
}

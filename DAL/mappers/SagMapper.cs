using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.mappers
{
    public static class SagMapper
    {
        //Fra DAL til DTO
        public static DTO.model.Sag Map(model.Sag sag)
        {
            DTO.model.Sag sagDTO = new DTO.model.Sag(sag.Overskrift, sag.Beskrivelse);
            if (sag.Id > 0)
            {
                sagDTO.Id = sag.Id;
            }
            return sagDTO;
        }

        //Fra DTO til DAL
        public static model.Sag Map(DTO.model.Sag sag)
        {
            model.Sag sagDAL = new model.Sag(sag.Overskrift, sag.Beskrivelse);
            if (sag.Id > 0)
            {
                sagDAL.Id = sag.Id;
            }
            return sagDAL;

        }
    }
}

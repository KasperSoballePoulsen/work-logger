using DAL.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.mappers
{
    public static class MedarbejderMapper
    {
        //Fra DAL til DTO
        /*public static DTO.model.Medarbejder MapWithoutTidsregistreringer(model.Medarbejder medarbejder)
        {
            DTO.model.Medarbejder medarbejderDTO = new DTO.model.Medarbejder(medarbejder.Initialer, medarbejder.CPRNummer, medarbejder.Navn, AfdelingMapper.Map(medarbejder.Afdeling));
            if (medarbejder.Id > 0)
            {
                medarbejderDTO.Id = medarbejder.Id;
            }
            return medarbejderDTO;
        }*


        //Fra DTO til DAL
        /*public static model.Medarbejder MapWithoutTidsregistreringer(DTO.model.Medarbejder medarbejder)
        {
            model.Medarbejder medarbejderDAL = new model.Medarbejder(medarbejder.Initialer, medarbejder.CPRNummer, medarbejder.Navn, AfdelingMapper.Map(medarbejder.Afdeling));
            if (medarbejder.Id > 0)
            {
                medarbejderDAL.Id = medarbejder.Id;
            }
            return medarbejderDAL;
        }*/



        //Fra DAL til DTO
        public static DTO.model.Medarbejder Map(model.Medarbejder medarbejder)
        {
            DTO.model.Medarbejder medarbejderDTO = new DTO.model.Medarbejder(medarbejder.Initialer, medarbejder.CPRNummer, medarbejder.Navn, AfdelingMapper.Map(medarbejder.Afdeling));
            if (medarbejder.Id > 0)
            {
                medarbejderDTO.Id = medarbejder.Id;
            } /*if (medarbejder.Tidsregistreringer.Count() > 0)
            {
                foreach (var tidsregistrering in medarbejder.Tidsregistreringer)
                {
                    medarbejderDTO.Tidsregistreringer.Add(TidsregistreringMapper.Map(tidsregistrering));
                }
            }*/
            return medarbejderDTO;
        }


        //Fra DTO til DAL
        public static model.Medarbejder Map(DTO.model.Medarbejder medarbejder)
        {
            model.Medarbejder medarbejderDAL = new model.Medarbejder(medarbejder.Initialer, medarbejder.CPRNummer, medarbejder.Navn, AfdelingMapper.Map(medarbejder.Afdeling));
            if (medarbejder.Id > 0)
            {
                medarbejderDAL.Id = medarbejder.Id;
            } /*if (medarbejder.Tidsregistreringer.Count() > 0)
            {
                foreach (var tidsregistrering in medarbejder.Tidsregistreringer)
                {
                    medarbejderDAL.Tidsregistreringer.Add(TidsregistreringMapper.Map(tidsregistrering));
                }
            }*/
            return medarbejderDAL;
        }
    }
}

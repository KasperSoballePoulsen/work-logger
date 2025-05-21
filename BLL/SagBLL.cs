using DAL.mappers;
using DAL.repositories;
using DTO.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SagBLL
    {
        public static List<Sag> GetSagerByAfdelingId(int id)
        {
            List<DAL.model.Sag> sagerDAL = SagRepo.GetSagerByAfdelingId(id);
            List<Sag> sagerDTO = new List<Sag>();
            foreach (var sag in sagerDAL)
            {
                sagerDTO.Add(DAL.mappers.SagMapper.Map(sag));
            }
            return sagerDTO;
        }

        public static string GetSagOverskriftById(int id)
        {
            return SagRepo.GetSagOverskriftById(id);
        }

        public static void OpdaterSag(string updatedOverskrift, string updatedBeskrivelse, int sagId)
        {
            if (updatedOverskrift.Length == 0 || updatedBeskrivelse.Length == 0)
            {
                throw new ArgumentException("Ingen felter må være tomme");

            }

            SagRepo.OpdaterSag(updatedOverskrift, updatedBeskrivelse, sagId);

        }

        public static void OpretSag(string overskrift, string beskrivelse, DTO.model.Afdeling afdeling)
        {
            string overskriftToRegister = overskrift.Trim().ToUpper();
            string beskrivelseToRegister = beskrivelse.Trim();

            if (overskriftToRegister.Length == 0)
            {
                throw new ArgumentException("Overskrift skal skrives");

            }
            else if (beskrivelseToRegister.Length == 0)
            {
                throw new ArgumentException("Beskrivelse skal skrives");
            }
            
            else if (afdeling == null)
            {
                throw new ArgumentException("En afdeling skal vælges");
            }
            else
            {
                DTO.model.Sag sagDTO = new DTO.model.Sag(overskrift, beskrivelse);
                DAL.model.Sag sagDAL = SagMapper.Map(sagDTO);
                SagRepo.AddSag(sagDAL, afdeling.Id);
            }
        }
    }
}

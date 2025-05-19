using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {
        public static List<DTO.model.Medarbejder> GetMedarbejdere()
        {
            List<DAL.model.Medarbejder> medarbejdereDAL = DAL.repositories.MedarbejderRepo.GetMedarbejdere();
            List<DTO.model.Medarbejder> medarbejdereDTO = new List<DTO.model.Medarbejder>();

            foreach (var medarbejderDAL in medarbejdereDAL)
            {
                DTO.model.Medarbejder medarbejderDTO = DAL.mappers.MedarbejderMapper.Map(medarbejderDAL);
                medarbejdereDTO.Add(medarbejderDTO);
               
            }

            return medarbejdereDTO;
        }
    }
}

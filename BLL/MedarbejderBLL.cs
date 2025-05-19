using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {
        public static Dictionary<DTO.model.Medarbejder, string> GetMedarbejderVisningsMap()
        {
            List<DAL.model.Medarbejder> medarbejdereDAL = DAL.repositories.MedarbejderRepo.GetMedarbejdere();
            Dictionary<DTO.model.Medarbejder, string> medarbejdereMap = new Dictionary<DTO.model.Medarbejder, string>();

            foreach (var medarbejderDAL in medarbejdereDAL)
            {
                DTO.model.Medarbejder medarbejderDTO = DAL.mappers.MedarbejderMapper.Map(medarbejderDAL);
                medarbejdereMap.Add(medarbejderDTO, medarbejderDTO.Initialer + medarbejderDTO.Id);
            }

            return medarbejdereMap;
        }
    }
}

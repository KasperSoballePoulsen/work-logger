using DAL.repositories;
using DTO.model;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}

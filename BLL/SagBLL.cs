using DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public static class SagBLL
    {
        public static string GetSagOverskriftById(int id)
        {
            return SagRepo.GetSagOverskriftById(id);
        }
    }
}

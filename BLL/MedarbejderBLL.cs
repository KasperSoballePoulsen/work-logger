using DAL.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {
        public static void GetMedarbejdere()
        {
            MedarbejderRepo.GetMedarbejdere();   
        }
    }
}

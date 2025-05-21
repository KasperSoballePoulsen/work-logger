using DAL.mappers;
using DAL.repositories;
using DTO.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class MedarbejderBLL
    {
        public static List<DTO.model.Medarbejder> GetMedarbejdere()
        {
            List<DAL.model.Medarbejder> medarbejdereDAL = DAL.repositories.MedarbejderRepo.GetMedarbejdereWithoutTidsregistreringer();
            List<DTO.model.Medarbejder> medarbejdereDTO = new List<DTO.model.Medarbejder>();

            foreach (var medarbejderDAL in medarbejdereDAL)
            {
                DTO.model.Medarbejder medarbejderDTO = DAL.mappers.MedarbejderMapper.Map(medarbejderDAL);
                medarbejdereDTO.Add(medarbejderDTO);
               
            }

            return medarbejdereDTO;
        }

        public static void OpretMedarbejder(string initialer, string navn, string cpr, Afdeling valgtAfdeling)
        {
            string initialerToRegister = initialer.Trim().ToUpper();
            string cprToRegister = cpr.Trim();
            string navnToRegister = navn.Trim();
            
            if (initialerToRegister.Length == 0 || !isUnikkeInitialer(initialerToRegister))
            {
                throw new ArgumentException("Initialer skal være en unik kombination af bogstaver");

            } else if (navnToRegister.Length == 0)
            {
                throw new ArgumentException("Navn skal udfyldes");
            } else if (!IsGyldigtCprFormat(cprToRegister))
            {
                throw new ArgumentException("CPR-nummer skal skrives på formatet DDMMYY-XXXX");
            } else if (valgtAfdeling == null)
            {
                throw new ArgumentException("En afdeling skal vælges");
            } else
            {
                DTO.model.Medarbejder medarbejderDTO = new DTO.model.Medarbejder(initialerToRegister, cprToRegister, navnToRegister, valgtAfdeling);
                DAL.model.Medarbejder medarbejderDAL = MedarbejderMapper.Map(medarbejderDTO);
                MedarbejderRepo.AddMedarbejder(medarbejderDAL);
            }
        }



        private static bool isUnikkeInitialer(string initialerToCheck)
        {
            List<string> medarbejderInitialer = MedarbejderRepo.GetMedarbejderInitialer();
            bool exists = medarbejderInitialer.Any(initialer => initialer == initialerToCheck);
            return !exists;
        }

        private static bool IsGyldigtCprFormat(string cprToCheck)
        {
            
            return Regex.IsMatch(cprToCheck, @"^\d{6}-\d{4}$");
        }

        public static List<DTO.model.Medarbejder> GetMedarbejdereFraAfdeling(int afdelingId)
        {
            List<DAL.model.Medarbejder> medarbejdereDAL = DAL.repositories.MedarbejderRepo.GetMedarbejdereFraAfdeling(afdelingId);
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

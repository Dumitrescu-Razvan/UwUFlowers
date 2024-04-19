using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    internal class PremiumUsersService
    {
        public PremiumUsersRepo PremiumUsersRepo { get; set; }

        public PremiumUsersService()
        {
            PremiumUsersRepo = new PremiumUsersRepo();
        }

        public List<int> GetPremiumUsers()
        {
            return PremiumUsersRepo.GetAll();
        }

        public bool IsPremiumUser(int userId)
        {
            return this.PremiumUsersRepo.GetAll().Contains(userId);
        }

        public void AddPremiumUser(int userId)
        {
            this.PremiumUsersRepo.Add(userId);
        }
    }
}

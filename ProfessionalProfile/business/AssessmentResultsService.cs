using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    internal class AssessmentResultsService
    {
        private AssessmentResultRepo AssessmentResultRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }

        public AssessmentResultsService()
        {
            AssessmentResultRepo = new AssessmentResultRepo();
            AssessmentTestRepo = new AssessmentTestRepo();
        }

        public List<AssessmentResult> GetResultsByUserId(int userId)
        {
            return this.AssessmentResultRepo.GetAssessmentResultsByUserId(userId);
        }

        public AssessmentTest GetTestById(int testId)
        {
            return this.AssessmentTestRepo.GetById(testId);
        }
    }
}

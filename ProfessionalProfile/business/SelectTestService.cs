using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;

namespace ProfessionalProfile.Business
{
    public class SelectTestService
    {
        private AnswerRepo AnswerRepo { get; }
        private QuestionRepo QuestionRepo { get; }
        private AssessmentTestRepo AssessmentTestRepo { get; }
        private SkillRepo SkillRepo { get; }

        public SelectTestService()
        {
            this.AssessmentTestRepo = new AssessmentTestRepo();
            this.QuestionRepo = new QuestionRepo();
            this.AnswerRepo = new AnswerRepo();
            this.SkillRepo = new SkillRepo();
        }

        public List<AssessmentTest> GetAllAssessmentTests()
        {
            return AssessmentTestRepo.GetAll();
        }

        public AssessmentTest GetAssessmentByName(string testName)
        {
            int id = AssessmentTestRepo.GetIdByName(testName);
            return AssessmentTestRepo.GetById(id);
        }

        public Skill GetSkillById(int id)
        {
            return SkillRepo.GetById(id);
        }
    }
}

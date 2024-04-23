using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.Business;
using TestProject.Mocks;


namespace TestProject.Tests
{
    public class TakeTestServiceTest
    {
        [Fact]
        public void TestConstructorAssignsRepositories()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            // Act
            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Assert
            Assert.NotNull(takeTestService);

        }

        [Fact]
        public void TestGetQuestionsDTOsReturnsListOfQuestionDTOs()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }

        [Fact]
        public void TestGetQuestionsDTOsReturnsListOfQuestionDTOsForGivenAssessmentId()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestGetQuestionDTOsReturnsAssessmentTestDTO()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestGetQuestionDTOsReturnsListOfQuestionDTOsForGivenAssessmentId()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.IsType<List<QuestionDTO>>(result);
        }
        [Fact]
        public void TestComputeTestResultReturnsInt()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            var assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", new List<QuestionDTO>(), "Python");
            var strings = new List<string> { "Python", "C++" };

            // Act
            var result = takeTestService.ComputeTestResult(assessmentTestDTO, strings);
            Assert.IsType<int>(result);

        }

        [Fact]
        public void TestComputeTestResultReturnsIntForGivenAssessmentTestDTOAndListOfStrings()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            var assessmentTestDTO = new AssessmentTestDTO("TestName", "Description", new List<QuestionDTO>(), "Python");
            var strings = new List<string> { "Python", "C++" };

            // Act
            var result = takeTestService.ComputeTestResult(assessmentTestDTO, strings);
            Assert.IsType<int>(result);

        }

        [Fact]
        public void AddTestResultAddsAssessmentResultToRepo()
        {
            // Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            // Act
            takeTestService.AddTestResult(1, 1, 100, DateTime.Now);

            // Assert
            Assert.Equal(1, AssessmentResultRepoMock.GetAll().Count);
        }
    }
}

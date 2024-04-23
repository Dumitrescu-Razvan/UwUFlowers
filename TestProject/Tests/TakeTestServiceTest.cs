using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.Repo;
using ProfessionalProfile.Business;
using TestProject.Mocks;
using System.Security.RightsManagement;


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
        public void TestGetQuestionDTOsCreateAnswerDTOsReturnsListOfCorrectAnswers()
        {
            //Arrange
            var AnswerRepoMock = new AnswerRepoMock();
            var QuestionRepoMock = new QuestionRepoMock();
            var AssessmentTestRepoMock = new AssessmentTestRepoMock();
            var SkillRepoMock = new SkillRepoMock();
            var AssessmentResultRepoMock = new AssessmentResultRepoMock();

            var takeTestService = new TakeTestService(AnswerRepoMock, QuestionRepoMock, AssessmentTestRepoMock, SkillRepoMock, AssessmentResultRepoMock);

            //create questions
            var question1 = new Question(1, "Question1", 1);
            var question2 = new Question(2, "Question2", 1);
            var question3 = new Question(3, "Question3", 1);
            var question4 = new Question(4, "Question4", 2);

            //create answers
            var answer1 = new Answer(1, "1", 1, true);
            var answer2 = new Answer(2, "1", 1, false);
            var answer3 = new Answer(3, "1", 1, true);
            var answer4 = new Answer(4, "2", 2, true);
            var answer5 = new Answer(5, "2", 2, false);
            var answer6 = new Answer(6, "2", 2, true);

            //add questions to repo
            QuestionRepoMock.Add(question1);
            QuestionRepoMock.Add(question2);
            QuestionRepoMock.Add(question3);
            QuestionRepoMock.Add(question4);


            //add answers to repo
            AnswerRepoMock.Add(answer1);
            AnswerRepoMock.Add(answer2);
            AnswerRepoMock.Add(answer3);
            AnswerRepoMock.Add(answer4);
            AnswerRepoMock.Add(answer5);
            AnswerRepoMock.Add(answer6);

            // Act
            var result = takeTestService.GetQuestionDTOs(1);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(3, result[0].Answers.Count);
            Assert.Equal(3, result[1].Answers.Count);



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
        public void TestComputeTestResultWithoutEmptyStringsReturnsIntForGivenAssessmentTestDTOAndListOfStrings()
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

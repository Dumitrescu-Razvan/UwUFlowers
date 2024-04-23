﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;
using ProfessionalProfile.RepoInterfaces;

namespace ProfessionalProfile.Repo
{
    public class QuestionRepo : IQuestionRepoInterface<Question>
    {
        private string connectionString;

        public QuestionRepo(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public QuestionRepo()
        {
            connectionString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        }

        public void Add(Question item)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"INSERT INTO Questions (QuestionText, AssessmentTestId) 
                       VALUES (@QuestionText, @AssessmentTestId)";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@QuestionText", item.QuestionText);
                command.Parameters.AddWithValue("@AssessmentTestId", item.AssesmentTestId);

                command.ExecuteNonQuery();
            }
        }

        public int GetIdByNameAndAssessmentId(string questionName, int assessmentId)
        {
            int questionId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT QuestionId FROM Questions WHERE QuestionText = @QuestionText AND AssessmentTestId = @AssessmentId";

                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@QuestionText", questionName);
                command.Parameters.AddWithValue("@AssessmentId", assessmentId);

                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                {
                    questionId = Convert.ToInt32(result);
                }
            }

            return questionId;
        }

        public void Delete(int id)
        {
        }

        public List<Question> GetAllByTestId(int testID)
        {
            List<Question> questions = new List<Question>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sql = "SELECT * FROM Questions WHERE AssessmentTestId = @TestId";
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@TestId", testID);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int questionId = (int)reader["QuestionId"];
                        string questionText = (string)reader["QuestionText"];
                        int testId = (int)reader["AssessmentTestId"];
                        // You may need to retrieve other properties depending on your schema
                        Question question = new Question(questionId, questionText, testId);

                        questions.Add(question);
                    }
                }
            }

            return questions;
        }

        public List<Question> GetAll()
        {
            throw new NotImplementedException();
        }

        public Question GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Question item)
        {
        }
    }
}

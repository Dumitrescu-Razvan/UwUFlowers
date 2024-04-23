﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProfessionalProfile.Domain;

namespace ProfessionalProfile.Repo
{
    internal class AssessmentResultRepo : IRepoInterface<AssessmentResult>
    {
        private List<AssessmentResult> assessmentResults;
        public AssessmentResultRepo()
        {
            assessmentResults = new List<AssessmentResult>();
        }

        public void Add(AssessmentResult item)
        {
            assessmentResults.Add(item);
        }

        public void Delete(int id)
        {
        }

        public List<AssessmentResult> GetAll()
        {
            return assessmentResults;
        }

        public List<AssessmentResult> GetAssessmentResultsByUserId(int userId)
        {
            List<AssessmentResult> allResults = this.GetAll();
            return allResults.FindAll(result => result.UserId == userId);
        }

        public AssessmentResult GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(AssessmentResult item)
        {
        }
    }
}
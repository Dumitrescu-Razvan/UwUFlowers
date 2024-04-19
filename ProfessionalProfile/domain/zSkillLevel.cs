using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalProfile.Domain
{
    // NOT USED
    public class SkillLevel
    {
        private int skillLevelId;
        private string level; // beginner, intermediate, advanced

        public SkillLevel(int skillLevelId, string level)
        {
            this.skillLevelId = skillLevelId;
            this.level = level;
        }

        public int SkillLevelId
        {
            get { return this.skillLevelId; }
            set { this.skillLevelId = value; }
        }

        public string Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
    }
}

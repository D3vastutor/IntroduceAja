using System;
using System.Collections.Generic;
using System.Text;

namespace IntroduceAja.Models.Requests
{
    public class EnrollMemberRequest
    {
        public string CodeName { get; set; }
        public string Skill { get; set; }
        public int? SkillLevel { get; set; }

    }
}

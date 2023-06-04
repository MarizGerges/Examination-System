using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02__Examination_system_
{
     class Answers
    {
        public int AnswerID { get; set; }
        public string AnswerText { get;set; }

        public override string ToString()
        {
            return $"{AnswerID} - {AnswerText}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02__Examination_system_
{
    abstract class Question
    {
        public string Question_Header;
        public string[] Question_Body;
        public decimal Question_Mark;
        public Answers[] answerList;

        public void setQuestion_Header()
        {
            Console.Write("please enter the header of the question : ");
            Question_Header = Console.ReadLine();
        }
        public void setQuestion_Mark()
        {
            bool flag;
            do
            {
                Console.Write("please enter the mark of the question : ");
                flag = decimal.TryParse(Console.ReadLine(), out Question_Mark);
            } while (!flag);
        }
        public abstract void setQuestion_body();

        public string getQuestion_Header()
        {
            return Question_Header;
        }
        public decimal getQuestion_Mark()
        {
            return Question_Mark;
        }

        public abstract string[] getQuestion_body();

        public abstract void setAnswer();
        public abstract Answers[] GetAnswers();
    }
    class TrueOrFalse : Question
    {
        public override void setQuestion_body()
        {
            string[] Qbody = new string[2];
            Qbody[0] = "true";
            Qbody[1] = "false";
            Question_Body = Qbody;
        }

        public override void setAnswer()
        {
            bool flag;
            int result;
            string userAnswer = "";
            do
            {
                Console.Write("please enter the right answer 1 for true | 2 for false :");
                flag = int.TryParse(Console.ReadLine(), out result);
                if (result == 1)
                    userAnswer= "true";
                else if (result == 2)
                    userAnswer = "false";
                else
                    flag= false;
            } while (!flag);
            Answers current =new Answers { AnswerText= userAnswer };
            List<Answers> NewAnswerList = new List<Answers>();
            NewAnswerList.Add(current);
            answerList= NewAnswerList.ToArray<Answers>();

        }

        public override Answers[] GetAnswers()
        {
            return answerList;
        }
        public override string[] getQuestion_body()
        {
            return Question_Body;
        }
      
    }



    
    class MCQ : Question
    {

        public override void setQuestion_body()
    {
            string[] answers2 = new string[3];
            Console.Write("please enter the choice number 1 :");
            answers2[0] = Console.ReadLine();
            Console.Write("please enter the choice number 2 :");
            answers2[1] = Console.ReadLine();
            Console.Write("please enter the choice number 3 :");
            answers2[2] = Console.ReadLine();
            Question_Body = answers2;
    }
        public override string[] getQuestion_body()
        {
            return Question_Body;
        }
       
        public override void setAnswer()
        {
            bool flag;
            int result;
            string userAnswer = "";
            do
            {
                string[] QAnswers = getQuestion_body();
                for (int i = 0; i < QAnswers.Length; i++)
                {
                    Console.WriteLine($"{i + 1}- {QAnswers[i]}");

                }
                Console.Write("please enter the number of the correct answer :");
                flag = int.TryParse(Console.ReadLine(), out result);
                if (result == 1)
                    userAnswer = QAnswers[0];
                else if (result == 2)
                    userAnswer = QAnswers[1];
                else if (result == 3)
                    userAnswer = QAnswers[2];
                else
                    flag = false;
            } while (!flag);
            Answers current = new Answers { AnswerText = userAnswer };
            List<Answers> NewAnswerList = new List<Answers>();
            NewAnswerList.Add(current);
            answerList = NewAnswerList.ToArray<Answers>();

        }

        public override Answers[] GetAnswers()
        {
            return answerList;
        }



    }
}


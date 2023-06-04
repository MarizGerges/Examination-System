using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02__Examination_system_
{
   class Exam
    {
        public int timeOfExam;
        public int numOfQuestions;
        public int getTimeOfExam()
        {
            return timeOfExam;
        }
        public void setTimeOfExam()
        {
            bool flag;
            do
            {
                Console.WriteLine("enter time of exam in minuets");
                flag = int.TryParse(Console.ReadLine(), out timeOfExam);
            } while (!flag);
        }
        public int getnumberOfQuestions()
        {
            return numOfQuestions;
        }
        public void setnumberOfQuestions()
        {
            bool flag;
            do
            {
                Console.WriteLine("enter number of question ");
                flag = int.TryParse(Console.ReadLine(), out numOfQuestions);
            } while (!flag);
        }
        #region
        public void showExam(Question[] MyQuestions)
        {

            Answers[] userAnswers=new Answers[MyQuestions.Length];
            Answers[] RightAnswers = new Answers[MyQuestions.Length];
            List<Answers> NewAnswerList = new List<Answers>();
            decimal[] Qmark = new decimal [MyQuestions.Length];
            decimal count = 0m;
            for (int i = 0; i < MyQuestions.Length; i++)
            {
                string userAnswer = "";
                Console.WriteLine(MyQuestions[i].getQuestion_Header());
                string[] Qanswers = MyQuestions[i].getQuestion_body();
                if (Qanswers.Length == 2)
                {
                    int result;
                    bool flag;
                    do
                    {
                        Console.Write("please enter 1 for true | 2 for false :");
                        flag = int.TryParse(Console.ReadLine(), out result);
                        if (result == 1)
                            userAnswer = "true";
                        else if (result == 2)
                            userAnswer = "false";
                        else
                            flag = false;
                        Answers current = new Answers {AnswerID=i+1, AnswerText = userAnswer };
                        NewAnswerList.Add(current);
                        userAnswers= NewAnswerList.ToArray<Answers>();
                    } while (!flag);
                }
                else if (Qanswers.Length == 3)
                {
                    int result;
                    bool flag;
                    Console.WriteLine("Question_body:");
                    for (int j = 0; j < Qanswers.Length; j++)
                    {
                        Console.WriteLine($"{j + 1}-{Qanswers[j]}");
                    }
                    do
                    {
                        Console.Write("please enter the number of the correct answer:");
                        flag = int.TryParse(Console.ReadLine(), out result);
                        if (result == 1)
                            userAnswer = Qanswers[0];
                        else if (result == 2)
                            userAnswer = Qanswers[1];
                        else if (result == 3)
                            userAnswer = Qanswers[2];
                        else
                            flag = false;
                        Answers current = new Answers { AnswerID = i + 1, AnswerText = userAnswer };
                        NewAnswerList.Add(current);
                        userAnswers = NewAnswerList.ToArray<Answers>();
                    } while (!flag);
                }
                Console.WriteLine("=======================================");
                Qmark[i]= MyQuestions[i].getQuestion_Mark();
            }
            string answerText = "";
            List<Answers> RightAnswersList = new List<Answers>();
            for (int i = 0; i < MyQuestions.Length; i++)
            {
                answerText = MyQuestions[i].GetAnswers()[0].AnswerText;
                Answers current = new Answers { AnswerID = i + 1, AnswerText = answerText };
                RightAnswersList.Add(current);
                RightAnswers = RightAnswersList.ToArray<Answers>();

            }
            for (int i = 0; i < userAnswers.Length; i++)
                {
                    for (int j = 0; j < RightAnswers.Length; j++)
                    {
                        if (userAnswers[i].AnswerID == RightAnswers[j].AnswerID && userAnswers[i].AnswerText == RightAnswers[j].AnswerText)
                        {
                            count +=Qmark[i] ;
                        }
                    }
                }
            Console.WriteLine($"student grade = {count}");

        }
        #endregion
    }
    class Final:Exam
    {
        public void finalExam()
        {
            bool flag;
            setTimeOfExam();
            setnumberOfQuestions();
            int Qnum=getnumberOfQuestions();
            Question[] MyQuestions = new Question[Qnum];
            string answerText = "";
            List<Answers> RightAnswersList = new List<Answers>();
            Answers[] RightAnswers = new Answers[Qnum];
            for (int i = 0; i < Qnum; i++)
            {
                int Qtype;
                do
                {
                    Console.WriteLine("choose type of question 1 for true or false | 2 for MCQ");
                    flag = int.TryParse(Console.ReadLine(), out Qtype);

                } while (!flag);

                if (Qtype == 1)
                {
                    TrueOrFalse trueOrFalseQuestion = new TrueOrFalse();
                    trueOrFalseQuestion.setQuestion_Header();
                    trueOrFalseQuestion.setQuestion_body();
                    trueOrFalseQuestion.setAnswer();
                    trueOrFalseQuestion.setQuestion_Mark();
                    MyQuestions[i] = trueOrFalseQuestion;
                }
                else if (Qtype == 2)
                {
                    MCQ MCQ = new MCQ();
                    MCQ.setQuestion_Header();
                    MCQ.setQuestion_body();
                    MCQ.setAnswer();
                    MCQ.setQuestion_Mark();
                    MyQuestions[i] = MCQ;
                }
            }
            Console.WriteLine("do you want start exam y|n");
            char x;
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Console.Clear();

                showExam(MyQuestions);
                for (int i = 0; i < MyQuestions.Length; i++)
                {
                    answerText = MyQuestions[i].GetAnswers()[0].AnswerText;
                    Answers current = new Answers { AnswerID = i + 1, AnswerText = answerText };
                    RightAnswersList.Add(current);
                    RightAnswers = RightAnswersList.ToArray<Answers>();
                }
                Console.WriteLine("Questions with right answer");
                for (int i = 0; i < Qnum; i++)
                {
                    Console.WriteLine($"{MyQuestions[i].getQuestion_Header()} :: {RightAnswers[i].AnswerText}");

                }

            }
        }
    }
    class practical : Exam
    {
        public void practicalExam()
        {
            setTimeOfExam();
            setnumberOfQuestions();
            int Qnum = getnumberOfQuestions();
            Question[] MyQuestions = new Question[Qnum];
            Answers[] RightAnswers = new Answers[Qnum];
            MCQ MCQ = new MCQ();
            string answerText = "";
            List<Answers> RightAnswersList = new List<Answers>();
            for (int i = 0; i < Qnum; i++)
            {
                MCQ = new MCQ();
                MCQ.setQuestion_Header();
                MCQ.setQuestion_body();
                MCQ.setAnswer();
                MCQ.setQuestion_Mark();
                MyQuestions[i] = MCQ;
            }
            Console.WriteLine("do you want start exam y|n");
            char x;
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Console.Clear();
                showExam(MyQuestions);
                Console.WriteLine("the right answers ::: ");
                for (int i = 0; i < MyQuestions.Length; i++)
                {
                    answerText = MyQuestions[i].GetAnswers()[0].AnswerText;
                    Answers current = new Answers { AnswerID = i + 1, AnswerText = answerText };
                    RightAnswersList.Add(current);
                    RightAnswers = RightAnswersList.ToArray<Answers>();

                }
                foreach (var item in RightAnswers)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

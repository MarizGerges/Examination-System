using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam02__Examination_system_
{
    internal class Subject
    {
        public int Subject_Id { get; set; }
        public string Subject_Name { get; set; }
        public Subject(int id , string name)
        {
            Subject_Id = id;
            Subject_Name = name;
        }
        
        public void create_exam() 
        {
            bool flag;
            int examType;
            do
            {
                Console.WriteLine("enter type of the exam 1 for practical  | 2 for final ");
                flag = int.TryParse(Console.ReadLine(), out examType);
            }while( !flag);

            if (examType==1)
            {
                practical practical = new practical();
                practical.practicalExam();
            }
            else if (examType==2)
            {
                Final final = new Final();
                final.finalExam();
            }
            


        }

    }


}

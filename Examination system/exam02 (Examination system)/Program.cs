using System.Diagnostics;

namespace exam02__Examination_system_
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Subject s1 = new Subject(10, "c#");

            var timer = new Stopwatch();
            timer.Start();
            s1.create_exam();
            timer.Stop();
            TimeSpan timeTaken = timer.Elapsed;
            Console.WriteLine($"the elapsed time = {timeTaken}");
        }
    }
}
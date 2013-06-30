using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chain_of_responsibility
{
    public class Problem
    {
        public ResponsiableLevel Level { get; set; }
        public string Description { get; set; }
    }

    //Enum  for  level
    public enum ResponsiableLevel
    {
        Low,
        High
    }
    public abstract class Staff
    {
        public string Name { get; set; }
        public Staff Boss { get; set; }
        public abstract void ProcessProblem(Problem problem);
    }
    public class Developer : Staff
    {
        public override void ProcessProblem(Problem problem)
        {
            if (problem.Level != ResponsiableLevel.Low)
            {
                Console.WriteLine("This is {0}. I am a Developer of this Company.I am not able to solve your problem. " +
                   "Our Team Lead {1} will review your problem", this.Name, Boss.Name);
                Console.WriteLine();
                Boss.ProcessProblem(problem);
            }
            else
            {
                Console.WriteLine("This is {0}. I am a developer of this Company. Your problem has been solved!", this.Name);
                Console.WriteLine();
            }
        }
    }
    public class TeamLead : Staff
    {
        public override void ProcessProblem(Problem problem)
        {
            Console.WriteLine("This is {0}. I am a Team Lead of this Company. Your problem has been solved!", this.Name);
            Console.WriteLine();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //create a developer
            Developer developer = new Developer();
            developer.Name = "John";

            //create a TeamLead
            TeamLead teamLead = new TeamLead();
            teamLead.Name = "Jack";

            //This is Resposiable Chain
            developer.Boss = teamLead;

            //create a problem that can be handled by developer.
            Problem Problemfirst = new Problem();
            Problemfirst.Description = "Here must be problem  that  can solve a developer";
            Problemfirst.Level = ResponsiableLevel.Low;
            Console.WriteLine("Problem Info: " + Problemfirst.Description);
            Console.WriteLine();
            //send problem
            developer.ProcessProblem(Problemfirst);
            Console.WriteLine();

            //create a problem that can be handled by TeamLead.
            Problem Problemsecond = new Problem();
            Problemsecond.Description = "Here must be problem  that  can solve a TeamLead";
            Problemsecond.Level = ResponsiableLevel.High;
            Console.WriteLine("Request Info: " + Problemsecond.Description);
            Console.WriteLine();
            //send problem
            developer.ProcessProblem(Problemsecond);
        }
    }
}

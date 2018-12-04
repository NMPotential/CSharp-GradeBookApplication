using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook //Add colon to inheret BaseGradeBook class
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted) //Creates call to base constructor
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) // Needs a min. of 5 students
                throw new InvalidOperationException("Ranked grading needs at least 5 students.");

            var threshold = (int)Math.Ceiling(Students.Count * 0.2); // This gives us 20% of total number of students
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if (grades[threshold - 1] <= averageGrade)
                return 'A';
            else if (grades[(threshold * 2) - 1] <= averageGrade)
                return 'B';
            else if (grades[(threshold * 3) - 1] <= averageGrade)
                return 'C';
            else if (grades[(threshold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return; //Step back out of method in the event there were <5 students
            }

            base.CalculateStatistics(); // If there were > 5 students call un-overrided method
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }

            base.CalculateStudentStatistics(name);
        }

    }
}

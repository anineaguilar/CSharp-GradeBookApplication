using System;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
            {
                int studentsRank = Convert.ToInt32(Students.Count * 0.2) - 1;
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if (grades.IndexOf(averageGrade) <= studentsRank)
                    return 'A';
                else if (grades.IndexOf(averageGrade) <= (studentsRank * 2))
                    return 'B';
                else if (grades.IndexOf(averageGrade) <= (studentsRank * 3))
                    return 'C';
                else if (grades.IndexOf(averageGrade) <= (studentsRank * 4))
                    return 'D';
            }
            return 'F';
        }
    }
}
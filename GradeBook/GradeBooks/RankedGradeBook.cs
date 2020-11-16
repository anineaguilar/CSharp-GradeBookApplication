using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
            {
                int studentsRank = Convert.ToInt32(Students.Count / 5) -1;
                List<Double> grades = new List<Double>();

                foreach(var student in Students)
                {
                    grades.Add(Convert.ToDouble(student.Grades));
                }

                grades.Sort();

                if (grades.IndexOf(averageGrade) <= studentsRank)
                    return 'A';
                else if (grades.IndexOf(averageGrade) <= (studentsRank * 2))
                    return 'B';
                else if (grades.IndexOf(averageGrade) <= (studentsRank * 3))
                    return 'C';
                else
                    return 'D';
            }
              
            return 'F';
            
            

        }
    }
}

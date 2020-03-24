using System;
using System.Linq;
using GradeBook.Enums;

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
            var studentCount = Students.Count;

            if (studentCount < 5)
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");

            var gradeThreshhold = (int)Math.Ceiling(studentCount * 0.2);
            var gradeOrder = Students.OrderByDecending(e => e.AverageGrade).ToList();

            if (gradeOrder[gradeThreshhold - 1] <= averageGrade)
                return 'A';

            else if (gradeOrder[(gradeThreshhold * 2) - 1] <= averageGrade)
                return 'B';

            else if (gradeOrder[(gradeThreshhold * 3) - 1] <= averageGrade)
                return 'C';

            else if (gradeOrder[(gradeThreshhold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
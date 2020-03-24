using System;
using System.Collections.Generic;
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

            var gradeOrder = from s in Students
                                orderby s.AverageGrade descending
                                select s;

            var gradeOrderList = gradeOrder.ToList();

            if (gradeOrderList[gradeThreshhold - 1] <= averageGrade)
                return 'A';
            else if (gradeOrderList[(gradeThreshhold * 2) - 1] <= averageGrade)
                return 'B';
            else if (gradeOrderList[(gradeThreshhold * 3) - 1] <= averageGrade)
                return 'C';
            else if (gradeOrderList[(gradeThreshhold * 4) - 1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
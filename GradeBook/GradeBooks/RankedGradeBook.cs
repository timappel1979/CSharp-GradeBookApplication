using System;
using System.Linq;
using GradeBook.Enums;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            List<Student> students = new List<Student>();

            students = Students;

            var studentCount = students.Count;

            if (studentCount < 5)
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
            {
                var gradeThreshold = (int)Math.Ceiling(studentCount * 0.2);
                var gradeOrder = students.OrderByDecending(e => e.AverageGrade).ToList();

                if (gradeOrder[gradeThreshold - 1].AverageGrade <= averageGrade)
                    return 'A';
                else if (gradeOrder[(gradeThreshold * 2) - 1].AverageGrade <= averageGrade)
                    return 'B';
                else if (gradeOrder[(gradeThreshold * 3) - 1].AverageGrade <= averageGrade)
                    return 'C';
                else if (gradeOrder[(gradeThreshold * 4) - 1].AverageGrade <= averageGrade)
                    return 'D';
                else
                    return 'F';
            }
        }
    }
}
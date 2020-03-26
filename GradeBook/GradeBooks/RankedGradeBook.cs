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

            var studentCount = students.Count;
            var gradeThreshhold = (int)Math.Ceiling(studentCount * 0.2);
            var gradeOrder = students.OrderBy(e => e.AverageGrade).ToList();


            if (studentCount < 5)
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");


            else if (gradeOrder[gradeThreshhold - 1].AverageGrade <= averageGrade)
                return 'A';
            else if (gradeOrder[(gradeThreshhold * 2) - 1].AverageGrade <= averageGrade)
                return 'B';
            else if (gradeOrder[(gradeThreshhold * 3) - 1].AverageGrade <= averageGrade)
                return 'C';
            else if (gradeOrder[(gradeThreshhold * 4) - 1].AverageGrade <= averageGrade)
                return 'D';
            else
                return 'F';
        }
    }
}
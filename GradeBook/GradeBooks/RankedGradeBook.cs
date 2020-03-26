﻿using System;
using System.Linq;
using System.Collections.Generic;
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
            if (Students.Count < 5)
                throw new System.InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            else
            {
                var threshold = (int)Math.Ceiling(Students.Count * 2);
                var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

                if (averageGrade >= grades[threshold - 1])
                    return "A";



                else
                    return "F";
            }

        }
    }
}
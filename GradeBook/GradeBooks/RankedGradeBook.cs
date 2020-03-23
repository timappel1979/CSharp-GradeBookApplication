using System;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(BaseGradeBook)
        {
            Type = GradeBookType.Ranked;
        }
    }
}
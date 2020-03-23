using System;
using GradeBook.GradeBooks;

public class StandardGradeBook
{
    public StandardGradeBook(string name) : base(BaseGradeBook)
    {
        Type = GradeBookType.Standard;
    }
}

using System;
using GradeBook.GradeBooks;

public class StandardGradeBook
{
    public StandardGradeBook(string name) : base(name)
    {
        Type = GradeBookType.Standard;
    }
}

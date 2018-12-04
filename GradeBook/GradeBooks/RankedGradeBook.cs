using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook //Add colon to inheret BaseGradeBook class
    {
        public RankedGradeBook(string name) : base(name) //Creates call to base constructor
        {
            Type = GradeBookType.Ranked;
        }
    }
}

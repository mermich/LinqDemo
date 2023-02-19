using LinqDemo.Data;

namespace LinqDemo
{
    public static class OrderDemo
    {
        /// <summary>
        /// Sort a list by a criteria...
        /// </summary>
        /// <returns>See also OrderBy - OrderByDescending</returns>
        public static void SortSudentsByGradeLinq(List<Student> students, int goodGrade = 10)
        {
            students.OrderByDescending(s => s.Grade).ToList().ToConsole();
        }


        public static void FilterAndSortSudentsByGradeLinq(List<Student> students, int goodGrade = 10)
        {
            students.Where(s => s.Grade >= 10)
                .OrderByDescending(s => s.Grade)
                .ToList()
                .ToConsole();
        }
    }
}
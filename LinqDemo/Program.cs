using LinqDemo.Data;
using LinqDemo.Tier1.Tier2;
using LinqDemo.Tier1.Tier2.Tier3;

namespace LinqDemo
{
    internal partial class Program
    {
        private static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Linq Demo");
            Console.ForegroundColor = ConsoleColor.White;

            List<Student> students = DataManager.ReadStudents(DataRefresh.Override);


            #region tier1
            // Methodes Linq a connaitre (par ordre d'importance) :
            // Where
            FilterListDemo.Run(students);
            Console.WriteLine();
            Console.ReadLine();

            // FirstOrDefault - First - SingleOrDefault - Single
            SingleResultDemo.Run(students);
            Console.WriteLine();
            Console.ReadLine();

            #region tier2
            // OrderBy - OrderByDescending
            OrderDemo.SortSudentsByGradeLinq(students);
            Console.WriteLine();
            Console.ReadLine();

            // Count - Any - All
            CountDemo.RunCount(students);
            Console.WriteLine();
            Console.ReadLine();

            #region tier3
            // Select
            SelectDemo.RunGetStudentsNames(students);
            Console.WriteLine();
            Console.ReadLine();

            // GroupBy
            GroupDemo.RunGetStudentsGroups(students);
            Console.WriteLine();
            Console.ReadLine();

            // SelectMany
            SelectManyDemo.RunGetAllAssignements(students);
            Console.WriteLine();
            Console.ReadLine();

            #region tier4
            // Skip - Take
            TakeDemo.RunGetTop5(students);
            Console.WriteLine();
            Console.ReadLine();

            SkipDemo.RunGetSecondTop5(students);
            Console.WriteLine();
            Console.ReadLine();

            #endregion
            #endregion
            #endregion
            #endregion
        }

    }
}
using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2.Tier3
{
    public static class SkipDemo
    {
        public static List<Student> GetSecondTop5(List<Student> students)
        {
            return students.OrderByDescending(s=>s.Grade)
                .Skip(5)
                .Take(5)
                .ToList();
        }


        public static void RunGetSecondTop5(List<Student> students)
        {
            Console.WriteLine("GetSecondTop5...");
            GetSecondTop5(students).ToConsole();
        }
    }
}
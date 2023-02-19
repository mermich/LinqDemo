using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2.Tier3
{
    public static class TakeDemo
    {
        public static List<Student> GetTop5(List<Student> students)
        {
            List<Student> res = new List<Student>();

            List<Student> sorted = students.OrderByDescending(s => s.Grade).ToList();
            for (int i = 0; i < 5; i++)
            {
                res.Add(sorted[i]);
            }
            return res;
        }


        public static List<Student> GetTop5Linq(List<Student> students)
        {
            return students.OrderByDescending(s => s.Grade).Take(5).ToList();
        }


        public static void RunGetTop5(List<Student> students)
        {
            Console.WriteLine("GetTop5...");
            GetTop5(students).ToConsole();

            Console.WriteLine("GetTop5Linq...");
            GetTop5Linq(students).ToConsole();
        }
    }
}
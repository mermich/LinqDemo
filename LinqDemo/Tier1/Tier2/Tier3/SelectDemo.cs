using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2.Tier3
{
    public static class SelectDemo
    {
        public static List<string> GetStudentsNames(List<Student> students)
        {
            List<string> res = new List<string>();

            foreach (Student student in students)
            {
                res.Add($"{student.FirstName}-{student.LastName}");
            }
            return res;
        }


        public static List<string> GetStudentsNamesLinq(List<Student> students)
        {
            return students.Select(s => $"{s.FirstName}-{s.LastName}").ToList();
        }


        public static void RunGetStudentsNames(List<Student> students)
        {
            Console.WriteLine("GetStudentsNames...");
            GetStudentsNames(students).ToConsole();

            Console.WriteLine("CountStudentsThatPassLinq...");
            GetStudentsNamesLinq(students).ToConsole();
        }


        public static void RunGetStudentsNamesWhoPass(List<Student> students, int passGrade = 10)
        {
            Console.WriteLine("RunGetStudentsNamesWhoPass...");
            students.Where(s => s.Grade >= 10)
                .Select(s => $"{s.FirstName}-{s.LastName}")
                .ToList()
                .ToConsole();
        }
    }
}
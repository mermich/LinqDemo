using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2.Tier3
{
    public static class SelectManyDemo
    {
        public static List<Assignement> GetAllAssignements(List<Student> students)
        {
            List<Assignement> res = new List<Assignement>();

            // Style boucle for:
            foreach (Student student in students)
            {
                res.AddRange(student.Assignements);
            }
            return res;
        }


        public static List<Assignement> GetStudentsNamesLinq(List<Student> students)
        {
            return students.SelectMany(s => s.Assignements).ToList();
        }


        public static void RunGetAllAssignements(List<Student> students)
        {
            Console.WriteLine("GetAllAssignements...");
            GetAllAssignements(students).ToConsole();

            Console.WriteLine("GetStudentsNamesLinq...");
            GetStudentsNamesLinq(students).ToConsole();
        }
    }
}
using LinqDemo.Data;

namespace LinqDemo
{
    public static class FilterListDemo
    {
        public static List<Student> FindStudentsWithgoodGrades(List<Student> students, int goodGrade = 10)
        {
            // Style boucle for:
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.Grade >= goodGrade)
                {
                    result.Add(student);
                }
            }

            return result;
        }

        public static List<Student> FindStudentsWithgoodGradesLinq(List<Student> students, int goodGrade = 10)
        {
            return students.Where(s => s.Grade >= goodGrade).ToList();
        }


        public static void Run(List<Student> students, int goodGrade = 10)
        {
            Console.WriteLine("FindStudentsWithgoodGrades...");
            FindStudentsWithgoodGrades(students, goodGrade).ToConsole();

            Console.WriteLine("FindStudentsWithgoodGradesLinq...");
            FindStudentsWithgoodGradesLinq(students, goodGrade).ToConsole();
        }

        public static void RunMultipleWhere(List<Student> students, int passGrade = 10, int goodGrade = 15)
        {
            Console.WriteLine("RunMultipleWhere");
            students
                .Where(s => s.Grade >= passGrade)
                .Where(s => s.Grade <= goodGrade)
                .ToList()
                .ToConsole();
        }
    }
}
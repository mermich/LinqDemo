using LinqDemo.Data;

namespace LinqDemo
{
    public static class SingleResultDemo
    {
        public static Student? FindPerfectStudents(List<Student> students)
        {
            // Style boucle for:
            foreach (Student student in students)
            {
                if (student.Grade == 20)
                {
                    return student;
                }
            }
            return null;
        }

        /// <summary>
        /// First Or Default returns the first element matching the criteria, or the default value of the return type.
        /// If multiple elements match the requirement, the first element is returned.
        /// </summary>
        /// <returns>See also : First, Single, SingleOrDefault</returns>
        public static Student? FindPerfectStudentsLinq(List<Student> students)
        {
            return students.FirstOrDefault(s => s.Grade == 20);
        }

        public static void Run(List<Student> students)
        {
            Console.WriteLine("FindPerfectStudents...");
            FindPerfectStudents(students).ToConsole();

            Console.WriteLine("FindPerfectStudentsLinq...");
            FindPerfectStudentsLinq(students).ToConsole();
        }
    }
}
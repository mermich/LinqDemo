using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2
{
    public static class CountDemo
    {
        #region Count
        public static int CountStudentsThatPass(List<Student> students, int gradeRequired = 10)
        {
            int result = 0;
            // Style boucle for:
            foreach (Student student in students)
            {
                if (student.Grade >= gradeRequired)
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// Count elements matching the criteria.
        /// </summary>
        public static int CountStudentsThatPassLinq(List<Student> students, int gradeRequired = 10)
        {
            return students.Count(s => s.Grade >= gradeRequired);
        }

        public static void RunCount(List<Student> students, int goodGrade = 10)
        {
            Console.WriteLine("CountStudentsThatPass...");
            CountStudentsThatPass(students, goodGrade).ToConsole();

            Console.WriteLine("CountStudentsThatPassLinq...");
            CountStudentsThatPassLinq(students, goodGrade).ToConsole();
        }

        #endregion

        #region All
        public static bool DoesAllStudentsPass(List<Student> students, int gradeRequired = 10)
        {
            bool allPassed = true;
            // Style boucle for:
            foreach (Student student in students)
            {
                allPassed &= student.Grade >= gradeRequired;
            }

            return allPassed;
        }


        /// <summary>
        /// Test if all items match the specified criteria.
        /// </summary>
        /// <returns>Will exit the loop on the first item not matching.</returns>
        public static bool DoesAllStudentsPassLinq(List<Student> students, int gradeRequired = 10)
        {
            return students.All(s => s.Grade >= gradeRequired);
        }


        #endregion

        #region Any
        public static bool DoesAnyStudentsFail(List<Student> students, int gradeRequired = 10)
        {
            // Style boucle for:
            foreach (Student student in students)
            {
                if (student.Grade < gradeRequired)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns true if any element match the criteria.
        /// </summary>
        /// <returns>Will exit the loop on the first item matching.</returns>
        public static bool DoesAnyStudentsFailLinq(List<Student> students, int gradeRequired = 10)
        {
            return students.Any(s => s.Grade < gradeRequired);
        }
        #endregion
    }
}
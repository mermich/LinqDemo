using LinqDemo.Data;

namespace LinqDemo.Tier1.Tier2.Tier3
{
    public static class GroupDemo
    {
        public static Dictionary<bool, List<Student>> GetStudentsGroups(List<Student> students)
        {
            Dictionary<bool, List<Student>> res = new Dictionary<bool, List<Student>>();

            foreach (Student student in students)
            {
                if (student.Grade >= 10)
                {
                    if (!res.ContainsKey(true))
                    {
                        res.Add(true, new List<Student>());
                    }

                    res[true].Add(student);
                }
                else
                {
                    if (!res.ContainsKey(false))
                    {
                        res.Add(false, new List<Student>());
                    }

                    res[false].Add(student);
                }
            }


            return res;
        }


        public static IEnumerable<IGrouping<bool, Student>> GetStudentsGroupsLinq(List<Student> students)
        {
            IEnumerable<IGrouping<bool, Student>> failPassGroups = students.GroupBy(s => s.Grade > 10);

            return failPassGroups;
        }



        public static void RunGetStudentsGroups(List<Student> students, int goodGrade = 10)
        {
            Console.WriteLine("GetStudentsGroups...");
            KeyValuePair<bool, List<Student>> group1 = GetStudentsGroups(students).First();
            group1.Value.ToConsole();

            Console.WriteLine("GetStudentsGroupsLinq...");
            GetStudentsGroupsLinq(students).First().ToConsole();
        }
    }
}
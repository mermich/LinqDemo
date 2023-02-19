using Bogus;
using LinqDemo.Data;
using System.Text.Json;

namespace LinqDemo
{
    public static class DataManager
    {
        private static string GetFilePath()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Students.json");
            return path;
        }

        public static List<Student> ReadStudents(DataRefresh dataRefresh)
        {
            switch (dataRefresh)
            {
                case DataRefresh.InMemory:
                    return CreateStudents();

                case DataRefresh.CreateIfNotExists:
                    if (File.Exists(GetFilePath()))
                    {
                        List<Student> students1 = CreateStudents();
                        SaveStudents(students1);
                    }
                    return ReadStudentsFile();

                case DataRefresh.Override:
                    List<Student> students2 = CreateStudents();
                    SaveStudents(students2);
                    return ReadStudentsFile();

                default:
                    throw new NotImplementedException();
            }
        }

        public static List<Student> ReadStudentsFile()
        {
            List<Student>? students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(GetFilePath()));
            return students;
        }

        public static void SaveStudents(List<Student> students)
        {
            string stringData = JsonSerializer.Serialize(students);
            File.WriteAllText(GetFilePath(), stringData);
        }






        /// <summary>
        /// Generation de donnees aleatoires pour demos...
        /// </summary>
        public static List<Student> CreateStudents()
        {
            Faker<Student> studentFaker = new Faker<Student>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Assignements, f => f.Make<Assignement>(4, () => new Faker<Assignement>()
                .RuleFor(ff => ff.Grade, new Random().Next(0, 20))
                .RuleFor(ff => ff.Id, f.UniqueIndex)
                ));

            List<Student> students = studentFaker.Generate(20).ToList();
            return students;
        }
    }
}
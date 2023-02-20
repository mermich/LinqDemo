using Bogus;
using System.Text.Json;

namespace LinqDemo.Exercices.Data
{
    public static class DataManager
    {
        private static string GetFilePath()
        {
            string path = Path.Combine(Environment.CurrentDirectory, "Employees.json");
            return path;
        }

        public static List<Employee> ReadEmployees(DataRefresh dataRefresh)
        {
            switch (dataRefresh)
            {
                case DataRefresh.InMemory:
                    return CreateEmployees();

                case DataRefresh.CreateIfNotExists:
                    if (File.Exists(GetFilePath()))
                    {
                        List<Employee> employees = CreateEmployees();
                        SaveEmployees(employees);
                    }
                    return ReadEmployeesFile();

                case DataRefresh.Override:
                    List<Employee> employees2 = CreateEmployees();
                    SaveEmployees(employees2);
                    return ReadEmployeesFile();

                default:
                    throw new NotImplementedException();
            }
        }

        public static List<Employee> ReadEmployeesFile()
        {
            List<Employee>? employees = JsonSerializer.Deserialize<List<Employee>>(File.ReadAllText(GetFilePath()));
            return employees;
        }

        public static void SaveEmployees(List<Employee> employees)
        {
            string stringData = JsonSerializer.Serialize(employees);
            File.WriteAllText(GetFilePath(), stringData);
        }






        /// <summary>
        /// Generation de donnees aleatoires pour demos...
        /// </summary>
        public static List<Employee> CreateEmployees()
        {
            var skills = new List<string>
            {
                "Dotnet",
                "Java",
                "C++",
                "JS",
                "Node",
                "Unity",
                "Project Management"
            };


            var proficiencies = new List<Proficiency>
            {
                Proficiency.Beginner,
                Proficiency.Confirmed,
                Proficiency.Advanced,
                Proficiency.Expert
            };

            Faker<Employee> employeeFaker = new Faker<Employee>()
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.DateOfBirth, f => f.Person.DateOfBirth)
                .RuleFor(u => u.Skills, f => f.Make<EmployeeSkill>(4, () => new Faker<EmployeeSkill>()
                    .RuleFor(s => s.Proficiency, f => f.PickRandom(proficiencies))
                    .RuleFor(s => s.Skill, f => f.PickRandom(skills))
                )
                );

            List<Employee> employees = employeeFaker.Generate(50).ToList();
            return employees;
        }
    }
}
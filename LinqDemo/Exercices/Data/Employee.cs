using System.ComponentModel;

namespace LinqDemo.Exercices.Data
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<EmployeeSkill> Skills { get; set; } = new List<EmployeeSkill>();
    }
}
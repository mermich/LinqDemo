namespace LinqDemo.Data
{
    public class Student
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";

        public decimal Grade => Assignements.Average(a => a.Grade);



        [ConsoleIgnore]
        public IEnumerable<Assignement> Assignements { get; set; } = new List<Assignement>();
    }
}
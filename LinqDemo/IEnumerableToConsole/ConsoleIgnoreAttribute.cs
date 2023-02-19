namespace LinqDemo.Data
{
    /// <summary>
    /// Proerty decored with this attribute will be ignored by the console writer.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ConsoleIgnoreAttribute : Attribute
    {

    }
}
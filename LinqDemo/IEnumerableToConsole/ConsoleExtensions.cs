using System.Reflection;

namespace LinqDemo.Data
{
    public static class ConsoleExtensions
    {
        public static void ToConsole(this int value)
        {
            Console.WriteLine(value);
        }

        public static void ToConsole<T>(this T item)
        {
            if (item == null)
            {
                Console.WriteLine("No Item");
            }
            else if (item is IEnumerable<string> enumerableStrings)
            {
                ToConsoleStrings(enumerableStrings);
            }
            else if (item is IEnumerable<object> enumerableItems)
            {
                ToConsoleList(enumerableItems);
            }
            else
            {
                ToConsoleItem(item);
            }
        }


        static void ToConsoleList<T>(this IEnumerable<T> items)
        {
            if (items.Any())
            {
                IEnumerable<PropertyInfo> properties = items.First().GetType().GetProperties().Where(p => !p.GetCustomAttributes<ConsoleIgnoreAttribute>().Any());
                if (properties.Any())
                {
                    int columnTextWidth = WriteHeader(properties);

                    foreach (T? item in items)
                    {
                        WriteRow(properties, columnTextWidth, item);
                    }

                    WriteHr(properties);
                }
                else
                {
                    Console.WriteLine("Type does not have any properties...");
                }
            }
            else
            {
                Console.WriteLine("No Items");
            }
        }


        static void ToConsoleItem<T>(T item)
        {
            if (item == null)
            {
                Console.WriteLine("No Item");
            }
            else
            {
                IEnumerable<PropertyInfo> properties = typeof(T).GetProperties().Where(p => !p.GetCustomAttributes<ConsoleIgnoreAttribute>().Any());
                if (properties.Any())
                {
                    int columnTextWidth = WriteHeader(properties);
                    WriteRow(properties, columnTextWidth, item);
                    WriteHr(properties);
                }
                else
                {
                    Console.WriteLine("Type does not have any properties...");
                }
            }
        }

        private static void WriteRow<T>(IEnumerable<PropertyInfo> properties, int columnTextWidth, T? item)
        {
            foreach (PropertyInfo property in properties)
            {
                string? value = "";
                if (property.PropertyType == typeof(string))
                {
                    value = item.GetType().GetProperty(property.Name).GetValue(item).ToString();
                }
                else if (property.PropertyType.IsGenericType)
                {
                    // ignore;
                }
                else
                {
                    value = item.GetType().GetProperty(property.Name).GetValue(item).ToString();
                }

                Console.Write("|" + value.PadRight(columnTextWidth));
            }

            Console.Write("|");
            Console.WriteLine();
        }

        private static int WriteHeader(IEnumerable<PropertyInfo> properties)
        {
            WriteHr(properties);

            int columnTextWidth = ((Console.WindowWidth - 2) / properties.Count()) - 1;

            foreach (PropertyInfo property in properties)
            {
                Console.Write("|");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(property.Name.PadRight(columnTextWidth));
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.Write("|");
            Console.WriteLine();

            WriteHr(properties);

            return columnTextWidth;
        }

        private static void WriteHr(IEnumerable<PropertyInfo> properties)
        {
            Console.Write("|");
            for (int i = 1; i < Console.WindowWidth - properties.Count(); i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
            Console.WriteLine();
        }

        static void ToConsoleStrings(this IEnumerable<string> values)
        {
            Console.Write("|");
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
            Console.WriteLine();

            int columnTextWidth = Console.WindowWidth - 2;

            Console.Write("|");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Value".PadRight(columnTextWidth));
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("|");
            Console.WriteLine();


            Console.Write("|");
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
            Console.WriteLine();

            foreach (string value in values)
            {
                Console.Write("|" + value.PadRight(columnTextWidth) + "|");
                Console.WriteLine();
            }


            Console.Write("|");
            for (int i = 1; i < Console.WindowWidth - 1; i++)
            {
                Console.Write("-");
            }
            Console.Write("|");
            Console.WriteLine();
        }
    }
}
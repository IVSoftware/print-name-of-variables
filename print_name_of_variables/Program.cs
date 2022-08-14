using System;
using System.Reflection;

namespace print_name_of_variables
{
    class Program
    {
        static void Main(string[] args)
        {
            var collection = new object []
            {
                new HasNameA(),
                new HasNameB(),
                new NoNameC(),
            };

            foreach (object item in collection)
            {
                Console.WriteLine("variable name : " + item.GetName());
                Console.WriteLine("variable value: " + item);
                Console.WriteLine("variable type : " + item.GetType().Name);
                Console.WriteLine("***************************** ");
            }
        }
    }
    class HasNameA
    {
        public string Name { get; set; } = "A";
        public object Value { get; set; } = 1;
        public override string ToString() => $"{Value}";
    }
    class HasNameB
    {
        public string Name { get; set; } = "B";
        public object Value { get; set; } = "Hello";
        public override string ToString() => $"{Value}";
    }
    class NoNameC
    {
        public object Value { get; set; } = Math.PI;
        public override string ToString() => $"{Value}";
    }

    static partial class Extensions
    {
        public static string GetName(this object unk)
        {
            Type type = unk.GetType();
            PropertyInfo propertyInfo = type.GetProperty("Name");
            if (propertyInfo == null)
            {
                return $"Error: Type '{type.Name}' does not have a Name property.";
            }
            else
            {
                return $"{propertyInfo.GetValue(unk)}";
            }
        }
    }
}

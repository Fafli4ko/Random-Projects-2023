using System;
using System.Reflection;

namespace ReflectionDemo
{
    public class Person
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string GetName()
        {
            return name;
        }

        private int GetAge()
        {
            return age;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("John Doe", 30);

            // Get the type of the Person class
            Type type = typeof(Person);

            // Get the public properties of the Person class
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            Console.WriteLine("Public properties:");
            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine(property.Name);
            }

            // Get the non-public fields of the Person class
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Non-public fields:");
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine(field.Name);
            }

            // Get the private methods of the Person class
            MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);
            Console.WriteLine("Private methods:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}

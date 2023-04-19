using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace h4k3r
{
    // Represents a user account
    public class User
    {
        private string Name = "Peev";     // Private field to store user's name
        private double Balance = 2000000; // Private field to store user's balance
    }

    // Represents a hacker
    public class Hacker
    {
        private string username = "DedSec24"; // Private field to store hacker's username
        private string password = "su";       // Private field to store hacker's password

        // Method to attack a user account
        public void MassAttack(User user)
        {
            // Get the type of the User class
            Type myType = typeof(User);

            // Get all the fields (both public and private) of the User class
            FieldInfo[] classFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // Loop through all the fields and print their values for the given user object
            foreach (var item in classFields)
            {
                Console.WriteLine(item.GetValue(user));
            }
        }
    }

    // Represents a spy
    public class Spy
    {
        // Method to steal information from a hacker object
        public void Steal(Type t, Hacker obj)
        {
            // Get all the public methods of the given type
            MethodInfo[] publicMethods = t.GetMethods();

            // Create a new User object to pass as argument to the hacker methods
            User user = new User();

            // Print the name of the type being investigated
            Console.WriteLine("Methods investigation: " + typeof(Hacker).Name);

            // Loop through all the public methods and invoke them on the hacker object
            foreach (var item in publicMethods)
            {
                // Invoke the current method on the given object, passing the user object as argument
                // and print the method name and return value
                Console.WriteLine(item.Name, item.Invoke(obj, new object[] { user }).ToString());
            }
        }

        // Method to attack a hacker object
        public void MassAttack(Hacker user)
        {
            // Get the type of the Hacker class
            Type myType = typeof(Hacker);

            // Get all the fields (both public and private) of the Hacker class
            FieldInfo[] classFields = myType.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            // Loop through all the fields and print their values for the given hacker object
            foreach (var item in classFields)
            {
                Console.WriteLine(item.GetValue(user));
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Create a new Hacker and User object
            Hacker h = new Hacker();
            User user1 = new User();

            // Call the MassAttack method on the Hacker object passing the User object as argument
            h.MassAttack(user1);

            // Create a new Spy object and another Hacker object
            Spy s = new Spy();
            Hacker user2 = new Hacker();

            // Call the Steal method on the Spy object passing the Hacker object and its type as arguments
            s.Steal(typeof(Hacker), user2);

            // Call the MassAttack method on the Spy object passing the Hacker object as argument
            s.MassAttack(user2);

            Console.ReadKey();
        }
    }
}

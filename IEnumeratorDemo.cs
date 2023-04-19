using System;
using System.Collections;

namespace IEnumeratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an array of integers
            int[] numbers = { 1, 2, 3, 4, 5 };

            // Get the enumerator for the array
            IEnumerator enumerator = numbers.GetEnumerator();

            // Loop through the enumerator using the MoveNext() method
            while (enumerator.MoveNext())
            {
                // Get the current value from the enumerator
                int value = (int)enumerator.Current;

                // Print the current value
                Console.WriteLine(value);
            }

            // Reset the enumerator to the beginning
            enumerator.Reset();

            // Move to the first element
            enumerator.MoveNext();

            // Loop through the enumerator again using a do-while loop
            do
            {
                // Get the current value from the enumerator
                int value = (int)enumerator.Current;

                // Print the current value
                Console.WriteLine(value);
            } while (enumerator.MoveNext());
        }
    }
}

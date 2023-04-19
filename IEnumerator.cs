using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumeratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new instance of the MyCollection class.
            MyCollection myCollection = new MyCollection();

            // Use an IEnumerator to iterate over the items in the collection.
            IEnumerator enumerator = myCollection.GetEnumerator();

            while (enumerator.MoveNext())
            {
                // Use the Current property to get the current item in the collection.
                Console.WriteLine(enumerator.Current);
            }

            // Reset the enumerator to the beginning of the collection.
            enumerator.Reset();

            // Use the Current property to get the first item in the collection.
            Console.WriteLine($"First item in collection: {enumerator.Current}");
        }
    }

    // A simple collection class that implements IEnumerable.
    public class MyCollection : IEnumerable
    {
        private string[] items = new string[] { "Item 1", "Item 2", "Item 3" };

        // Implement the IEnumerable.GetEnumerator method.
        public IEnumerator GetEnumerator()
        {
            return new MyEnumerator(items);
        }
    }

    // A simple enumerator class that implements IEnumerator.
    public class MyEnumerator : IEnumerator
    {
        private string[] items;
        private int currentIndex = -1;

        // Constructor that takes an array of items to iterate over.
        public MyEnumerator(string[] items)
        {
            this.items = items;
        }

        // Implement the IEnumerator.Current property.
        public object Current
        {
            get
            {
                // Return the current item in the array.
                return items[currentIndex];
            }
        }

        // Implement the IEnumerator.MoveNext method.
        public bool MoveNext()
        {
            // Move to the next item in the array.
            currentIndex++;

            // Return true if we haven't reached the end of the array yet.
            return currentIndex < items.Length;
        }

        // Implement the IEnumerator.Reset method.
        public void Reset()
        {
            // Reset the current index to -1, which means we'll start at the beginning of the array on the next MoveNext call.
            currentIndex = -1;
        }
    }
}

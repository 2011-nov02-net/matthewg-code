using HelloVisualStudio.Library.Sorting;
using HelloVisualStudio.ConsoleApp.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Net.NetworkInformation;
using System.Transactions;
using HelloVisualStudio.Library;

namespace HelloVisualStudio.ConsoleApp
{
    class Program
    {
        static void Main(string[] args) {
            // separation of concerns
            //      different "concerns" or "considerations" in code shouldn't be tangled together
            // single responsibility principle (S in SOLID)
            //      a unit of code (e.g. class, method) should have just one responsibility
            // DRY principle
            //      don't repeat yourself
            // KISS
            //      keep it simple stupid


            // have a list of products
            List<Product> catalog = GetProducts();


            // display them to the user
            // allow for some customization of that display to the user
            var input = "";
            while (input != "s" && input != "d") {
                Console.WriteLine("Enter s for simple, d for detailed.");
                input = Console.ReadLine();
            }
            var input2 = "";
            while (input2 != "y" && input2 != "n") {
                Console.WriteLine("Sort? y/n");
                input2 = Console.ReadLine();
            }

            ISorter sorter;

            if (input2 == "y") {
                sorter = new PriceSorter();
            } else {
                sorter = new NonSorter();
            }

            IWriter writer;

            if (input == "s") {
                writer = new SimpleWriter(sorter);
            } else {
                writer = new DetailedWriter(sorter);
            }

            writer.FormatAndDisplay(catalog);

            // dependency inversion principle (D in SOLID)
            // - don't have classes depend on each other directly
            //   instead, have them depend on interfaces
        }

        static List<Product> CollectionDigression() {
            // built-in collections in C# / .NET

            // most basic: array
            //      low level, less "overhead"
            //      fixed-size sequence of a particular data type

            var numbers = new int[5]; // an array of 5 ints (initial value is the default 0)
            numbers[3] = 1; // setting fourth value in the array to 1

            // System.Collections.ArrayList is an old alternative to arrays in C#
            //      not locked down to a particular data type
            var numbers2 = new ArrayList();

            numbers2.Add(1);
            numbers2.Add(2);
            numbers2.Add(3);
            numbers2.Remove(2);
            numbers2.Add("abc");
            numbers2.Add(new Product("", "", 1, 1));

            // problem with arraylist: since it is not type-locked, it can't be sure that the value in the list is a number
            // C# supports overloading the [] operator (indexing operator)
            //      recent version of C# added reverse indexing into collections with ^, so ^2 is the second from the end
            int x = (int) numbers2[^1]; // downcast - assert to the compiler that the value will be a particular type more specific than it can verify
            x++;

            // upcasting - take a value of specific type and store it in a variable of a less specific type

            object o = x; // upcasting a value type to "object" boxes the value in a reference type container
                          // downcasting from that object back to the value is called unboxing

            double pi = 3.14;
            int three = (int)pi;
            // another type of "casting" for type conversion. neither downcasting nor upcasting. int and double are both structs, neither inheriting from the other.
                    // but it is a conversion that is "dangerous" (could lose data) so it's explicit
            // float num = (float)1 / 3;
            // float num2 = 1 / 3;

            // is and as keywords for determining type relationship and explicit casting
            if (numbers2[0] is int) { 
    
            } else {
                Product product = numbers2[0] as Product;
                if (product != null) {

                }
            }


            // we don't need to use types like arraylist anymore because C# supports generics.

            // List supports flexible size and specific data type using the <> syntax.

            var list = new List<int> { 4, 3, 8, 1 }; // no upcasting
            var z = list[0]; // no downcasting, the compiler knows it must be an int.

            return null;
        }

        // anything method that just returns something can be written in "expression body syntax" as follows:
        static List<Product> GetProducts() => new List<Product> { new Product("0001", "laptop", 1000.00, 5),
                                                                  new Product("0003", "pizza", 10.00, 50),
                                                                  new Product("0004", "coffee", 10.00, 20) };

        static void ApplyDiscount (Product p) {
            p.Price *= 0.85; // 15% off
        }
    }
}

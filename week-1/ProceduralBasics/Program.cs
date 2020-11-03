using System;

namespace ProceduralBasics
{

    // in a console application project (dotnet new console), runtime looks for "static void Main(string[] args)" method.

    // projects contain classes (blueprint for creating an object, which combines functions/behavior and data)
    // classes contain members, e.g. methods (sequence of statements that run sequentially, can have input parameters and a return value output)

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // C# has typed variables
            // a variable is a reference to a value
            // the type of value is determined at declaration and is immutable

            // primitive types:
            // int -        4 bytes ( <= 2,147,483,647)
            // short -      2 bytes
            // byte -       1 byte
            // long -       8 bytes
            // double -     8 bytes (floating-point)
            // float -      4 bytes (floating-point)
            // decimal -    16 bytes (floating-point)
            // bool -       true/false
            // char -       single character
            // string -     >= 1 characters

            double x = 1.0 / 3; // declaring a variable named 'x' of type 'double', initializing with a value of 1/3.
            x -= 5; // reassigning x based on its initial value minus 5.
            
            Console.WriteLine("Enter a number");
            string input = Console.ReadLine();
            int num = int.Parse(input);

            bool negative = (num < 0);

            // Control flow: loops, conditionals, etc)

            if (negative) {
                Console.WriteLine("This prints if number was negative.");
            } else if (num == 0) {
                Console.WriteLine("The number was 0.");
            } else {
                Console.WriteLine("The number was positive.");
            }

            // switch statement
            switch (num) {
                case 4:
                    x = 8;
                    break;
                case 7:
                    x = 1;
                    break;
            }
            // C# supports "switch expression" which uses "pattern matching"
            
            // for loop : (start, condition, increment)
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(i % 3);
            }

            // In C# even primitives are treated as objects, except for null which is the (default) absence of a value.
            3.ToString();
            true.CompareTo(false);



            // print out triangle of size "number" (based on user input)
            for (int i = 0; i < num; i++) {
                // string line = new string('#', i + 1); // instead of the block below
                for (int j = 0; j <= i; j++) {
                    Console.Write("#");   
                }
                Console.WriteLine();
            }
        }
    }
}

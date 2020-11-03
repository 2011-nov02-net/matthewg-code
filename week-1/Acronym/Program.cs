using System;

namespace Acronym
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a multi-word term:");
            string input = Console.ReadLine();
            
            if (input.Length < 1)
                return;

            string[] words = input.Split(' ');

            foreach (string word in words) {
                Console.Write(word.Substring(0, 1).ToUpper());
            }
        }
    }
}

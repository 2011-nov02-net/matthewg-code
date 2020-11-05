using RockPaperScissors.Library;
using System;

namespace RockPaperScissors.ConsoleApp {
    class Program {
        static void Main(string[] args) {
            // in a .NET program, paths will be relative to the location of the application dll (usually down in bin/debug/etc)
            string filePath = "../../../data.json"; // should be next to this file
            var persistence = new JsonFilePersistence(filePath);
            var game = new GameLogic(persistence);

            // Loops game until user quits
            while (true) {
                var input = "";
                while (!ValidInput(input)) { // Read user input until a valid entry is received
                    Console.WriteLine("Enter your choice (\"Rock\", \"Paper\", or \"Scissors\") [Q] to quit:");
                    input = Console.ReadLine();
                }

                if (input.Equals("q", StringComparison.OrdinalIgnoreCase)) { // quit game if user entered Q
                    Console.WriteLine("Exiting Game.");
                    persistence.Write(game.Scores);
                    return;
                } else {                                                    // otherwise assign player an element object
                    game.PlayerElement = ReadPlayerChoice(input);
                }
                // print outcome and scoreboard
                Console.WriteLine(game.result());
                Console.Write($"\nScore:\nYou: {game.Scores.PlayerScore}\nAI: {game.Scores.AIScore}\nDraws: {game.Scores.Draws}\n\n");
            }

        }

        /// <summary>
        /// Checks user input against valid string inputs. Case-insensitive.
        /// </summary>
        /// <returns>
        /// True if the user entered an acceptible string. False otherwise.
        /// </returns>
        static bool ValidInput(string s) {
            return s.Equals("q", StringComparison.OrdinalIgnoreCase)
                || s.Equals("rock", StringComparison.OrdinalIgnoreCase)
                || s.Equals("paper", StringComparison.OrdinalIgnoreCase)
                || s.Equals("scissors", StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Assigns the player an IElement object of their selection based on the user input.
        /// </summary>
        /// <returns>
        /// An IElement object of type: Rock, Paper, or Scissors
        /// </returns>
        static IElement ReadPlayerChoice(string s) {
            if (s.Equals("rock", StringComparison.OrdinalIgnoreCase)) {
                return new Rock();
            } else if (s.Equals("paper", StringComparison.OrdinalIgnoreCase)) {
                return new Paper();
            } else {
                return new Scissors();
            }
        }
    }
}

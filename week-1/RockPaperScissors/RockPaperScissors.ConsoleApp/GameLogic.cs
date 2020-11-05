using RockPaperScissors.Library;
using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.ConsoleApp {
    class GameLogic {
        public ScoreTracker Scores { get; }
        public IElement PlayerElement { get; set; }
        public IElement AIElement { get; set; }


        public GameLogic() {
            Scores = new ScoreTracker();
        }

        public string result() {
            AIElement = AIChooseElement();
            if (PlayerElement.Beats == AIElement.value) {
                Scores.PlayerScore++;
                return $"\nYour {PlayerElement.value} beats their {AIElement.value}.";
            }
            if (AIElement.Beats == PlayerElement.value) {
                Scores.AIScore++;
                return $"\nTheir {AIElement.value} beats your {PlayerElement.value}.";
            }
            else {
                Scores.Draws++;
                return $"\nYou both picked {PlayerElement.value}. The round ends in a draw.";
            }
        }

        /// <summary>
        /// Picks a random element: Rock, Paper, or Scissors to play.
        /// </summary>
        /// <returns>
        /// An IElement object of type: Rock, Paper, or Scissors
        /// </returns>
        private IElement AIChooseElement() {
            var rand = new Random();
            int num = rand.Next(3);

            return num switch
            {
                0 => new Rock(),
                1 => new Paper(),
                _ => new Scissors(),
            };
        }
    }
}

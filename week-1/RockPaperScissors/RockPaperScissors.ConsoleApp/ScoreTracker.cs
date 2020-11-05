using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.ConsoleApp {
    public class ScoreTracker {
        public int PlayerScore { get; set; }
        public int AIScore { get; set; }
        public int Draws { get; set; }

        public ScoreTracker() {
            PlayerScore = 0;
            AIScore = 0;
            Draws = 0;
        }
    }
}

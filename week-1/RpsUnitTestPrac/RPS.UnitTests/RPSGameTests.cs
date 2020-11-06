using System;
using Xunit;

namespace RPS.UnitTests {
    public class RPSGameTests {

        [Theory]
        [InlineData("r")]
        [InlineData("p")]
        [InlineData("s")]
        public void PlayingTiesShouldReturnTieAndUpdateScore(string move) {
            // 1. arrange
            // and setup necessary to arrange the objects for "act"
            var game = new RPSgame();
            var score = new Score();
            int initialLossCount = score.lossCount;
            int initialWinCount = score.winCount;
            int initialTieCount = score.tieCount;

            // 2. act
            // the specific behavior we are testing
            string result = game.Play(move, move, score);

            // 3. assert
            // verify that everything went correctly with the "act"
            // (assume that the "arrange" part went fine.
            Assert.Equal("tie", result);
            Assert.Equal(initialLossCount, score.lossCount);
            Assert.Equal(initialWinCount, score.winCount);
            Assert.Equal(initialWinCount + 1, score.tieCount);
        }
    }
}

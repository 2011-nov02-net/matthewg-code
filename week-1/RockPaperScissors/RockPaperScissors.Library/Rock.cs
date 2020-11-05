using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library {
    public class Rock : IElement {
        public Elements value => Elements.Rock;

        public Elements Beats => Elements.Scissors;

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library {
    public class Scissors : IElement {
        public Elements value => Elements.Scissors;

        public Elements Beats => Elements.Paper;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library {
    public class Paper : IElement {
        public Elements value => Elements.Paper;

        public Elements Beats => Elements.Rock;
    }
}

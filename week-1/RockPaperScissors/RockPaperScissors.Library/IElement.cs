using System;
using System.Collections.Generic;
using System.Text;

namespace RockPaperScissors.Library {
    public interface IElement {
        Elements value { get; }
        Elements Beats { get; }
    }
}

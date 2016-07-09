using System.Collections.Generic;

namespace GameCore
{
    interface IBoardState
    {
        List<int>[] BoardState { get; set; }
    }
}

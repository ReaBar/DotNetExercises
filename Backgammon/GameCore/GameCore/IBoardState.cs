using System;
using System.Collections.Generic;

namespace GameCore
{
    public interface IBoardState
    {
        PointOnBoard[] BoardState { get;}
        int BoardSize();
    }
}

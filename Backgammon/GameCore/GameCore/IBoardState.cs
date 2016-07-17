﻿using System;
using System.Collections.Generic;

namespace GameCore
{
    public interface IBoardState
    {
        PointOnBoard[] BoardPointsState { get;}
        int BoardSize();
        List<GameCheckers> GameCheckersOnBar { get; }
        List<GameCheckers> GameCheckersOut { get; }
    }
}

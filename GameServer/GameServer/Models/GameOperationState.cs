﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Models
{
    enum GameOperationState
    {
        WaitingForPlayers,
        InProgress,
        Completed,
        Failed,
    }
}
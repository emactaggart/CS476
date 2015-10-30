﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameServer.Data.Models.TicTacToe
{
    public enum PlayerMark
    {
        Empty, X, O
    }

    public enum PlayerPosition
    {
        First, Second
    }
    
    public enum MovePosition
    {
        TopLeft, TopCenter, TopRight,
        MiddleLeft, MiddleCenter, MiddleRight,
        BottomLeft, BottomCenter, BottomRight
    }

    public class Player
    {
        public string name;
        public PlayerMark mark;
    }
}
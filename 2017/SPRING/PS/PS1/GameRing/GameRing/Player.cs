﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace GameRing
{
    public class Player
    {
        public int ID;
        public int Gender { get; set; }
        public Player Next { get; set; }

        public Player(int id, char gender)
        {
            ID = id;
            if (gender == 'M')
                Gender = 0;
            else if (gender == 'F')
                Gender = 1;
            else throw new ArgumentException("Argument should be 'M' or 'F' ");
        }

        public char GetChar()
        {
            return (Gender == 0) ? 'M' : 'F';
        }

        public Player Copy()
        {
            return new Player(ID, GetChar());
        }
    }
}

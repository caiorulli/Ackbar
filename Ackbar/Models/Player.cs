﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ackbar.Models
{
    public class Player
    {
        public long Id { get; set; }
        public Game[] LikedGames { get; set; }
        public Game[] DislikedGames { get; set; }
        public User User { get; set; }
    }
}
﻿using Ackbar.Models;
using Microsoft.EntityFrameworkCore;

namespace Ackbar
{
    public class GameGuideContext: DbContext
    {
        public GameGuideContext(DbContextOptions<GameGuideContext> options): base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
    }
}
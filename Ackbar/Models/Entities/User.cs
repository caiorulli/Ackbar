﻿namespace Ackbar.Models.Entities
{
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Player Player { get; set; }
    }
}
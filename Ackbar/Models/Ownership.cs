using System;

namespace Ackbar.Models
{
    public class Ownership
    {
        public long Id { get; set; }
        public DateTime DateTime { get; set; }
        public Game Game { get; set; }
        public Player Player { get; set; }
    }
}
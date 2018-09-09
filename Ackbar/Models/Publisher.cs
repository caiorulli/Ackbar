using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Publisher
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
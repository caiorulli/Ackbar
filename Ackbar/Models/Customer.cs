using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
        public ICollection<Report> Reports { get; set; }
    }
}
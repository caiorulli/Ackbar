namespace Ackbar.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string ReportUrl { get; set; }
        public User User { get; set; }
    }
}
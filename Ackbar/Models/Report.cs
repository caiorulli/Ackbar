namespace Ackbar.Models
{
    public class Report
    {
        public long Id { get; set; }
        public string ReportUrl { get; set; }
        public Customer Customer { get; set; }
    }
}
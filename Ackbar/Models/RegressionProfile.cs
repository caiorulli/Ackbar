using Ackbar.Models.RegressionProfileTypes;

namespace Ackbar.Models
{
    public class RegressionProfile
    {
        public long Id { get; set; }
        public RegressionAgency Agency { get; set; }
        public RegressionAppearance Appearance { get; set; }
        public RegressionConflict Conflict { get; set; }
        public RegressionInvestment Investment { get; set; }
        public RegressionRules Rules { get; set; }
    }
}
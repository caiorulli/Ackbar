namespace Ackbar.Models.RegressionProfileTypes
{
    public class RegressionRules
    {
        public long Id { get; set; }
        public float Randomness { get; set; }
        public float Actions { get; set; }
        public float Conditions { get; set; }
        public float Resources { get; set; }
        public float Components { get; set; }
        public float VictoryConditions { get; set; }
        public float IdealNumberOfPlayers { get; set; }
        public float RealNumberOfPlayers { get; set; }
        public float Variance { get; set; }
    }
}
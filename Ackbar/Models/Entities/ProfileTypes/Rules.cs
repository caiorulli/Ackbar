namespace Ackbar.Models.Entities.ProfileTypes
{
    public class Rules
    {
        public long Id { get; set; }
        public int Randomness { get; set; }
        public int Actions { get; set; }
        public int Conditions { get; set; }
        public int Resources { get; set; }
        public int Components { get; set; }
        public int VictoryConditions { get; set; }
        public int IdealNumberOfPlayers { get; set; }
        public int RealNumberOfPlayers { get; set; }
        public int Variance { get; set; }
    }
}
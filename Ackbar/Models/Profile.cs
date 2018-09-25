using Ackbar.Models.ProfileTypes;

namespace Ackbar.Models
{
    public class Profile
    {
        public long Id { get; set; }
        public Agency Agency { get; set; }
        public Appearance Appearance { get; set; }
        public Conflict Conflict { get; set; }
        public Investment Investment { get; set; }
        public Rules Rules { get; set; }

        public double[] MakeRegressionArray()
        {
            return new double[]
            {
                Agency.Gradation,
                Agency.Participation,
                Agency.Result,
                Appearance.Quality,
                Appearance.Theme,
                Appearance.Transmediality,
                Appearance.VisualIdentity,
                Conflict.Competitivity,
                Conflict.Economy,
                Conflict.Feedback,
                Conflict.Interaction,
                Conflict.Structure,
                Conflict.Symmetry,
                Conflict.CognitiveAbility,
                Conflict.MentalAbility,
                Conflict.PhysicalAbility,
                Conflict.SocialAbility,
                Investment.Duration,
                Investment.Monetary,
                Investment.Setup,
                Investment.Space,
                Rules.Actions,
                Rules.Components,
                Rules.Conditions,
                Rules.Randomness,
                Rules.Resources,
                Rules.Variance,
                Rules.VictoryConditions,
                Rules.IdealNumberOfPlayers,
                Rules.RealNumberOfPlayers
            };
        }
    }
}
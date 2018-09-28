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

        public static RegressionProfile MakeRegressionProfile(double[] regressionResult)
        {
            var agency = new RegressionAgency
            {
                Gradation = (float) regressionResult[1],
                Participation = (float) regressionResult[2],
                Result = (float) regressionResult[3]
            };

            var appearance = new RegressionAppearance
            {
                Quality = (float) regressionResult[4],
                Theme = (float) regressionResult[5],
                Transmediality = (float) regressionResult[6],
                VisualIdentity = (float) regressionResult[7]
            };

            var conflict = new RegressionConflict
            {
                Competitivity = (float) regressionResult[8],
                Economy = (float) regressionResult[9],
                Feedback = (float) regressionResult[10],
                Interaction = (float) regressionResult[11],
                Structure = (float) regressionResult[12],
                Symmetry = (float) regressionResult[13],
                CognitiveAbility = (float) regressionResult[14],
                MentalAbility = (float) regressionResult[15],
                PhysicalAbility = (float) regressionResult[16],
                SocialAbility = (float) regressionResult[17]
            };

            var investment = new RegressionInvestment
            {
                Duration = (float) regressionResult[18],
                Monetary = (float) regressionResult[19],
                Setup = (float) regressionResult[20],
                Space = (float) regressionResult[21]
            };

            var rules = new RegressionRules
            {
                Actions = (float) regressionResult[22],
                Components = (float) regressionResult[23],
                Conditions = (float) regressionResult[24],
                Randomness = (float) regressionResult[25],
                Resources = (float) regressionResult[26],
                Variance = (float) regressionResult[27],
                VictoryConditions = (float) regressionResult[28],
                IdealNumberOfPlayers = (float) regressionResult[29],
                RealNumberOfPlayers = (float) regressionResult[30]
            };

            return new RegressionProfile
            {
                Agency = agency,
                Appearance = appearance,
                Conflict = conflict,
                Investment = investment,
                Rules = rules
            };
        }
    }
}
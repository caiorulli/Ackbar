using System.Collections.Generic;
using Ackbar.Models;
using Ackbar.Models.RegressionProfileTypes;
using MathNet.Numerics;

namespace Ackbar.Api
{
    public class RegressionService : IRegressionService
    {
        public void CalculateRegression(Player player, IEnumerable<Game> randomGames)
        {            
            var regressionX = new List<double[]>();
            var results = new List<double>();
                
            var likes = player.Likes;

            foreach (var like in likes)
            {
                var profile = like.Game.Profile;
                regressionX.Add(profile.MakeRegressionArray());
                results.Add(1);
            }

            foreach (var game in randomGames)
            {
                var profile = game.Profile;
                regressionX.Add(profile.MakeRegressionArray());
                results.Add(0);
            }

            var p = Fit.MultiDim(
                regressionX.ToArray(),
                results.ToArray(),
                true);

            player.RegressionAlpha = (float) p[0];
            var agency = new RegressionAgency
            {
                Gradation = (float) p[1],
                Participation = (float) p[2],
                Result = (float) p[3]
            };

            var appearance = new RegressionAppearance
            {
                Quality = (float) p[4],
                Theme = (float) p[5],
                Transmediality = (float) p[6],
                VisualIdentity = (float) p[7]
            };

            var conflict = new RegressionConflict
            {
                Competitivity = (float) p[8],
                Economy = (float) p[9],
                Feedback = (float) p[10],
                Interaction = (float) p[11],
                Structure = (float) p[12],
                Symmetry = (float) p[13],
                CognitiveAbility = (float) p[14],
                MentalAbility = (float) p[15],
                PhysicalAbility = (float) p[16],
                SocialAbility = (float) p[17]
            };

            var investment = new RegressionInvestment
            {
                Duration = (float) p[18],
                Monetary = (float) p[19],
                Setup = (float) p[20],
                Space = (float) p[21]
            };

            var rules = new RegressionRules
            {
                Actions = (float) p[22],
                Components = (float) p[23],
                Conditions = (float) p[24],
                Randomness = (float) p[25],
                Resources = (float) p[26],
                Variance = (float) p[27],
                VictoryConditions = (float) p[28],
                IdealNumberOfPlayers = (float) p[29],
                RealNumberOfPlayers = (float) p[30]
            };

            player.Profile = new RegressionProfile
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
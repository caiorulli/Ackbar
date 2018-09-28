using System.Collections.Generic;

namespace Ackbar.Models
{
    public class Game
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Year { get; set; }
        public string Age { get; set; }
        public string NumberOfPlayers { get; set; }
        public string Duration { get; set; }
        public string Description { get; set; }
        public string CoverImage { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public float SellingPrice { get; set; }
        
        public ICollection<Like> Likes { get; set; }
        public ICollection<View> Views { get; set; }
        public ICollection<Ownership> Ownerships { get; set; }
        public Profile Profile { get; set; }

        public float CalculateScore(Player player)
        {
            var score = player.RegressionAlpha;
            
            score += player.Profile.Agency.Gradation * Profile.Agency.Gradation;
            score += player.Profile.Agency.Participation * Profile.Agency.Participation;
            score += player.Profile.Agency.Result * Profile.Agency.Result;
            
            score += player.Profile.Appearance.Transmediality * Profile.Appearance.Transmediality;
            score += player.Profile.Appearance.Quality * Profile.Appearance.Quality;
            score += player.Profile.Appearance.Theme * Profile.Appearance.Theme;
            score += player.Profile.Appearance.VisualIdentity * Profile.Appearance.VisualIdentity;
            
            score += player.Profile.Conflict.MentalAbility * Profile.Conflict.MentalAbility;
            score += player.Profile.Conflict.Competitivity * Profile.Conflict.Competitivity;
            score += player.Profile.Conflict.Economy * Profile.Conflict.Economy;
            score += player.Profile.Conflict.Feedback * Profile.Conflict.Feedback;
            score += player.Profile.Conflict.Interaction * Profile.Conflict.Interaction;
            score += player.Profile.Conflict.Structure * Profile.Conflict.Structure;
            score += player.Profile.Conflict.Symmetry * Profile.Conflict.Symmetry;
            score += player.Profile.Conflict.CognitiveAbility * Profile.Conflict.CognitiveAbility;
            score += player.Profile.Conflict.PhysicalAbility * Profile.Conflict.PhysicalAbility;
            score += player.Profile.Conflict.SocialAbility * Profile.Conflict.SocialAbility;

            score += player.Profile.Investment.Monetary * Profile.Investment.Monetary;
            score += player.Profile.Investment.Duration * Profile.Investment.Duration;
            score += player.Profile.Investment.Setup * Profile.Investment.Setup;
            score += player.Profile.Investment.Space * Profile.Investment.Space;

            score += player.Profile.Rules.Resources * Profile.Rules.Resources;
            score += player.Profile.Rules.Actions * Profile.Rules.Actions;
            score += player.Profile.Rules.Components * Profile.Rules.Components;
            score += player.Profile.Rules.Conditions * Profile.Rules.Conditions;
            score += player.Profile.Rules.Randomness * Profile.Rules.Randomness;
            score += player.Profile.Rules.Variance * Profile.Rules.Variance;
            score += player.Profile.Rules.VictoryConditions * Profile.Rules.VictoryConditions;
            score += player.Profile.Rules.IdealNumberOfPlayers * Profile.Rules.IdealNumberOfPlayers;
            score += player.Profile.Rules.RealNumberOfPlayers * Profile.Rules.RealNumberOfPlayers;

            return score;
        }
    }
}

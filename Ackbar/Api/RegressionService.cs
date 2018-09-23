using System;
using System.Collections.Generic;
using Ackbar.Models;
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
            
            Console.WriteLine(p);
        }
    }
}
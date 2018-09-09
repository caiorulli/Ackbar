using System.Collections.Generic;
using Ackbar.Api.Dto;

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
        
        public ICollection<Like> Likes { get; set; }
        public Profile Profile { get; set; }
        public Publisher Publisher { get; set; }
    }
}

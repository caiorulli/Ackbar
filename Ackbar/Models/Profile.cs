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
    }
}
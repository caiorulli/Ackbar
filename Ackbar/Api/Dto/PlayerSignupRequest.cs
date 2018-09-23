namespace Ackbar.Api.Dto
{
    public class PlayerSignupRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string AvatarUrl { get; set; }
        public int CollectionSize { get; set; }
        public int WeeklyPlayTime { get; set; }
    }
}
namespace Scheduler.Infrastructure.Settings
{
    public class AppSettings
    {
        public string JWTSecretKey { get; set; }
        public int JWTLifespan { get; set; }
    }
}

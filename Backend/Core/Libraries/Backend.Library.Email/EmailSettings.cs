namespace Backend.Library.Email
{
    public class EmailSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string AppPass { get; set; }
        public bool Authenticate { get; set; }
    }
}
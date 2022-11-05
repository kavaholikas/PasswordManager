namespace PManager.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool LastUsed { get; set; }
    }
}
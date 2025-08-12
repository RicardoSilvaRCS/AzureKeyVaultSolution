namespace DatabaseAccess.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
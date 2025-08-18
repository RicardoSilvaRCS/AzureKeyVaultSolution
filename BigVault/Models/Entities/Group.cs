namespace DatabaseAccess.Models
{
    public class Group
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<Secret> Secrets { get; set; } = new List<Secret>();
    }
}
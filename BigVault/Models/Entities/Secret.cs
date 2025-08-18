namespace DatabaseAccess.Models
{
    public class Secret
    {
        public Guid SecretId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public int Version { get; set; }
        public bool Enabled { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public virtual ICollection<Group> Groups { get; set; } = new List<Group>();
    }
}
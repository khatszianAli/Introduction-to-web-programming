namespace TaskManager.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string GroupUsername { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? CreatedByUserId { get; set; }
        public User? CreatedByUser { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<GroupMember> Members { get; set; } = new();
        public List<TaskItem> Tasks { get; set; } = new();
    }
}
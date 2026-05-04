namespace TaskManager.Models // Убедитесь, что namespace совпадает с вашим проектом
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public List<TaskItem> Tasks { get; set; } = new();
        public List<GroupMember> GroupMemberships { get; set; } = new();
        public List<Group> CreatedGroups { get; set; } = new();
        public List<TaskComment> Comments { get; set; } = new();
        public List<CommentReaction> Reactions { get; set; } = new();
    }
}
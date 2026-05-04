using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class TaskComment
{
    public int Id { get; set; }

    public int TaskItemId { get; set; }
    public TaskItem? TaskItem { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int? ParentCommentId { get; set; }
    public TaskComment? ParentComment { get; set; }
    public List<TaskComment> Replies { get; set; } = new();

    [Required]
    public string Content { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public List<CommentReaction> Reactions { get; set; } = new();
}

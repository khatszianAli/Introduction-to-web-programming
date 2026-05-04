using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models;

public class CommentReaction
{
    public int Id { get; set; }

    public int TaskCommentId { get; set; }
    public TaskComment? TaskComment { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    [MaxLength(16)]
    public string Emoji { get; set; } = "👍";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}

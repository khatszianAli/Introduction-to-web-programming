using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TaskManager.Models;

public class TaskItem
{
    public int Id { get; set;  }
    [Column("TaskName")]
    [Required(ErrorMessage = "Имя не может быть пустым")]
    public string Name{ get; set; }
    [Required(ErrorMessage = "Описание не может быть пустым")]
    public string Description { get; set; }

    [Required(ErrorMessage = "Дата не может быть пустым")]
    [Column("TaskDate")]
    public DateTime Date { get; set; } = DateTime.Today;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public bool IsCompleted { get; set; } = false;

    [Required]
    public string Status { get; set; } = TaskStatuses.Todo;
    
    public int UserId { get; set; } 
    public User? User { get; set; }
    
    public int? GroupId { get; set; }
    public Group? Group { get; set; }
    
    public List<TaskComment> Comments { get; set; } = new();
}
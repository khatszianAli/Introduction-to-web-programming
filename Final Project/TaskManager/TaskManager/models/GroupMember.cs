namespace TaskManager.Models;

public class GroupMember
{
    public int GroupsId { get; set; }
    public Group? Group { get; set; }

    public int UsersId { get; set; }
    public User? User { get; set; }
}

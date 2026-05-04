namespace TaskManager.Models;

public static class TaskStatuses
{
    public const string Todo = "todo";
    public const string InProgress = "in-progress";
    public const string Done = "done";

    public static readonly string[] All = [Todo, InProgress, Done];
}

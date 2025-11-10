namespace TaskSphere.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation
        public ICollection<Project> Projects { get; set; } = new List<Project>();
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}

namespace AzureTaskTracker.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public TaskItem(int id, string title, string description, bool isCompleted)
        {
            Id = id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
        
        // Parameterless constructor for serialization/deserialization
        public TaskItem() { }
    }
}

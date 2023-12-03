namespace Domain;

public class Shift
{
    public Guid Id { get; set; }
    
    public DateTime StartTime { get; set; } = DateTime.Now;
    
    public DateTime? EndTime { get; set; }

    public Guid ProjectId { get; set; }
    public Project Project { get; set; }
}
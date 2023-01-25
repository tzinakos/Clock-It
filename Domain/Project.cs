namespace Domain;

public class Project
{
    public Guid Id { get; set; }
    
    public string Name { get; set; }

    public Guid SettingsId { get; set; }
    public Settings? Settings { get; set; }
    
    public Guid UserId { get; set; }
    public User User { get; set; }
}
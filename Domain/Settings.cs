using Microsoft.EntityFrameworkCore;

namespace Domain;

public class Settings
{
    public Guid Id { get; set; }

    public string Currency { get; set; }
    
    public decimal Value { get; set; }
    
    public Rate Rate { get; set; }
}

public enum Rate
{
    Annually,
    Monthly,
    Weekly,
    Daily,
    Hourly
}
namespace DefaultNamespace;

public class Event
{
    public int MoveNumber { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
    public string Characteristic { get; set; }

    public Event(int moveNumber, string description, string type, string characteristic)
    {
        MoveNumber = moveNumber;
        Description = description;
        Type = type;
        Characteristic = characteristic;
    }
}
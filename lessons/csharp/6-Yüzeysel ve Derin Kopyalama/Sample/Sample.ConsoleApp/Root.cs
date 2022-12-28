using System.Text.Json;

public class Root
{
    public int Id { get; set; }
    public required Child Child { get; set; }

    public Root ShallowCopy()
    {
        return (Root)MemberwiseClone();
    }

    public Root DeepCopy()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<Root>(json)!;
    }
}

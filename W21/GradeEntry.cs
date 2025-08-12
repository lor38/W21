using System.Globalization;

public class GradeEntry
{
    public float value { get; set; }
    public DateTime dateAdded { get; set; }
    public string? comment { get; set; }

    public override string ToString()
    {
        return $"{value.ToString(CultureInfo.InvariantCulture)}|{dateAdded:yyyy-MM-dd HH:mm}|{comment}";
    }

    public static GradeEntry Parse(string line)
    {
        var parts = line.Split('|');
        return new GradeEntry
        {
            value = float.Parse(parts[0], CultureInfo.InvariantCulture),
            dateAdded = DateTime.Parse(parts[1]),
            comment = parts.Length > 2 ? parts[2] : null
        };
    }
}

using System.Text.Json.Serialization;

public class FeatureCollection
{
    [JsonPropertyName("features")]
    public EarthquakeFeature[] Features { get; set; }
}

public class EarthquakeFeature
{
    [JsonPropertyName("properties")]
    public FeatureProperties Properties { get; set; }
}

public class FeatureProperties
{
    [JsonPropertyName("place")]
    public string Place { get; set; }

    [JsonPropertyName("mag")]
    public double? Mag { get; set; }
}

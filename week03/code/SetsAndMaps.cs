using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;

public static class SetsAndMaps
{
    // ✅ Problem 1: FindPairs
    public static string[] FindPairs(string[] words)
    {
        var seen = new HashSet<string>();
        var results = new List<string>();

        foreach (var word in words)
        {
            if (word[0] == word[1]) continue;
            var reversed = new string(word.Reverse().ToArray());

            if (seen.Contains(reversed))
            {
                results.Add($"{word} & {reversed}");
            }

            seen.Add(word);
        }

        return results.ToArray();
    }

    // ✅ Problem 2: Summarize Degrees
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();

        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(',');

            if (fields.Length >= 4)
            {
                string degree = fields[3].Trim();

                if (!degrees.ContainsKey(degree))
                    degrees[degree] = 1;
                else
                    degrees[degree]++;
            }
        }

        return degrees;
    }

    // ✅ Problem 3: IsAnagram using Dictionary
    public static bool IsAnagram(string word1, string word2)
    {
        string Normalize(string s) => new string(
            s.ToLower().Where(char.IsLetterOrDigit).ToArray()
        );

        var a = Normalize(word1);
        var b = Normalize(word2);

        if (a.Length != b.Length) return false;

        var count = new Dictionary<char, int>();

        foreach (var c in a)
        {
            if (!count.ContainsKey(c)) count[c] = 0;
            count[c]++;
        }

        foreach (var c in b)
        {
            if (!count.ContainsKey(c)) return false;

            count[c]--;
            if (count[c] < 0)
                return false;
        }

        return true;
    }

    // ✅ Problem 5: EarthquakeDailySummary
    public static string[] EarthquakeDailySummary()
    {
        const string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";

        using var client = new HttpClient();
        using var response = client.Send(new HttpRequestMessage(HttpMethod.Get, url));
        using var jsonStream = response.Content.ReadAsStream();

        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        var data = JsonSerializer.Deserialize<FeatureCollection>(jsonStream, options);

        var result = new List<string>();

        if (data?.Features == null) return [];

        foreach (var feature in data.Features)
        {
            var place = feature.Properties?.Place;
            var mag = feature.Properties?.Mag;

            if (!string.IsNullOrEmpty(place) && mag.HasValue)
                result.Add($"{place} - Mag {mag.Value}");
        }

        return result.ToArray();
    }
}
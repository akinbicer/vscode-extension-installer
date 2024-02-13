using Newtonsoft.Json;

namespace VsCodeExtension.Models;

public class Extension
{
    [JsonProperty("identifier")] public Identifier? Identifier { get; set; }

    [JsonProperty("version")] public string? Version { get; set; }

    [JsonProperty("preRelease")] public bool? PreRelease { get; set; }

    [JsonProperty("pinned")] public bool? Pinned { get; set; }

    [JsonProperty("installed")] public bool? Installed { get; set; }
}
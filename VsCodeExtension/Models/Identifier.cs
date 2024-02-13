using Newtonsoft.Json;

namespace VsCodeExtension.Models;

public class Identifier
{
    [JsonProperty("id")] public string? Id { get; set; }

    [JsonProperty("uuid")] public string? Uuid { get; set; }
}
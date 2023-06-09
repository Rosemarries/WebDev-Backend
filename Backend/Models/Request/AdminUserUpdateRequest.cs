using System.Text.Json.Serialization;

namespace Backend.Models.Request;

public class AdminUserUpdateRequest
{
    [JsonPropertyName("username")]
    public string? Username { get; set; }
    [JsonPropertyName("password")]
    public string? Password { get; set; }
    
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("role")]
    public string? Role { get; set; }
    
    [JsonPropertyName("banned")]
    public bool? Banned { get; set; }
    
    [JsonPropertyName("deleted")]
    public bool? Deleted { get; set; }
    
    [JsonPropertyName("profile_image")]
    public string? ProfileImage { get; set; }
    
    [JsonPropertyName("student_id")]
    public string? StudentId { get; set; }
}
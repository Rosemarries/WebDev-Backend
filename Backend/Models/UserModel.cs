using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    
    [BsonElement("username")]
    public string Username { get; set; } = null!;
    
    [BsonElement("password")]
    [JsonIgnore]
    public string? Password { get; set; } = null!;

    [BsonElement("email")] 
    public string? Email { get; set; } = null!;
    
    [BsonElement("name")]
    [JsonPropertyName("name")]
    public string Name { get; set; } = "";
    
    [BsonElement("student_id")]
    [JsonPropertyName("student_id")]
    public string StudentId { get; set; } = null!;
    
    [BsonElement("role")]
    [JsonPropertyName("role")]
    public string? Role { get; set; } = "";

    [BsonElement("profile_image")]
    [JsonPropertyName("profile_image")]
    public string ProfileImage { get; set; } = "";

    [BsonElement("banned")]
    [JsonPropertyName("banned")]
    public bool Banned { get; set; } = false;

    [BsonElement("deleted")]
    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; } = false;
    
    [BsonElement("created_date")]
    [JsonPropertyName("created_date")]
    public DateTime? CreatedDate { get; set; } = DateTime.Now;
    
    [BsonElement("updated_date")]
    [JsonPropertyName("updated_date")]
    public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    public override string ToString()
    {
        return Username;
    }
}
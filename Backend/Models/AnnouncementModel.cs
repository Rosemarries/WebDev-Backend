using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Backend.Models;

public class Announcement
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = ObjectId.GenerateNewId().ToString();

    [BsonElement("content")]
    [JsonPropertyName("content")]
    public string Content { get; set; } = null!;

    [BsonElement("created_date")]
    [JsonPropertyName("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
}
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace memories.Domain.Models
{
    public class Memory
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public DateTimeOffset Date { get; set; } = DateTimeOffset.Now;
        public string Type { get; set; } = string.Empty;
        public string User { get; set; } = string.Empty;

    }
}
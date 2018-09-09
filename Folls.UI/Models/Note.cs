using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Folls.UI.Models
{
    public class Note
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        [BsonElement("text")]
        public string Text { get; set; }
    }
}
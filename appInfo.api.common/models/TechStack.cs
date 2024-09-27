using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace appInfo.api.common.models
{
    public class TechStack
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? _id { get; set; }
        public string? TechStackName { get; set; }

        public string? logo { get; set; }
    }
}
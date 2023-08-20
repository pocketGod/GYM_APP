using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace GYM_MODELS.DB
{
    public class ExcerciseDBRecord
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
    }
}
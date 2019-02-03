using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace language_server.Models {

    public class Word
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Native")]
        public string NativeWord { get; set; }
        
        [BsonElement("Foreign")]
        public string ForeignWord { get; set; }

        [BsonElement("NativePrefix")]
        public string NativePrefix { get; set; }

        [BsonElement("ForeignPrefix")]
        public string ForeignPrefix { get; set; }
        
    }
}
using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace webapi_signalr.Model
{
    public class Game
    {
        [BsonId]
        public ObjectId InternalId { get; set; }                // standard BSonId generated by MongoDb
        public string Id { get; set; }                          // external Id, easier to reference: 1,2,3 etc. 

        public string Gamecode {get; set;}
    }
}
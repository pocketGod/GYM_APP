using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.DB
{
    public class BaseDBRecord
    {
        /// <summary>
        /// MongoDB Assigned ObjectId
        /// </summary>
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
    }
}

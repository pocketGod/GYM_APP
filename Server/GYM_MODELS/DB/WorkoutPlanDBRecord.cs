using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.DB
{
    public class WorkoutPlanDBRecord : BaseDBRecord
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string OwnerUserId { get; set; }
        public string PlanName { get; set; }
        public List<ObjectId> Workouts { get; set; }
    }



}

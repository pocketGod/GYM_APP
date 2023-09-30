using GYM_MODELS.DB;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace GYM_DB.Tools.CustomSerializers
{
    public class WorkoutPlanInnerWorkoutDBRecordSerializer : IBsonSerializer<WorkoutPlanInnerWorkoutDBRecord>
    {
        public Type ValueType => typeof(WorkoutPlanInnerWorkoutDBRecord);

        public WorkoutPlanInnerWorkoutDBRecord Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            var reader = context.Reader;
            reader.ReadStartDocument();

            string id = null;
            DateTimeOffset? lastRecord = null;

            while (reader.ReadBsonType() != BsonType.EndOfDocument)
            {
                var fieldName = reader.ReadName();
                var currentBsonType = reader.GetCurrentBsonType();

                if (fieldName == "Id" && currentBsonType == BsonType.ObjectId)
                {
                    id = reader.ReadObjectId().ToString();
                }
                else if (fieldName == "Id" && currentBsonType == BsonType.String)
                {
                    id = reader.ReadString();
                }
                else if (fieldName == "LastRecord" && currentBsonType == BsonType.DateTime)
                {
                    var lastRecordTicks = reader.ReadDateTime();
                    lastRecord = DateTimeOffset.FromUnixTimeMilliseconds(lastRecordTicks);
                }
                else
                {
                    reader.SkipValue();
                }
            }

            reader.ReadEndDocument();

            if (id == null || lastRecord == null)
            {
                throw new InvalidOperationException("Id and LastRecord fields must be present.");
            }

            return new WorkoutPlanInnerWorkoutDBRecord { Id = id, LastRecord = lastRecord.Value.DateTime };
        }


        public void Serialize(BsonSerializationContext context, BsonSerializationArgs args, WorkoutPlanInnerWorkoutDBRecord value)
        {
            var writer = context.Writer;
            writer.WriteStartDocument();
            writer.WriteString("Id", value.Id);

            var lastRecordTicks = new DateTimeOffset(value.LastRecord).ToUnixTimeMilliseconds();
            writer.WriteDateTime("LastRecord", lastRecordTicks);

            writer.WriteEndDocument();
        }

        void IBsonSerializer.Serialize(BsonSerializationContext context, BsonSerializationArgs args, object value)
        {
            Serialize(context, args, (WorkoutPlanInnerWorkoutDBRecord)value);
        }

        object IBsonSerializer.Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
        {
            return Deserialize(context, args);
        }
    }
}

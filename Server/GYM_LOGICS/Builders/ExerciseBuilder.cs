using GYM_MODELS.Client;
using GYM_MODELS.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Builders
{
    public class ExerciseBuilder
    {
        public Exercise Build(ExerciseDBRecord dbRecord)
        {
            Exercise clientModel = new()
            {
                Id = dbRecord._id,
                Name = dbRecord.Name,
                ImageUrl = dbRecord.Image,
                TargetMuscle = dbRecord.TargetMuscle,
                IncludedMuscles = dbRecord.IncludedMuscles,
                Equipment = dbRecord.Equipment,
                PossibleEquipments = dbRecord.PossibleEquipment,
                Difficulty = dbRecord.Difficulty
            };

            return clientModel;
        }
    }
}

using GYM_MODELS.DB;
using GYM_MODELS.Enums.Anatomy;
using GYM_MODELS.Enums.Common;
using GYM_MODELS.Enums.Gym;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Client
{
    public class Exercise
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public Muscles TargetMuscle { get; set; }
        public List<Muscles> IncludedMuscles { get; set; }
        public EquipmentTypes Equipment { get; set; }
        public List<EquipmentTypes> PossibleEquipments { get; set; }
        public DifficultyLevels Difficulty { get; set; }
    }

    public class ExerciseByMuscleResponse
    {
        public List<Exercise> Target { get; set; }
        public List<Exercise> Included { get; set; }
    
    }
}

using GYM_LOGICS.Builders;
using GYM_LOGICS.Extensions;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutBuilder;
using GYM_MODELS.DB;
using GYM_MODELS.Settings.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_LOGICS.Services
{
    public class WorkoutService
    {
        private readonly string _collectionName = "Workouts";
        private readonly IMongoCollection<WorkoutDBRecord> _workouts;
        private readonly WorkoutBuilder _workoutBuilder;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PropertiesService _propertiesService;
        private readonly ExerciseService _exerciseService;

        public WorkoutService(
            IMongoDatabase database, 
            WorkoutBuilder workoutBuilder, 
            IHttpContextAccessor httpContextAccessor,
            PropertiesService propertiesService,
            ExerciseService exerciseService
            )
        {
            _workouts = database.GetCollection<WorkoutDBRecord>(_collectionName);
            _workoutBuilder = workoutBuilder;
            _httpContextAccessor = httpContextAccessor;
            _propertiesService = propertiesService;
            _exerciseService = exerciseService;
        }


        public List<Workout> GetAllMyWorkouts()
        {
            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"] as string;
            var dbRecords = _workouts.Find(workout => workout.OwnerUserId == connectedUserId).ToList();
            return dbRecords.Select(_workoutBuilder.Build).ToList();
        }

        public WorkoutBuilderPropertiesResponse GetWorkoutBuildingProperties()
        {
            List<EnumPropertiesGroupModel> enums = _propertiesService.GetAllEnums();

            if (enums.IsNullOrEmpty()) return null;

            List<EnumPropertiesModel> workoutEnums = enums.FirstOrDefault((en)=> en.GroupName == EnumGroups.Workout.ToString()).Enums;

            List<Dictionary<string, List<Exercise>>> exercises = _exerciseService.GetAllExercises().GroupExercisesByTargetMuscle();

            WorkoutBuilderPropertiesResponse response = new()
            {
                Exercises= exercises,
                WorkoutProperties = workoutEnums
            };


            return response;
        }



     
    }
}

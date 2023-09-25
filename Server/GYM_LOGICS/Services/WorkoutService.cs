using GYM_LOGICS.Builders;
using GYM_LOGICS.Extensions;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutCreator;
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

            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();

            List<WorkoutDBRecord> dbRecords = _workouts.Find(workout => workout.OwnerUserId == connectedUserId).ToList();
            return dbRecords.Select(_workoutBuilder.BuildForClient).ToList();
        }

        public Workout GetWorkoutById(string id)
        {
            WorkoutDBRecord dbRecord = _workouts.Find(wo => wo._id == id).ToList().FirstOrDefault();
            return _workoutBuilder.BuildForClient(dbRecord);
        }



        public WorkoutCreatorPropertiesResponse GetWorkoutCreationProperties()
        {
            List<EnumPropertiesGroupModel> enums = _propertiesService.GetAllEnums();

            if (enums.IsNullOrEmpty()) return null;

            List<EnumPropertiesModel> workoutEnums = enums.FirstOrDefault((en)=> en.GroupName == EnumGroups.Workout.ToString()).Enums;

            List<Dictionary<string, List<Exercise>>> exercises = _exerciseService.GetAllExercises().GroupExercisesByTargetMuscle();

            WorkoutCreatorPropertiesResponse response = new()
            {
                Exercises= exercises,
                WorkoutProperties = workoutEnums
            };


            return response;
        }

        public bool AddNewWorkoutToCollection(NewWorkoutSchema newWorkout)
        {
            try
            {

                if (!newWorkout.IsNewWorkoutValid()) return false;

                string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();

                WorkoutDBRecord workoutDBRecord = _workoutBuilder.BuildNewWorkout(newWorkout, connectedUserId);

                _workouts.InsertOne(workoutDBRecord);
                // If the record was not inserted in the DB successfully than the code will jump to the catch block

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool EditWorkoutInCollection(NewWorkoutSchema newWorkout)
        {
            try
            {
                if (!newWorkout.IsNewWorkoutValid(false)) return false;

                string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();

                WorkoutDBRecord originalWorkout = _workouts.Find(w => w._id == newWorkout.WorkoutId && w.OwnerUserId == connectedUserId).FirstOrDefault();

                if (originalWorkout == null) return false;

                WorkoutDBRecord workoutDBRecord = _workoutBuilder.BuildNewWorkout(newWorkout, connectedUserId);

                workoutDBRecord._id = originalWorkout._id;

                FilterDefinition<WorkoutDBRecord> filter = Builders<WorkoutDBRecord>.Filter.Eq(w => w._id, newWorkout.WorkoutId) &
                    Builders<WorkoutDBRecord>.Filter.Eq(w => w.OwnerUserId, connectedUserId);

                ReplaceOneResult result = _workouts.ReplaceOne(filter, workoutDBRecord);

                // Check if a document was actually modified
                return result.ModifiedCount > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }




    }
}

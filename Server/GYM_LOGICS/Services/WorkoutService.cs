using GYM_DB.Repositories;
using GYM_LOGICS.Builders;
using GYM_LOGICS.Extensions;
using GYM_MODELS.Client;
using GYM_MODELS.Client.WorkoutCreator;
using GYM_MODELS.DB;
using GYM_MODELS.Settings.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace GYM_LOGICS.Services
{
    public class WorkoutService
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly WorkoutBuilder _workoutBuilder;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PropertiesService _propertiesService;
        private readonly ExerciseService _exerciseService;

        public WorkoutService(
            IWorkoutRepository workoutRepository,
            WorkoutBuilder workoutBuilder,
            IHttpContextAccessor httpContextAccessor,
            PropertiesService propertiesService,
            ExerciseService exerciseService)
        {
            _workoutRepository = workoutRepository;
            _workoutBuilder = workoutBuilder;
            _httpContextAccessor = httpContextAccessor;
            _propertiesService = propertiesService;
            _exerciseService = exerciseService;
        }

        public List<Workout> GetAllMyWorkouts()
        {
            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();
            List<WorkoutDBRecord> dbRecords = _workoutRepository.GetWorkoutsByOwner(connectedUserId);
            return dbRecords.Select(_workoutBuilder.BuildForClient).ToList();
        }

        public Workout GetWorkoutById(string id)
        {
            WorkoutDBRecord dbRecord = _workoutRepository.GetWorkoutById(id);
            return _workoutBuilder.BuildForClient(dbRecord);
        }

        public WorkoutCreatorPropertiesResponse GetWorkoutCreationProperties()
        {
            List<EnumPropertiesGroupModel> enums = _propertiesService.GetAllEnums();
            if (enums.IsNullOrEmpty()) return null;

            List<EnumPropertiesModel> workoutEnums = enums.FirstOrDefault(en => en.GroupName == EnumGroups.Workout.ToString()).Enums;
            List<Dictionary<string, List<Exercise>>> exercises = _exerciseService.GetAllExercises().GroupExercisesByTargetMuscle();

            return new WorkoutCreatorPropertiesResponse
            {
                Exercises = exercises,
                WorkoutProperties = workoutEnums
            };
        }

        public bool AddNewWorkoutToCollection(NewWorkoutSchema newWorkout)
        {
            if (!newWorkout.IsNewWorkoutValid()) return false;

            string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();
            WorkoutDBRecord workoutDBRecord = _workoutBuilder.BuildNewWorkout(newWorkout, connectedUserId);

            return _workoutRepository.InsertOne(workoutDBRecord);
        }

        public bool EditWorkoutInCollection(NewWorkoutSchema newWorkout)
        {
            try
            {
                if (!newWorkout.IsNewWorkoutValid(false)) return false;

                string connectedUserId = _httpContextAccessor.HttpContext.Items["UserId"].ToString();

                WorkoutDBRecord originalWorkout = _workoutRepository.GetWorkoutById(newWorkout.WorkoutId);

                if (originalWorkout == null || originalWorkout.OwnerUserId != connectedUserId) return false;

                WorkoutDBRecord workoutDBRecord = _workoutBuilder.BuildNewWorkout(newWorkout, connectedUserId);

                workoutDBRecord._id = originalWorkout._id;

                return _workoutRepository.ReplaceOne(newWorkout.WorkoutId, workoutDBRecord);
            }
            catch (Exception)
            {
                return false;
            }
        }


    }

}

using GYM_LOGICS.Services;
using GYM_MODELS.Client.WorkoutCreator;
using GYM_MODELS.Settings.Properties;

namespace GYM_LOGICS.Managers
{
    public class PropertiesManager
    {
        private readonly PropertiesService _propertiesService;
        private readonly WorkoutService _workoutService;

        public PropertiesManager(PropertiesService propertiesSeervice, WorkoutService workoutService)
        {
            _propertiesService = propertiesSeervice;
            _workoutService = workoutService;

        }

        /// <summary>
        /// Asynchronously retrieves all available properties
        /// </summary>
        /// <returns>A Task containing a list of all Enum-properties-group-model</returns>
        public List<EnumPropertiesGroupModel> GetEnumsProperties()
        {
            return _propertiesService.GetAllEnums();
        }



        /// <summary>
        /// Asynchronously retrieves properties required for creating a workout.
        /// </summary>
        /// <returns>A Task containing a response object with necessary properties for creating a workout.</returns>
        public Task<WorkoutCreatorPropertiesResponse> GetWorkoutCreatorProperties()
        {
            return Task.FromResult(_workoutService.GetWorkoutCreationProperties());
        }



    }
}

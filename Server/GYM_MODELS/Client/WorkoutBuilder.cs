using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Client.WorkoutBuilder
{
    /// <summary>
    /// Initial response containing the clients properties and options for builing a workout
    /// </summary>
   public class WorkoutBuilderPropertiesResponse
    {
        public List<EnumPropertiesModel> WorkoutProperties { get; set; }

        public List<Dictionary<string, List<Exercise>>> Exercises { get; set; }
    }
}

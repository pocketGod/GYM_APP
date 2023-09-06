using GYM_LOGICS.Services;
using GYM_MODELS.Enums.Anatomy;
using GYM_MODELS.Enums.Exercise;
using GYM_MODELS.Settings.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GYM_LOGICS.Managers
{
    public class PropertiesManager
    {
        private readonly PropertiesService _propertiesService;
        public PropertiesManager(PropertiesService propertiesSeervice)
        {
            _propertiesService = propertiesSeervice;
        }

        /// <summary>
        /// Asynchronously retrieves all available properties
        /// </summary>
        /// <returns>A Task containing a list of all Enum-properties-group-model</returns>
        public List<EnumPropertiesGroupModel> GetEnumsProperties()
        {
            return _propertiesService.GetAllEnums();
        }



    }
}

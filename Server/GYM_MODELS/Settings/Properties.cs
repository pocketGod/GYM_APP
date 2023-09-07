using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Settings.Properties
{

    #region Enums

    /// <summary>
    /// Attribute for specifying the group of an enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public class EnumGroupAttribute : Attribute
    {
        /// <summary>
        /// Name of the group.
        /// </summary>
        public string GroupName { get; }

        public EnumGroupAttribute(string groupName)
        {
            GroupName = groupName;
        }
    }

    /// <summary>
    /// Attribute for specifying the title of an enum.
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum, Inherited = false)]
    public class EnumTitleAttribute : Attribute
    {
        /// <summary>
        /// Title of the enum.
        /// </summary>
        public string Title { get; }

        public EnumTitleAttribute(string title)
        {
            Title = title;
        }
    }

    public class EnumPropertiesGroupModel
    {
        /// <summary>
        /// Name of the enum group.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// List of enums in the group.
        /// </summary>
        public List<EnumPropertiesModel> Enums { get; set; }
    }

    public class EnumPropertiesModel
    {
        /// <summary>
        /// Used Enum Name
        /// </summary>
        public string EnumName { get; set; }

        /// <summary>
        /// List Of Enum Values
        /// </summary>
        public List<EnumPropertiesValueModel> EnumValues { get; set; }
    }

    public class EnumPropertiesValueModel
    {
        /// <summary>
        /// Propert String Value
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Property int value
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Property Description
        /// </summary>
        public string Summary { get; set; }
    }


    public enum EnumGroups
    {
        Workout,
        User,
        General
    }


    #endregion

}

using GYM_MODELS.Enums.Anatomy;
using GYM_MODELS.Enums.Common;
using GYM_MODELS.Enums.Exercise;
using GYM_MODELS.Enums.Gym;
using GYM_MODELS.Enums.User;
using GYM_MODELS.Enums.Workout;
using GYM_MODELS.Settings.Properties;
using System.Reflection;
using System.Xml.Linq;
using System.Xml.XPath;

namespace GYM_LOGICS.Services
{
    public class PropertiesService
    {

        #region Enums Section

        private XDocument _gymModelsXmlDoc = XDocument.Load("..\\GYM_MODELS\\obj\\Debug\\net6.0\\GYM_MODELS.xml");

        public List<EnumPropertiesGroupModel> GetAllEnums()
        {
            Assembly _gymModelsEnumAssembly = typeof(WorkoutGoals).Assembly; //example enum to select the relevant assembly (since this is a multi csproj solution)

            IEnumerable<Type> enumTypes = _gymModelsEnumAssembly.GetTypes()
                                    .Where(t => t.IsEnum && t.GetCustomAttribute<EnumGroupAttribute>() != null);


            List<EnumPropertiesGroupModel> groupedEnums = enumTypes.GroupBy(
                e => e.GetCustomAttribute<EnumGroupAttribute>().GroupName,
                e => e,
                (key, enums) => new EnumPropertiesGroupModel
                {
                    GroupName = key,
                    Enums = enums.Select(e => GetEnumModel(e)).ToList()
                }).ToList();

            return groupedEnums;
        }

        private EnumPropertiesModel GetEnumModel(Type enumType)
        {
            string? enumTitle = enumType.GetCustomAttribute<EnumTitleAttribute>()?.Title ?? enumType.Name;

            return new EnumPropertiesModel
            {
                EnumName = enumTitle,
                EnumValues = Enum.GetValues(enumType)
                                 .Cast<object>()
                                 .Select(e => new EnumPropertiesValueModel
                                 {
                                     Name = e.ToString(),
                                     Value = (int)e,
                                     Summary = GetEnumSummary(enumType, e.ToString())
                                 }).ToList()
            };
        }

        private string GetEnumSummary(Type enumType, string name)
        {
            MemberInfo memberInfo = enumType.GetMember(name).FirstOrDefault();
            if (memberInfo != null)
            {
                string xmlPath = $"{memberInfo.DeclaringType.FullName}.{memberInfo.Name}";
                XElement summaryElement = _gymModelsXmlDoc.XPathSelectElement($"/doc/members/member[@name='F:{xmlPath}']/summary");

                return summaryElement?.Value.Trim() ?? string.Empty;
            }

            return string.Empty;
        }

        #endregion
    }
}

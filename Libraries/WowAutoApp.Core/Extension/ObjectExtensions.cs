using System.ComponentModel.DataAnnotations;
using System.Resources;

namespace WowAutoApp.Core.Extension
{
    public static class ObjectExtensions
    {
        public static string GetDisplayValue(this object value)
        {
            var fieldInfo = value?.GetType().GetField(value.ToString());
            var descriptionAttributes =
                fieldInfo?.GetCustomAttributes(typeof(DisplayAttribute), false) as DisplayAttribute[];

            if (descriptionAttributes == null) return string.Empty;
            if (descriptionAttributes.Length == 0) return value.ToString();

            var name = descriptionAttributes[0].Name;
            var resourceType = descriptionAttributes[0].ResourceType;

            return resourceType == null
                ? name
                : new ResourceManager(resourceType.FullName, resourceType.Assembly).GetString(name);
        }
    }
}

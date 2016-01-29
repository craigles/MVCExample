using System;
using System.ComponentModel;
using System.Linq;

namespace Craig.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum element)
        {
            var type = element.GetType();
            var memInfo = type.GetMember(element.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Any())
                return ((DescriptionAttribute)attributes[0]).Description;

            return element.ToString();
        }
    }
}
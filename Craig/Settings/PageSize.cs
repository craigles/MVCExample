using System.Collections.Generic;
using ConfigInjector;

namespace Craig.Settings
{
    public class PageSize : ConfigurationSetting<int>
    {
        protected override IEnumerable<string> ValidationErrors(int value)
        {
            if (value < 1) yield return "Page size cannot be less than 1.";
        }
    }
}
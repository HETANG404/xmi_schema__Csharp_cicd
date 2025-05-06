using System.Reflection;
using XmiSchema.Core.Enums;

namespace XmiSchema.Core.Handlers;
public static class ExtensionEnumHelper
{
    public static TEnum? FromEnumValue<TEnum>(string value) where TEnum : struct, Enum
    {
        foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var attribute = field.GetCustomAttribute<EnumValueAttribute>();
            if (attribute != null && attribute.Value.Equals(value, StringComparison.OrdinalIgnoreCase))
            {
                var enumValue = field.GetValue(null);
                if (enumValue is TEnum typedValue)
                {
                    return typedValue;
                }
            }
        }

        return null;
    }
}

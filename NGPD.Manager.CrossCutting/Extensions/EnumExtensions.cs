using System.ComponentModel;
using System.Globalization;

namespace NGPD.Manager.CrossCutting.Extensions;

public static class EnumExtensions
{
    public static string GetEnumDescription(this Enum @enum)
    {
        var type = @enum.GetType();

        var memberInfo = type.GetMember(@enum.ToString());

        if (memberInfo != null && memberInfo.Length > 0)
        {
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }
        }
        return @enum.ToString();
    }

    public static string GetDescription<T>(this T e) where T : IConvertible
    {
        string description = null;

        if (e is Enum)
        {
            Type type = e.GetType();
            Array values = System.Enum.GetValues(type);

            foreach (int val in values)
            {
                if (val == e.ToInt32(CultureInfo.InvariantCulture))
                {
                    var memInfo = type.GetMember(type.GetEnumName(val));
                    var descriptionAttributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (descriptionAttributes.Length > 0)
                    {
                        description = ((DescriptionAttribute)descriptionAttributes[0]).Description;
                    }

                    break;
                }
            }
        }

        return description;
    }
}
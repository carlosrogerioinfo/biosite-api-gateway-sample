using Biosite.Core.Enums;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Biosite.Core.Extensions
{
    public static class StringExtensionTools
    {

        public static string OnlyNumbers(this string str, string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        public static string GetDescription(this PrescriptionType value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
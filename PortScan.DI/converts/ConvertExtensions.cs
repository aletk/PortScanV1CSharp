using System;
using System.ComponentModel;


namespace PortScan.Converts
{

    public static class ConvertExtentions
    {
        /// <summary>
        /// Realiza conversão de tipos, evitando null reference. 
        /// </summary>
        public static T To<T>(this object value)
        {
            var conversionType = typeof(T);
            return (T)To(value, conversionType);
        }

        public static object To(this object value, Type conversionType)
        {
            if (conversionType == null)
                throw new ArgumentNullException("conversionType");

            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                if (value == null || Convert.IsDBNull(value))
                    return null;

                var nullableConverter = new NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }
            else if (conversionType == typeof(Guid))
            {
                return new Guid(value.ToString());
            }

            else if (conversionType.IsEnum && value is string @string)
            {
                return Enum.Parse(conversionType, @string);
            }

            if ((value is string || value == null || value is DBNull) &&
                (conversionType == typeof(short) ||
                conversionType == typeof(int) ||
                conversionType == typeof(long) ||
                conversionType == typeof(double) ||
                conversionType == typeof(decimal) ||
                conversionType == typeof(float)))
            {
                if (!decimal.TryParse(value as string, out _))
                    value = "0";
            }

            if (conversionType == typeof(bool) && (value == null || value is DBNull))
            {
                value = 0;
            }

            if (conversionType == typeof(DateTime) && (value == null || value is DBNull))
            {
                value = DateTime.MinValue;
            }

            return Convert.ChangeType(value, conversionType);
        }

    }
}
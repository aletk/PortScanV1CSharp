using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace PortScan.Converts
{
    internal static class EnumExtensions
    {

        /// <summary>
        /// Retorna a descrição de um enum caso tenha sido criado. 
        /// </summary>
        public static string GetDescription(this Enum value)
        {
            FieldInfo field = value.GetType().GetField(value.ToString().To<string>());

            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();

            if(attribute == null)
            {
                return value.ToString();
            }

            return attribute.Description;
        }

    }
}

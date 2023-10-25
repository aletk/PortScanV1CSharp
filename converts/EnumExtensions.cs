﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PortScan.Converts
{
    internal static class EnumExtensions
    {
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

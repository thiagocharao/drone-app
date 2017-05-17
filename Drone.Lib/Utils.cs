﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace DroneApp.Lib
{
    public static class Utils
    {
        public class StringValueAttribute : Attribute
        {
			public string StringValue { get; protected set; }
            public StringValueAttribute(string value)
            {
                this.StringValue = value;
            }
        }
       
        public static string GetStringValue(this Enum value)
        {
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(typeof(StringValueAttribute), false) as StringValueAttribute[];
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }
    }
}

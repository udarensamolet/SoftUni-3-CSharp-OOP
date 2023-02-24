﻿using System.ComponentModel;
using System.Linq;
using System.Reflection;
using ValidationAttributes.Models.Attributes;

namespace ValidationAttributes.Models
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property
                    .GetCustomAttributes()
                    .Where(x => x.GetType().IsSubclassOf(typeof(MyValidationAttribute)))
                    .ToArray();

                foreach(MyValidationAttribute attribute in attributes)
                {
                    bool isValid = attribute.IsValid(property.GetValue(obj));
                    if(!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

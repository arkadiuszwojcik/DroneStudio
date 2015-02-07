using System;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;

namespace DroneStudio.Library.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<TAttribute> GetFieldsAttributes<TAttribute>(this Type type)
        {
            IList<TAttribute> attributes = new List<TAttribute>();

            foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic))
            {
                var attr = field.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault();
                if (attr != null) attributes.Add((TAttribute)attr);
            }

            return attributes;
        }
    }
}

using ExHentaiApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Expressions
{
    public static class ModelExpressions
    {
        public static string GetEnumDisplayName(this Enum value)
        {
            var type = value.GetType();
            var field = type.GetField(value.ToString());
            var attr = field.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            if (attr == null)
            {
                return type.Name;
            }
            return attr.Name;
        }

        public static int ContainsCategory(this Categories categories, Categories category)
        {
            return ((categories & category) == category) ? 1 : 0;
        }

        public static string ReadToString(this Stream stream)
        {
            using (stream)
            using (StreamReader streamRead = new StreamReader(stream))
            {
                return streamRead.ReadToEnd();
            }
        }
    }
}

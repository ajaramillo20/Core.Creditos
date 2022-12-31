using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.Creditos.Helpers
{
    /// <summary>
    /// Clase general de helpers
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Convierte un objeto a json
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        public static string ToJson(this object objeto)
        {
            return JsonConvert.SerializeObject(objeto);
        }

        /// <summary>
        /// Inyecta variables en un string
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="injectionObject"></param>
        /// <returns></returns>
        public static string Inject(this string formatString, object injectionObject)
        {
            return formatString.Inject(GetPropertyHash(injectionObject));
        }

        /// <summary>
        /// Inserta variables en un string
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string Inject(this string formatString, IDictionary dictionary)
        {
            return formatString.Inject(new Hashtable(dictionary));
        }

        /// <summary>
        /// Inserta variables en un string
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string Inject(this string formatString, Hashtable attributes)
        {
            string text = formatString;
            if (attributes == null || formatString == null)
            {
                return text;
            }

            foreach (string key in attributes.Keys)
            {
                text = text.InjectSingleValue(key, attributes[key]);
            }

            return text;
        }

        /// <summary>
        /// Inserta variables en un string
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        public static string InjectSingleValue(this string formatString, string key, object replacementValue)
        {
            string text = formatString;
            Regex regex = new Regex("{(" + key + ")(?:}|(?::(.[^}]*)}))");
            foreach (Match item in regex.Matches(formatString))
            {
                string text2 = item.ToString();
                if (item.Groups[2].Length > 0)
                {
                    string format = string.Format(CultureInfo.InvariantCulture, "{{0:{0}}}", item.Groups[2]);
                    text2 = string.Format(CultureInfo.CurrentCulture, format, replacementValue);
                }
                else
                {
                    text2 = (replacementValue ?? string.Empty).ToString();
                }

                text = text.Replace(item.ToString(), text2);
            }

            return text;
        }

        /// <summary>
        /// Inserta variables en un string
        /// </summary>
        /// <param name="formatString"></param>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        private static Hashtable GetPropertyHash(object properties)
        {
            Hashtable hashtable = null;
            if (properties != null)
            {
                hashtable = new Hashtable();
                PropertyDescriptorCollection properties2 = TypeDescriptor.GetProperties(properties);
                foreach (PropertyDescriptor item in properties2)
                {
                    hashtable.Add(item.Name, item.GetValue(properties));
                }
            }

            return hashtable;
        }
    }
}

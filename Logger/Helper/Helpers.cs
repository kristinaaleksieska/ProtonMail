using NUnit.Framework.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Helper
{
    public static class Helpers
    {
        private static Dictionary<string, object> _dict = new Dictionary<string, object>();

        public static T GetValue<T>(this IPropertyBag properties, string key) where T : class
        {
            _dict.Clear();

            foreach (var propeprtyBagKey in properties.Keys)
            {

                _dict[propeprtyBagKey] = properties.Get(propeprtyBagKey);
            }

            object obj;
            if (_dict != null && _dict.TryGetValue(key, out obj) && _dict.Count > 0)
            {
                return _dict[key] as T;
            }
            return null;
        }

        public static string GetRGBFromColorCode(string colorCode)
        {
            Color hashColor = ColorTranslator.FromHtml(colorCode);

            return $"rgb({hashColor.R}, {hashColor.G}, {hashColor.B})";
        }


    }
}

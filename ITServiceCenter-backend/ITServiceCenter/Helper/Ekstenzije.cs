using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FIT_Api_Examples.Helper
{
    public static class Ekstenzije
    {
        public static string RemoveTags(this string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public static List<T> GetRandomElements<T>(this IEnumerable<T> list, int elementsCount)
        {
            return list.OrderBy(arg => Guid.NewGuid()).Take(elementsCount).ToList();
        }

        public static byte[] ParsirajBase64(this string base64string)
        {
            if (base64string != null)
            {
            if (!base64string.StartsWith("data:image/png;base64,"))
            {
                base64string = $"data:image/png;base64,{base64string}";
            }

            base64string = base64string.Split(',')[1];
            return System.Convert.FromBase64String(base64string);
            }

            else
            {
                return Fajlovi.Ucitaj("wwwroot/profile_images/empty.png");
            }
        }

        public static string ToBase64 (this byte[] bajtovi)
        {
            return System.Convert.ToBase64String(bajtovi);
        }
    }
}

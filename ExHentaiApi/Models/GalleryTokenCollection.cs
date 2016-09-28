using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    public class GalleryTokenCollection : List<GalleryToken>
    {

        private static Regex rCount = new Regex(Definitions.PageShowingPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);
        private static Regex rGallery = new Regex(Definitions.GalleryUrlPattern, RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static GalleryTokenCollection CreateByHtml(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                return null;
            }

            var list = new GalleryTokenCollection();

            Match m = rCount.Match(data);
            if (m.Success)
            {
                try
                {
                    list.ShowingStart = Convert.ToInt32(m.Groups[1].Value.Replace(",", ""));
                    list.ShowingEnd = Convert.ToInt32(m.Groups[2].Value.Replace(",", ""));
                    list.SearchCount = Convert.ToInt32(m.Groups[3].Value.Replace(",", ""));
                    list.PageCount = Convert.ToInt32(Math.Ceiling((double)list.SearchCount / 25));
                }
                catch
                {
                    list.ShowingStart = list.ShowingEnd = list.SearchCount = 0;
                }
            }

            m = rGallery.Match(data);
            while (m.Success)
            {
                try
                {
                    GalleryToken token = new GalleryToken(int.Parse(m.Groups[2].Value), m.Groups[3].Value);
                    if (!list.Contains(token))
                    {
                        list.Add(token);
                    }
                }
                catch
                {
                    continue;
                }

                m = m.NextMatch();
            }

            return list;
        }

        public int ShowingStart { get; internal set; }
        public int ShowingEnd { get; internal set; }
        public int SearchCount { get; internal set; }
        public int PageCount { get; internal set; }
    }
}

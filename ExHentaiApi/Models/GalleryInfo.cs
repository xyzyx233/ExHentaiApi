using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    public class GalleryInfo
    {
        public override string ToString()
        {
            return this.Title;
        }

        public GalleryToken token { get; internal set; }
        public string ArchiverKey { get; internal set; }
        public DateTime ArchiverKeyTime { get; internal set; }
        public DateTime ArchiverKeyTimeUTC { get; internal set; }
        public string Title { get; internal set; }
        public string TitleJpn { get; internal set; }
        public Categories Category { get; internal set; }
        public string ThumbURL { get; internal set; }
        public string ThumbPath { get; set; }
        public string Uploader { get; internal set; }
        public DateTime PostedUTC { get; internal set; }
        public DateTime Posted { get; internal set; }
        public int FileCount { get; internal set; }
        public long FileSize { get; internal set; }
        public bool Expunged { get; internal set; }
        public float Rating { get; internal set; }
        public int TorrentCount { get; internal set; }
        public string error { get; internal set; }
        public string[] Tags { get; internal set; }
    }
}

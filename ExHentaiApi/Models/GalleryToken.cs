using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    public class GalleryToken
    {
        public GalleryToken(int gid, string token)
        {
            this.gid = gid;
            this.token = token;
        }

        public int gid { get; internal set; }

        public string token { get; internal set; }

        public static bool operator ==(GalleryToken a, GalleryToken b)
        {
            if (Object.ReferenceEquals(a, b))
                return true;

            if (((object)a == null) || ((object)b == null))
                return false;

            return ((a.gid == b.gid) && (a.token == b.token));
        }

        public static bool operator !=(GalleryToken a, GalleryToken b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            GalleryToken p = obj as GalleryToken;
            if ((Object)p == null)
                return false;

            return (this.gid == p.gid) && (this.token == p.token);
        }

        public bool Equals(GalleryToken obj)
        {
            if ((object)obj == null)
                return false;

            return (this.gid == obj.gid) && (this.token == obj.token);
        }

        public override int GetHashCode()
        {
            return (this.gid ^ this.token.GetHashCode());
        }

        public override string ToString()
        {
            return string.Format("{0}/{1}", this.gid, this.token);
        }


        public byte[] GetBytes()
        {
            return Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(new ExHentaiRequestModel()
            {
                method = "gdata",
                gidlist = new string[][] { new string[] { this.gid.ToString(), this.token } }
            }));
        }
    }
}

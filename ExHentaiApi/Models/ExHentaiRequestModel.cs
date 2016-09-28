using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    public class ExHentaiRequestModel
    {
        public string method { get; set; }
        public string[][] gidlist { get; set; }
        public string[][] pagelist { get; set; }
        public int gid { get; set; }
        public int page { get; set; }
        public string imgkey { get; set; }
        public string showkey { get; set; }
    }
}

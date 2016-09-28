using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    [Flags]
    public enum Categories : short
    {
        [Display(Name = "None")]
        None = 0x000,
        [Display(Name = "Doujinshi")]
        Doujinshi = 0x001,
        [Display(Name = "Manga")]
        Manga = 0x002,
        [Display(Name = "Artist CG")]
        ArtistCG = 0x004,
        [Display(Name = "Game CG")]
        GameCG = 0x008,
        [Display(Name = "Westorn")]
        Western = 0x010,
        [Display(Name = "Non H")]
        NonH = 0x020,
        [Display(Name = "Image Sets")]
        ImageSets = 0x040,
        [Display(Name = "Cosplay")]
        Cosplay = 0x080,
        [Display(Name = "Asian Porn")]
        AsianPorn = 0x100,
        [Display(Name = "Mics")]
        Misc = 0x200,
        [Display(Name = "Private")]
        Private = 0x400,
        [Display(Name = "All")]
        All = 0x7FF
    }
}

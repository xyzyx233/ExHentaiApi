using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi
{
    public class Definitions
    {
        static Definitions()
        {
            #region --- Url ---
            E_HentaiWebsiteUrl = @"http://g.e-hentai.org/";
            ExHentaiWebsiteUrl = @"https://exhentai.org/";
            E_HentaiApiUrl = @"http://g.e-hentai.org/api.php";
            ExHentaiApiUrl = @"https://exhentai.org/api.php";
            LoginUrl = @"https://forums.e-hentai.org/index.php?act=Login&CODE=01"; 
            #endregion

            #region --- Pattern ---
            LoginInfoPattern = "returntype=8&CookieDate=1&b=d&bt=pone&UserName={0}&PassWord={1}&ipb_login_submit=Login%21";
            LoginMemberIdPattern = "ipb_member_id=([^;]+);";
            LoginPassHashPattern = "ipb_pass_hash=([^;]+);";

            PageShowingPattern = "Showing ([0-9,]+)-([0-9,]+) of ([0-9,]+)";
            GalleryUrlPattern = "(http|https)://[^/\"]+/g/([^/\"]+)/([^/\"]+)/";
            #endregion
        }

        #region --- Url ---
        /// <summary>
        /// E-Hentai 網址
        /// </summary>
        public static string E_HentaiWebsiteUrl { get; set; }

        /// <summary>
        /// ExHentai 網址
        /// </summary>
        public static string ExHentaiWebsiteUrl { get; set; }

        /// <summary>
        /// E-Hentai API 網址
        /// </summary>
        public static string E_HentaiApiUrl { get; set; }

        /// <summary>
        /// ExHentai API 網址
        /// </summary>
        public static string ExHentaiApiUrl { get; set; }

        /// <summary>
        /// ExHentai 登入網址
        /// </summary>
        public static string LoginUrl { get; set; } 
        #endregion

        #region --- Pattern ---
        /// <summary>
        /// 登入資訊的 Format Pattern
        /// </summary>
        public static string LoginInfoPattern { get; set; }

        /// <summary>
        /// MemberId 的 Regex Pattern
        /// </summary>
        public static string LoginMemberIdPattern { get; set; }

        /// <summary>
        /// PassHash 的 Regex Pattern
        /// </summary>
        public static string LoginPassHashPattern { get; set; } 
        #endregion

        public static string PageShowingPattern { get; set; }

        public static string GalleryUrlPattern { get; set; }
    }
}

using ExHentaiApi.Models;
using ExHentaiApi.Expressions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExHentaiApi
{
    public class ExHentaiHelper
    {

        #region --- Login ---
        public IAsyncResult BeginLogin(string username, string password, AsyncCallback callBack)
        {
            var buff = Encoding.UTF8.GetBytes(string.Format(Definitions.LoginInfoPattern, username, password));
            var _req = HttpWebRequest.Create(Definitions.LoginUrl) as HttpWebRequest;
            _req.Proxy = this.Proxy;
            _req.Method = WebRequestMethods.Http.Post;
            _req.Referer = Definitions.E_HentaiWebsiteUrl;
            _req.ContentType = "application/x-www-form-urlencoded";
            return new ApiResult(_req, buff, callBack);
        }

        public void EndLogin(IAsyncResult result)
        {
            ApiResult apiResult = result as ApiResult;

            if (apiResult == null)
            {
                throw new FormatException();
            }

            if (apiResult.Exception != null)
            {
                throw apiResult.Exception;
            }

            apiResult.CompletedSynchronously = true;

            var header = apiResult.Result.Headers.Get("set-cookie");

            Regex rID = new Regex(Definitions.LoginMemberIdPattern, RegexOptions.Compiled);
            Regex rPW = new Regex(Definitions.LoginPassHashPattern, RegexOptions.Compiled);

            this.User = new ExHentaiUser(rID.Match(header).Groups[1].Value, rPW.Match(header).Groups[1].Value);
        } 
        #endregion

        #region GetGalleryTokensAsync
        public IAsyncResult BeginGetGalleryTokens(AsyncCallback callBack)
        {
            return this.BeginGetGalleryTokens(null, callBack, null);
        }

        public IAsyncResult BeginGetGalleryTokens(GallerySearchOption options, AsyncCallback callBack)
        {
            return this.BeginGetGalleryTokens(options, callBack, null);
        }

        public IAsyncResult BeginGetGalleryTokens(GallerySearchOption options, AsyncCallback callBack, object userState)
        {
            string url = this.DataSourceUrl;
            if (options != null)
            {
                url += options.GetParametor();
            }

            WebRequest wReq = WebRequest.Create(url);
            wReq.Proxy = this.Proxy;
            wReq.Method = WebRequestMethods.Http.Get;
            if (this.User != null)
            {
                wReq.Headers.Set("cookie", this.User.Cookie);
            }

            return new ApiResult(wReq, callBack, userState);
        }

        public GalleryTokenCollection EndGetGalleryTokens(IAsyncResult result)
        {
            ApiResult apiResult = result as ApiResult;

            if (apiResult == null)
            {
                throw new FormatException();
            }

            if (apiResult.Exception != null)
            {
                throw apiResult.Exception;
            }

            apiResult.CompletedSynchronously = true;

            return GalleryTokenCollection.CreateByHtml(apiResult.Result.GetResponseStream().ReadToString());
        }
        #endregion

        #region --- public property ---
        /// <summary>
        /// 用戶資訊
        /// </summary>
        public ExHentaiUser User { get; internal set; }

        /// <summary>
        /// 搜索來源
        /// </summary>
        public string DataSourceUrl
        {
            get
            {
                return (this.User != null) ? Definitions.ExHentaiWebsiteUrl : Definitions.E_HentaiWebsiteUrl;
            }
        }

        /// <summary>
        /// 代理伺服器
        /// </summary>
        public IWebProxy Proxy { get; set; } 
        #endregion
    }
}

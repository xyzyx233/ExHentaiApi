using ExHentaiApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExHentaiApi
{
    public class ExHentaiApi
    {
        #region --- constructor ---
        public ExHentaiApi()
        {
            this.Helper = new ExHentaiHelper();
        }
        #endregion

        #region --- public method ---

        #region #Login
        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="username">用戶名稱</param>
        /// <param name="password">用戶密碼</param>
        public void Login(string username, string password)
        {
            IAsyncResult result = this.Helper.BeginLogin(username, password, null);
            result.AsyncWaitHandle.WaitOne();
            this.Helper.EndLogin(result);
        }

        /// <summary>
        /// 使用Cookie資訊進行登入
        /// </summary>
        /// <param name="memberId"></param>
        /// <param name="passHash"></param>
        public void LoginByCookie(string memberId, string passHash)
        {
            this.Helper.User = new ExHentaiUser(memberId, passHash);
        } 
        #endregion

        #region #GetGalleryTokens
        public GalleryTokenCollection GetGalleryTokens()
        {
            return this.GetGalleryTokens(null);
        }

        public GalleryTokenCollection GetGalleryTokens(GallerySearchOption options)
        {
            IAsyncResult result = this.Helper.BeginGetGalleryTokens(options, null);
            result.AsyncWaitHandle.WaitOne();
            return this.Helper.EndGetGalleryTokens(result);
        }
        #endregion

        #endregion

        #region --- public property ---
        /// <summary>
        /// 輔助方法
        /// </summary>
        public ExHentaiHelper Helper { get; set; }
        #endregion
    }
}

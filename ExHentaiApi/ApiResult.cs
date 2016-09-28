using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ExHentaiApi
{
    public class ApiResult : IAsyncResult
    {
        #region --- constructor ---
        public ApiResult(WebRequest request)
            : this(request, null, null, null)
        {

        }

        public ApiResult(WebRequest request, byte[] buff)
            : this(request, buff, null, null)
        {

        }

        public ApiResult(WebRequest request, AsyncCallback callBack)
            : this(request, null, callBack, null)
        {

        }

        public ApiResult(WebRequest request, AsyncCallback callBack, object asyncState)
            : this(request, null, callBack, asyncState)
        {

        }

        public ApiResult(WebRequest request, byte[] buff, AsyncCallback callBack)
            : this(request, buff, callBack, null)
        {

        }

        public ApiResult(WebRequest request, byte[] buff, AsyncCallback callBack, object asyncState)
        {
            this._req = request;
            this._buff = buff;
            this._callBack = callBack;
            this._asyncState = asyncState;
            this._waitHandle = new ManualResetEvent(false);

            this.Cancel = false;
            this.CompletedSynchronously = false;
            this.IsCompleted = false;

            try
            {
                //如果不需要傳參數則直接GetResponse
                if (buff == null)
                    this._req.BeginGetResponse(this.GetResponseCallback, null);
                else
                    this._req.BeginGetRequestStream(this.GetRequestCallback, null);
            }
            catch (Exception ex)
            {
                this.Result = null;
                this.Complete(ex);
            }
        }
        #endregion

        #region --- private method ---
        private void Complete()
        {
            this.Complete(null);
        }

        private void Complete(Exception ex)
        {
            this.Exception = ex;
            this.IsCompleted = true;
            this._waitHandle.Set();

            if (this._callBack != null)
            {
                this._callBack.Invoke(this);
            }
        }

        private void GetRequestCallback(IAsyncResult ar)
        {
            if (this.Cancel)
            {
                this.Complete(null);
                return;
            }

            try
            {
                Stream stream = this._req.EndGetRequestStream(ar);
                stream.Write(this._buff, 0, this._buff.Length);
                stream.Flush();
                stream.Close();

                //清空待傳的數據
                this._buff = null;

                this._req.BeginGetResponse(this.GetResponseCallback, null);
            }
            catch (Exception ex)
            {
                this.Result = null;
                this.Complete(ex);
            }
        }

        private void GetResponseCallback(IAsyncResult ar)
        {
            if (this.Cancel)
            {
                this.Complete(null);
                return;
            }

            try
            {
                this.Result = this._req.EndGetResponse(ar) as HttpWebResponse;

                //using (HttpWebResponse response = (HttpWebResponse)this._req.EndGetResponse(ar))
                //using (Stream streamResponse = response.GetResponseStream())
                //using (StreamReader streamRead = new StreamReader(streamResponse))
                //{
                //    this.Result = streamRead.ReadToEnd();
                //}

                this.Complete(null);
            }
            catch (Exception ex)
            {
                this.Result = null;
                this.Complete(ex);
            }
        }
        #endregion

        #region --- public property ---
        public object AsyncState { get { return this._asyncState; } }
        public WaitHandle AsyncWaitHandle { get { return this._waitHandle; } }
        public bool CompletedSynchronously { get; set; }
        public bool IsCompleted { get; set; }
        public bool Cancel { get; set; }
        public HttpWebResponse Result { get; set; }
        public Exception Exception { get; set; }
        #endregion

        #region --- private field ---
        private WebRequest _req;
        private byte[] _buff;
        private AsyncCallback _callBack;
        private object _asyncState;
        private ManualResetEvent _waitHandle;
        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExHentaiApi.Models
{
    public class ExHentaiUser
    {
        public ExHentaiUser(string memberId, string passHash)
        {
            this.MemberId = memberId;
            this.PassHash = passHash;
        }

        /// <summary>
        /// 用戶Cookie
        /// </summary>
        public string Cookie
        {
            get { return string.Format("ipb_member_id={0};ipb_pass_hash={1};", this.MemberId, this.PassHash); }
        }

        /// <summary>
        /// 用戶編號
        /// </summary>
        public string MemberId { get; set; }

        /// <summary>
        /// 用戶瀏覽金鑰
        /// </summary>
        public string PassHash { get; set; }
    }
}

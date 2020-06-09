using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.Model
{
    /// <summary>
    /// 方式果乾會員
    /// </summary>
    public class MemberListTitle
    {
        ///<summary>
        ///時間戳記
        ///</summary>
        [DataMember(Name = "時間戳記")]
        [JsonProperty(PropertyName = "時間戳記")]
        public string TimeStamp { set; get; }
        ///<summary>
        ///真實姓名
        ///</summary>
        [DataMember(Name = "真實姓名")]
        [JsonProperty(PropertyName = "真實姓名")]
        public string RealName { set; get; }
        ///<summary>
        ///出生年月日
        ///</summary>
        [DataMember(Name = "出生年月日")]
        [JsonProperty(PropertyName = "出生年月日")]
        public string Birthday { set; get; }
        ///<summary>
        ///聯絡電話
        ///</summary>
        [DataMember(Name = "聯絡電話")]
        [JsonProperty(PropertyName = "聯絡電話")]
        public string PhoneNumber { set; get; }
        ///<summary>
        ///電子信箱
        ///</summary>
        [DataMember(Name = "電子信箱")]
        [JsonProperty(PropertyName = "電子信箱")]
        public string Email { set; get; }
    }
}

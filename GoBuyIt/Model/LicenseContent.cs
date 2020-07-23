using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.Model
{
    public class LicenseContent
    {

        /// <summary>
        /// 起始日期
        /// </summary>
        [JsonProperty(PropertyName = "DateFrom")]
        public string DateFrom { set; get; }

        /// <summary>
        /// 結束日期
        /// </summary>
        [JsonProperty(PropertyName = "DateEnd")]
        public string DateEnd { set; get; }

        /// <summary>
        /// 授權者
        /// </summary>
        [JsonProperty(PropertyName = "Authorizer")]
        public string Authorizer { set; get; }

        /// <summary>
        /// 被授權者
        /// </summary>
        [JsonProperty(PropertyName = "Customer")]
        public string Customer { set; get; }
    }
}

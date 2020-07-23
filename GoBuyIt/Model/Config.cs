using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.Model
{
    /// <summary>
    /// 配置檔
    /// </summary>
    public class Config
    {
        /// <summary>
        /// 訂單資料夾路徑
        /// </summary>
        [JsonProperty(PropertyName = "OrderListDirectoryPath")]
        public string OrderListDirectoryPath { set; get; }

        /// <summary>
        /// 物流單資料夾路徑
        /// </summary>
        [JsonProperty(PropertyName = "LogisticsDirectoryPath")]
        public string LogisticsDirectoryPath { set; get; }

        /// <summary>
        /// 物流單副檔名類型
        /// </summary>
        [JsonProperty(PropertyName = "LogisticsFileNameExtensionType")]
        public string LogisticsFileNameExtensionType { set; get; }

        /// <summary>
        /// 會員名單檔案路徑
        /// </summary>
        [JsonProperty(PropertyName = "MemberListFilePath")]
        public string MemberListFilePath { set; get; }

        /// <summary>
        /// PDF輸出預設位置
        /// </summary>
        [JsonProperty(PropertyName = "PDFDefaultPath")]
        public string PDFDefaultPath { set; get; }

        /// <summary>
        /// 授權檔路徑
        /// </summary>
        [JsonProperty(PropertyName = "LicenseDirectory")]
        public string LicenseDirectory { set; get; }

        /// <summary>
        /// 標頭字型路徑
        /// </summary>
        [JsonProperty(PropertyName = "HeaderFontPath")]
        public string HeaderFontPath { set; get; }

        /// <summary>
        /// 內容字型路徑
        /// </summary>
        [JsonProperty(PropertyName = "ContentFontPath")]
        public string ContentFontPath { set; get; }


    }
}

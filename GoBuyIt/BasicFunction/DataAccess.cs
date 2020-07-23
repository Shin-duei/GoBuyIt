using GoBuyIt.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.BasicFunction
{
    public class DataAccess
    {
        public DataAccess()
        {
            Config config = ReadConfiguration();

            OrderListDirectoryPath = config.OrderListDirectoryPath;
            LogisticsDirectoryPath=config.LogisticsDirectoryPath;
            MemberListFilePath = config.MemberListFilePath;
            PDFDefaultPath = config.PDFDefaultPath;
            LicenseDirectory = config.LicenseDirectory;
            HeaderFontPath = config.HeaderFontPath;
            ContentFontPath = config.ContentFontPath;
            LogisticsFileNameExtensionType=config.LogisticsFileNameExtensionType;
        }

        public static string OrderListDirectoryPath;
        public static string LogisticsDirectoryPath;
        public static string MemberListFilePath;
        public static string PDFDefaultPath;
        public static string LicenseDirectory;
        public static string HeaderFontPath;
        public static string ContentFontPath;
        public static string LogisticsFileNameExtensionType;

        /// <summary>
        /// 讀取配置
        /// </summary>
        /// <returns></returns>
        private Config ReadConfiguration()
        {
            using (StreamReader r = new StreamReader("Config.dat"))
            {
                string jsonString = r.ReadToEnd();
                return JsonConvert.DeserializeObject<Config>(jsonString);//反序列化
            }
        }

    }
}

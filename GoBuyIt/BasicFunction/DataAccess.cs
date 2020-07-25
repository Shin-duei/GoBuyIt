using GoBuyIt.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GoBuyIt.BasicFunction
{
    public class DataAccess
    {
        public DataAccess()
        {
            Config config = ReadConfiguration();

            if (config == null)
                System.Environment.Exit(0);

            
            OrderListDirectoryPath = config.OrderListDirectoryPath;
            if (!Directory.Exists(OrderListDirectoryPath))
                Directory.CreateDirectory(OrderListDirectoryPath);

            LogisticsDirectoryPath = config.LogisticsDirectoryPath;
            if (!Directory.Exists(LogisticsDirectoryPath))
                Directory.CreateDirectory(LogisticsDirectoryPath);

            LicenseDirectory = config.LicenseDirectory;
            if (!Directory.Exists(LicenseDirectory))
                Directory.CreateDirectory(LicenseDirectory);

            MemberListFilePath = config.MemberListFilePath; 
            PDFDefaultPath = config.PDFDefaultPath;
            HeaderFontPath = config.HeaderFontPath;
            ContentFontPath = config.ContentFontPath;
            LogisticsFileNameExtensionType = config.LogisticsFileNameExtensionType;
        }

        public static string OrderListDirectoryPath;
        public static string LogisticsDirectoryPath;
        public static string MemberListFilePath;
        public static string PDFDefaultPath;
        public static string LicenseDirectory;
        public static string HeaderFontPath;
        public static string ContentFontPath;
        public static string LogisticsFileNameExtensionType;

        private const string ConfigFileName = "Config.dat";

        /// <summary>
        /// 讀取配置
        /// </summary>
        /// <returns></returns>
        private Config ReadConfiguration()
        {
            if (File.Exists(ConfigFileName))
            {
                using (StreamReader r = new StreamReader(ConfigFileName))
                {
                    string jsonString = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<Config>(jsonString);//反序列化
                }
            }
            else
            {
                return MigrationConfig();
            }

        }
        /// <summary>
        /// 配置檔自動生成
        /// </summary>
        /// <returns></returns>
        private Config MigrationConfig()
        {
            var config = new Config
            {
                OrderListDirectoryPath = @".\OrderList",
                MemberListFilePath = @".\MemberList\mm.csv",
                LogisticsDirectoryPath = @".\LogisticsList",
                PDFDefaultPath = "",
                LicenseDirectory = @".\License",
                HeaderFontPath = @"C:\windows\fonts\msjhbd.ttc,0",
                ContentFontPath = @"C:\windows\fonts\msjh.ttc,0",
                LogisticsFileNameExtensionType = ".png"
            };

            using (StreamWriter sw = new StreamWriter(ConfigFileName))
            {
                try
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Ignore;

                    //構建Json.net的寫入流  
                    JsonWriter writer = new JsonTextWriter(sw)
                    {
                        Formatting = Formatting.Indented,//格式化缩进
                        Indentation = 4,  //缩进四个字符
                        IndentChar = ' '  //缩进的字符是空格
                    }; ;
                    //把模型數據序列化並寫入Json.net的JsonWriter流中  
                    serializer.Serialize(writer, config);
                    //ser.Serialize(writer, ht);  
                    writer.Close();
                    sw.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString(), "提示"); ex.Message.ToString();
                }
            }
            return config;
        }
    }
}

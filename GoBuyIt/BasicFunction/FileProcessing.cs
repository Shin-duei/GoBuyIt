using ServiceStack;
using System.Collections.Generic;
using System.IO;

namespace GoBuyIt.BasicFunction
{
    /// <summary>
    /// 資料處理用的工具
    /// </summary>
    public class FileProcessing
    {
        /// <summary>
        /// Csv轉成Json物件
        /// </summary>
        /// <param name="CsvFilePath"></param>
        /// <param name=""></param>
        public static bool CsvTrans2Json<T>(string CsvFilePath, out List<T> jsonObject) where T : new()
        {
            jsonObject = new List<T>();

            if (!System.IO.File.Exists(CsvFilePath))
                return false;

            var csv = File.ReadAllText(CsvFilePath, new System.Text.UTF8Encoding(true));
            //記得using ServiceStack啟用擴充方法
            try
            {
                jsonObject = csv.FromCsv<List<T>>();
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}

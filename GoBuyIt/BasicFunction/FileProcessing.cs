using GoBuyIt.Model;
using Newtonsoft.Json;
using ServiceStack;
using System;
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
        public static T CsvTrans2Json<T>(string CsvFilePath, T jsonObject)
        {
            var csv = File.ReadAllText(@"C:\Users\Administrator\Downloads\order_2020_05_16_09_52_57.csv", System.Text.Encoding.GetEncoding(950));
            //記得using ServiceStack啟用擴充方法
            var data = csv.FromCsv<List<BaseTitle>>();
            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            Console.Read();

            return jsonObject;
        }
        public static void CsvTrans2Jsontest()
        {
            var csv = File.ReadAllText(@"C:\Users\Administrator\Downloads\order_2020_05_16_09_52_57.csv", new System.Text.UTF8Encoding(true));
            //記得using ServiceStack啟用擴充方法
            var data = csv.FromCsv<List<BaseTitle>>();
            Console.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
            Console.Read();

        }

    }
}

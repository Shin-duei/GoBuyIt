using GoBuyIt.Model;
using LicenseManager;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace GoBuyIt.BasicFunction
{
    public class LicenseCheck
    {
        /// <summary>
        /// 開始時間
        /// </summary>
        public static DateTime DateFrom;

        /// <summary>
        /// 結束時間
        /// </summary>
        public static DateTime DateEnd;

        /// <summary>
        /// 可用時間
        /// </summary>
        public static int AvailabeTime;

        /// <summary>
        /// 確認授權
        /// </summary>
        /// <param name="licenseDirectoryPath"></param>
        /// <returns></returns>
        public static bool IsLicenseValidation(string licenseDirectoryPath)
        {
            var DecryptJson = LicenseKit.Decrypt(licenseDirectoryPath);

            if (DecryptJson != null)
            {
                var licenseContent = JsonConvert.DeserializeObject<LicenseContent>(DecryptJson);

                CultureInfo CultureInfoDateCulture = new CultureInfo("ja-JP"); //日期文化格式

                DateFrom = DateTime.ParseExact(licenseContent.DateFrom, "yyyy/MM/dd", CultureInfoDateCulture);
                DateEnd = DateTime.ParseExact(licenseContent.DateEnd, "yyyy/MM/dd", CultureInfoDateCulture);
                AvailabeTime = CalculateDate(DateEnd);

                if(AvailabeTime<0)
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        /// <summary>
        /// 計算目前日期與到期日之差異
        /// </summary>
        /// <param name="DateEnd"></param>
        /// <returns></returns>
        private static int CalculateDate(DateTime DateEnd)
        {
            //現在日期
            DateTime DateNow = DateTime.Now;

            TimeSpan k = new TimeSpan(DateEnd.Ticks - DateNow.Ticks);

            return k.Days;
        }
    }
}

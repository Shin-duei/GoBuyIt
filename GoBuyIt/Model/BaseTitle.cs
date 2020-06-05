using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.Model
{
    /// <summary>
    /// 基礎訂單樣板
    /// </summary>
    public class BaseTitle
    {
        /// <summary>
        /// 主鍵
        /// </summary>
        [JsonProperty(PropertyName = "主鍵")]
        public int MainKey { set; get; }

        /// <summary>
        /// 廠商編號
        /// </summary>
        [JsonProperty(PropertyName = "廠商編號")]
        public string OwnerNumber { set; get; }


        /// <summary>
        /// 廠商名稱
        /// </summary>
        [JsonProperty(PropertyName = "廠商名稱")]
        public string OwnerName { set; get; }


        /// <summary>
        /// 訂單編號
        /// </summary>
        [JsonProperty(PropertyName = "訂單編號")]
        public string OrderNumber { set; get; }


        /// <summary>
        /// 建立日期
        /// </summary>
        [JsonProperty(PropertyName = "建立日期")]
        public string DateCreate { set; get; }


        /// <summary>
        /// 訂單狀態
        /// </summary>
        [JsonProperty(PropertyName = "訂單狀態")]
        public string OrderStatus { set; get; }


        /// <summary>
        /// 顧客
        /// 顧客姓名
        /// </summary>
        [JsonProperty(PropertyName = "顧客")]
        public string CustomerName { set; get; }


        /// <summary>
        /// 名稱
        /// 貨物種類
        /// </summary>
        [JsonProperty(PropertyName = "名稱")]
        public string GoodsType { set; get; }


        /// <summary>
        /// 產品SKU
        /// 產品編號
        /// </summary>
        [JsonProperty(PropertyName = "產品SKU")]
        public string ProductSerial { set; get; }


        /// <summary>
        /// 產品
        /// 產品名稱
        /// </summary>
        [JsonProperty(PropertyName = "產品")]
        public string ProductName { set; get; }


        /// <summary>
        /// 產品數量
        /// </summary>
        [JsonProperty(PropertyName = "產品數量")]
        public int ProductQuantity { set; get; }


        /// <summary>
        /// 數量(單品/組合/任選)
        /// </summary>
        [JsonProperty(PropertyName = "數量(單品/組合/任選)")]
        public int ProductQuantitySpecific { set; get; }


        /// <summary>
        /// 單價
        /// </summary>
        [JsonProperty(PropertyName = "單價")]
        public double UnitPrice { set; get; }


        /// <summary>
        /// 小計
        /// </summary>
        [JsonProperty(PropertyName = "小計")]
        public double Subtotal { set; get; }


        /// <summary>
        /// 訂單金額(不含金/物流手續費)
        /// </summary>
        [JsonProperty(PropertyName = "訂單金額(不含金/物流手續費)")]
        public double OrderPrice { set; get; }


        /// <summary>
        /// 訂單金流手續費
        /// </summary>
        [JsonProperty(PropertyName = "訂單金流手續費")]
        public double HandlingFee { set; get; }


        /// <summary>
        /// 訂單運費
        /// </summary>
        [JsonProperty(PropertyName = "訂單運費")]
        public double ShippingFee { set; get; }


        /// <summary>
        /// 總計金額
        /// </summary>
        [JsonProperty(PropertyName = "總計金額")]
        public double OrderTotalPrice { set; get; }


        /// <summary>
        /// 金流
        /// 金流類型
        /// </summary>
        [JsonProperty(PropertyName = "金流")]
        public string CashFlowType { set; get; }


        /// <summary>
        /// 金流狀態
        /// </summary>
        [JsonProperty(PropertyName = "金流狀態")]
        public string CashFlowStatus { set; get; }

        /// <summary>
        /// 金流備註
        /// </summary>
        [JsonProperty(PropertyName = "金流備註")]
        public string CashFlowRemark { set; get; }


        /// <summary>
        /// 物流
        /// 物流類型
        /// </summary>
        [JsonProperty(PropertyName = "物流")]
        public string LogisticsType { set; get; }

        /// <summary>
        /// 物流狀態
        /// </summary>
        [JsonProperty(PropertyName = "物流狀態")]
        public string LogisticsStatus { set; get; }

        /// <summary>
        /// 物流備註
        /// </summary>
        [JsonProperty(PropertyName = "物流備註")]
        public string LogisticsRemark { set; get; }

        /// <summary>
        /// 電話國碼
        /// </summary>
        [JsonProperty(PropertyName = "電話國碼")]
        public string CountryPhoneCode { set; get; }

        /// <summary>
        /// 顧客電話
        /// </summary>
        [JsonProperty(PropertyName = "顧客電話")]
        public string CustomerPhoneNumber { set; get; }

        /// <summary>
        /// 顧客性別
        /// </summary>
        [JsonProperty(PropertyName = "顧客性別")]
        public string CustomerGender { set; get; }

        /// <summary>
        /// 顧客信箱
        /// </summary>
        [JsonProperty(PropertyName = "顧客信箱")]
        public string CustomerEmail { set; get; }

        /// <summary>
        /// 運送地址
        /// </summary>
        [JsonProperty(PropertyName = "運送地址")]
        public string ShippingAddress { set; get; }

        /// <summary>
        /// 方便收貨時間
        /// </summary>
        [JsonProperty(PropertyName = "方便收貨時間")]
        public string ShippingTime { set; get; }

        /// <summary>
        /// 運送超商
        /// 超商名稱
        /// </summary>
        [JsonProperty(PropertyName = "運送超商")]
        public string ConvenienceStoreName { set; get; }

        /// <summary>
        /// 超商寄貨編號(拋單後取得)
        /// </summary>
        [JsonProperty(PropertyName = "超商寄貨編號(拋單後取得)")]
        public int PostNumber { set; get; }

        /// <summary>
        /// 超商代號
        /// </summary>
        [JsonProperty(PropertyName = "超商代號")]
        public int ConvenienceStoreSerial { set; get; }

        /// <summary>
        /// 顧客備註
        /// </summary>
        [JsonProperty(PropertyName = "顧客備註")]
        public string CustomerRemark { set; get; }

        /// <summary>
        /// 商家備註
        /// </summary>
        [JsonProperty(PropertyName = "商家備註")]
        public string OwnerRemark { set; get; }

        /// <summary>
        /// 物流追蹤
        /// 物流資訊
        /// </summary>
        [JsonProperty(PropertyName = "物流追蹤")]
        public string LogisticsTrack { set; get; }

        /// <summary>
        /// 發票
        /// </summary>
        [JsonProperty(PropertyName = "發票")]
        public string Iinvoice { set; get; }

        /// <summary>
        /// IP
        /// </summary>
        [JsonProperty(PropertyName = "IP")]
        public string CustomerIP { set; get; }

        /// <summary>
        /// FB名稱
        /// </summary>
        [JsonProperty(PropertyName = "FB名稱")]
        public string FacebookID { set; get; }

        /// <summary>
        /// 標籤
        /// </summary>
        [JsonProperty(PropertyName = "標籤")]
        public string Tag { set; get; }

        /// <summary>
        /// 信用卡末四碼
        /// </summary>
        [JsonProperty(PropertyName = "信用卡末四碼")]
        public int CreditCardLastFourNumber { set; get; }

        /// <summary>
        /// 託運單號
        /// </summary>
        [JsonProperty(PropertyName = "託運單號")]
        public string ConsignmentNumber { set; get; }

        /// <summary>
        /// 匯款末五碼
        /// </summary>
        [JsonProperty(PropertyName = "匯款末五碼")]
        public int MoneyTransferLastFiveNumber { set; get; }

        /// <summary>
        /// 匯款時間
        /// </summary>
        [JsonProperty(PropertyName = "匯款時間")]
        public string MoneyTransferTime { set; get; }

        /// <summary>
        /// 顧客留言
        /// </summary>
        [JsonProperty(PropertyName = "顧客留言")]
        public string CustomerMessage { set; get; }
    }
}

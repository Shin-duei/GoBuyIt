using Newtonsoft.Json;
using System.Runtime.Serialization;

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
        [DataMember(Name = "主鍵")]
        [JsonProperty(PropertyName = "主鍵")]
        public int MainKey { set; get; }

        /// <summary>
        /// 廠商編號
        /// </summary>
        [DataMember(Name = "廠商編號")]
        [JsonProperty(PropertyName = "廠商編號")]
        public string OwnerNumber { set; get; }


        /// <summary>
        /// 廠商名稱
        /// </summary>
        [DataMember(Name = "廠商名稱")]
        [JsonProperty(PropertyName = "廠商名稱")]
        public string OwnerName { set; get; }


        /// <summary>
        /// 訂單編號
        /// </summary>
        [DataMember(Name = "訂單編號")]
        [JsonProperty(PropertyName = "訂單編號")]
        public string OrderNumber { set; get; }


        /// <summary>
        /// 建立日期
        /// </summary>
        [DataMember(Name = "建立日期")]
        [JsonProperty(PropertyName = "建立日期")]
        public string DateCreate { set; get; }


        /// <summary>
        /// 訂單狀態
        /// </summary>
        [DataMember(Name = "訂單狀態")]
        [JsonProperty(PropertyName = "訂單狀態")]
        public string OrderStatus { set; get; }


        /// <summary>
        /// 顧客
        /// 顧客姓名
        /// </summary>
        [DataMember(Name = "顧客")]
        [JsonProperty(PropertyName = "顧客")]
        public string CustomerName { set; get; }

        /// <summary>
        /// 會員
        /// 會員資格
        /// </summary>
        [DataMember(Name = "會員")]
        [JsonProperty(PropertyName = "會員")]
        public string Membership { set; get; }


        /// <summary>
        /// 名稱
        /// 貨物種類
        /// </summary>
        [DataMember(Name = "名稱")]
        [JsonProperty(PropertyName = "名稱")]
        public string GoodsType { set; get; }


        /// <summary>
        /// 產品SKU
        /// 產品編號
        /// </summary>
        [DataMember(Name = "產品SKU")]
        [JsonProperty(PropertyName = "產品SKU")]
        public string ProductSerial { set; get; }


        /// <summary>
        /// 產品
        /// 產品名稱
        /// </summary>
        [DataMember(Name = "產品")]
        [JsonProperty(PropertyName = "產品")]
        public string ProductName { set; get; }


        ///// <summary>
        ///// 產品數量
        ///// </summary>
        //[DataMember(Name = "產品數量")]
        //[JsonProperty(PropertyName = "產品數量")]
        //public int ProductQuantity { set; get; }


        ///// <summary>
        ///// 數量(單品/組合/任選)
        ///// </summary>
        //[DataMember(Name = "數量(單品/組合/任選)")]
        //[JsonProperty(PropertyName = "數量(單品/組合/任選)")]
        //public int ProductQuantitySpecific { set; get; }


        ///// <summary>
        ///// 單價
        ///// </summary>
        //[DataMember(Name = "單價")]
        //[JsonProperty(PropertyName = "單價")]
        //public double UnitPrice { set; get; }


        ///// <summary>
        ///// 小計
        ///// </summary>
        //[DataMember(Name = "小計")]
        //[JsonProperty(PropertyName = "小計")]
        //public double Subtotal { set; get; }


        ///// <summary>
        ///// 訂單金額(不含金/物流手續費)
        ///// </summary>
        //[DataMember(Name = "訂單金額(不含金/物流手續費)")]
        //[JsonProperty(PropertyName = "訂單金額(不含金/物流手續費)")]
        //public double OrderPrice { set; get; }


        ///// <summary>
        ///// 訂單金流手續費
        ///// </summary>
        //[DataMember(Name = "訂單金流手續費")]
        //[JsonProperty(PropertyName = "訂單金流手續費")]
        //public double HandlingFee { set; get; }


        ///// <summary>
        ///// 訂單運費
        ///// </summary>
        //[DataMember(Name = "訂單運費")]
        //[JsonProperty(PropertyName = "訂單運費")]
        //public double ShippingFee { set; get; }


        ///// <summary>
        ///// 總計金額
        ///// </summary>
        //[DataMember(Name = "總計金額")]
        //[JsonProperty(PropertyName = "總計金額")]
        //public double OrderTotalPrice { set; get; }


        ///// <summary>
        ///// 金流
        ///// 金流類型
        ///// </summary>
        //[DataMember(Name = "金流")]
        //[JsonProperty(PropertyName = "金流")]
        //public string CashFlowType { set; get; }


        ///// <summary>
        ///// 金流狀態
        ///// </summary>
        //[DataMember(Name = "金流狀態")]
        //[JsonProperty(PropertyName = "金流狀態")]
        //public string CashFlowStatus { set; get; }

        ///// <summary>
        ///// 金流備註
        ///// </summary>
        //[DataMember(Name = "金流備註")]
        //[JsonProperty(PropertyName = "金流備註")]
        //public string CashFlowRemark { set; get; }


        ///// <summary>
        ///// 物流
        ///// 物流類型
        ///// </summary>
        //[DataMember(Name = "物流")]
        //[JsonProperty(PropertyName = "物流")]
        //public string LogisticsType { set; get; }

        ///// <summary>
        ///// 物流狀態
        ///// </summary>
        //[DataMember(Name = "物流狀態")]
        //[JsonProperty(PropertyName = "物流狀態")]
        //public string LogisticsStatus { set; get; }

        ///// <summary>
        ///// 物流備註
        ///// </summary>
        //[DataMember(Name = "物流備註")]
        //[JsonProperty(PropertyName = "物流備註")]
        //public string LogisticsRemark { set; get; }

        ///// <summary>
        ///// 電話國碼
        ///// </summary>
        //[DataMember(Name = "電話國碼")]
        //[JsonProperty(PropertyName = "電話國碼")]
        //public string CountryPhoneCode { set; get; }

        ///// <summary>
        ///// 顧客電話
        ///// </summary>
        //[DataMember(Name = "顧客電話")]
        //[JsonProperty(PropertyName = "顧客電話")]
        //public string CustomerPhoneNumber { set; get; }

        ///// <summary>
        ///// 顧客性別
        ///// </summary>
        //[DataMember(Name = "顧客性別")]
        //[JsonProperty(PropertyName = "顧客性別")]
        //public string CustomerGender { set; get; }

        ///// <summary>
        ///// 顧客信箱
        ///// </summary>
        //[DataMember(Name = "顧客信箱")]
        //[JsonProperty(PropertyName = "顧客信箱")]
        //public string CustomerEmail { set; get; }

        ///// <summary>
        ///// 運送地址
        ///// </summary>
        //[DataMember(Name = "運送地址")]
        //[JsonProperty(PropertyName = "運送地址")]
        //public string ShippingAddress { set; get; }

        ///// <summary>
        ///// 方便收貨時間
        ///// </summary>
        //[DataMember(Name = "方便收貨時間")]
        //[JsonProperty(PropertyName = "方便收貨時間")]
        //public string ShippingTime { set; get; }

        ///// <summary>
        ///// 運送超商
        ///// 超商名稱
        ///// </summary>
        //[DataMember(Name = "運送超商")]
        //[JsonProperty(PropertyName = "運送超商")]
        //public string ConvenienceStoreName { set; get; }

        ///// <summary>
        ///// 超商寄貨編號(拋單後取得)
        ///// </summary>
        //[DataMember(Name = "超商寄貨編號(拋單後取得)")]
        //[JsonProperty(PropertyName = "超商寄貨編號(拋單後取得)")]
        //public int PostNumber { set; get; }

        ///// <summary>
        ///// 超商代號
        ///// </summary>
        //[DataMember(Name = "超商代號")]
        //[JsonProperty(PropertyName = "超商代號")]
        //public int ConvenienceStoreSerial { set; get; }

        ///// <summary>
        ///// 顧客備註
        ///// </summary>
        //[DataMember(Name = "顧客備註")]
        //[JsonProperty(PropertyName = "顧客備註")]
        //public string CustomerRemark { set; get; }

        ///// <summary>
        ///// 商家備註
        ///// </summary>
        //[DataMember(Name = "商家備註")]
        //[JsonProperty(PropertyName = "商家備註")]
        //public string OwnerRemark { set; get; }

        ///// <summary>
        ///// 物流追蹤
        ///// 物流資訊
        ///// </summary>
        //[DataMember(Name = "物流追蹤")]
        //[JsonProperty(PropertyName = "物流追蹤")]
        //public string LogisticsTrack { set; get; }

        /// <summary>
        /// 發票
        /// </summary>
        [DataMember(Name = "發票")]
        [JsonProperty(PropertyName = "發票")]
        public string Iinvoice { set; get; }

        /// <summary>
        /// IP
        /// </summary>
        [DataMember(Name = "IP")]
        [JsonProperty(PropertyName = "IP")]
        public string CustomerIP { set; get; }

        /// <summary>
        /// FB名稱
        /// </summary>
        [DataMember(Name = "FB名稱")]
        [JsonProperty(PropertyName = "FB名稱")]
        public string FacebookID { set; get; }

        /// <summary>
        /// 標籤
        /// </summary>
        [DataMember(Name = "標籤")]
        [JsonProperty(PropertyName = "標籤")]
        public string Tag { set; get; }

        ///// <summary>
        ///// 信用卡末四碼
        ///// </summary>
        //[DataMember(Name = "信用卡末四碼")]
        //[JsonProperty(PropertyName = "信用卡末四碼")]
        //public int CreditCardLastFourNumber { set; get; }

        ///// <summary>
        ///// 託運單號
        ///// </summary>
        //[DataMember(Name = "託運單號")]
        //[JsonProperty(PropertyName = "託運單號")]
        //public string ConsignmentNumber { set; get; }

        ///// <summary>
        ///// 匯款末五碼
        ///// </summary>
        //[DataMember(Name = "匯款末五碼")]
        //[JsonProperty(PropertyName = "匯款末五碼")]
        //public int MoneyTransferLastFiveNumber { set; get; }

        /// <summary>
        /// 匯款時間
        /// </summary>
        [DataMember(Name = "匯款時間")]
        [JsonProperty(PropertyName = "匯款時間")]
        public string MoneyTransferTime { set; get; }

        /// <summary>
        /// 顧客留言
        /// </summary>
        [DataMember(Name = "顧客留言")]
        [JsonProperty(PropertyName = "顧客留言")]
        public string CustomerMessage { set; get; }


    }
}

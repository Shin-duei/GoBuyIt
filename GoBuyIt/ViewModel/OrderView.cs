using GoBuyIt.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.ViewModel
{
          public class OrderView : ViewModelBase
          {
                    private BaseTitle OrderList;

                    public OrderView(BaseTitle orderList)
                    {
                              OrderList = orderList;

                              OwnerName = OrderList.OwnerName;
                              OrderNumber = OrderList.OrderNumber;
                              DateCreate = OrderList.DateCreate;
                              CustomerName = OrderList.CustomerName;
                              Membership = OrderList.Membership;
                    }

                    private string ownerName;
                    /// <summary>
                    /// 廠商名稱
                    /// </summary>
                    [DataMember(Name = "廠商名稱")]
                    [JsonProperty(PropertyName = "廠商名稱")]
                    public string OwnerName
                    {
                              get { return ownerName; }
                              set
                              {
                                        ownerName = value;
                                        OnPropertyChanged();
                              }
                    }

                    private string orderNumber;
                    /// <summary>
                    /// 訂單編號
                    /// </summary>
                    [DataMember(Name = "訂單編號")]
                    [JsonProperty(PropertyName = "訂單編號")]
                    public string OrderNumber
                    {
                              get { return orderNumber; }
                              set
                              {
                                        orderNumber = value;
                                        OnPropertyChanged();
                              }
                    }

                    private string dateCreate;
                    /// <summary>
                    /// 建立日期
                    /// </summary>
                    [DataMember(Name = "建立日期")]
                    [JsonProperty(PropertyName = "建立日期")]
                    public string DateCreate
                    {
                              get { return dateCreate; }
                              set
                              {
                                        dateCreate = value;
                                        OnPropertyChanged();
                              }
                    }

                    private string customerName;
                    /// <summary>
                    /// 顧客
                    /// 顧客姓名
                    /// </summary>
                    [DataMember(Name = "顧客")]
                    [JsonProperty(PropertyName = "顧客")]
                    public string CustomerName
                    {
                              get { return customerName; }
                              set
                              {
                                        customerName = value;
                                        OnPropertyChanged();
                              }
                    }

                    private string membership;
                    /// <summary>
                    /// 會員
                    /// 會員資格
                    /// </summary>
                    [DataMember(Name = "會員")]
                    [JsonProperty(PropertyName = "會員")]
                    public string Membership
                    {
                              get { return membership; }
                              set
                              {
                                        membership = value;
                                        OnPropertyChanged();
                              }
                    }
          }
}

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
                              OwnerNumber = OrderList.OrderNumber;
                              OwnerName = OrderList.OwnerName;
                              OrderNumber = OrderList.OrderNumber;
                              DateCreate = OrderList.DateCreate;
                    }

                    private string ownerNumber;
                    /// <summary>
                    /// 廠商編號
                    /// </summary>
                    [DataMember(Name = "廠商編號")]
                    [JsonProperty(PropertyName = "廠商編號")]
                    public string OwnerNumber
                    {
                              get { return ownerNumber; }
                              set
                              {
                                        ownerNumber = value;
                                        OnPropertyChanged();
                              }
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

          }
}

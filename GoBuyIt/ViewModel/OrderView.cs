using GoBuyIt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.ViewModel
{
          public class OrderView : ViewModelBase
          {
                    private BaseTitle orderList;

                    public BaseTitle OrderList
                    {
                              get { return orderList; }
                              set
                              {
                                        orderList = value;
                                        OnPropertyChanged();
                              }
                    }

          }
}

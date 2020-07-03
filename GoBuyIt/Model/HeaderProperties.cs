using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.Model
{
    public class HeaderProperties
    {
        public HeaderProperties()
        {
            this.FontSize = 10;
            this.HeaderFontSize = 11;
            this.CellWidth = 30;
        }
        /// <summary>
        /// 列显示的名称
        /// </summary>
        public string DisplayName { get; set; }
        /// <summary>
        /// 列相对于的属性名称
        /// </summary>
        public string ValueName { get; set; }
        /// <summary>
        /// 列宽
        /// </summary>
        public float CellWidth { get; set; }
        /// <summary>
        /// 标题字体大小
        /// </summary>
        public int HeaderFontSize { get; set; }
        /// <summary>
        /// 内容字体大小
        /// </summary>
        public int FontSize { get; set; }
    }
}

using GoBuyIt.Model;
using GoBuyIt.ViewModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.BasicFunction
{
    public static class ToPdfTools
    {
        /// <summary>
        /// 文档边距（上和下）
        /// </summary>
        private static float _marginTop = 20;
        private static float _marginBottom = 20;

        /// <summary>
        /// 设置pdf内容占文档的宽度比例
        /// </summary>
        private static readonly float _widthPercent = 100;

        /// <summary>
        /// 文档字体BaseFont类引入字体类型
        /// </summary>
        private static readonly BaseFont BsFont = BaseFont.CreateFont(@"C:\windows\fonts\msjh.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);


        /// <summary>
        /// 导出Pdf
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">数据</param>
        /// <param name="headerProperties">标题及列设计</param>
        /// <param name="rectangle">文档大小</param>
        /// <param name="isLandscape">是否横向</param>
        /// <returns></returns>
        public static MemoryStream ToPdfStream<T>(this List<T> data, List<HeaderProperties> headerProperties, Rectangle rectangle, bool isLandscape = false)
        {
            Rectangle pageSize = rectangle;
            MemoryStream stream = new MemoryStream();

            Document doc = isLandscape ? new Document(pageSize.Rotate()) : new Document(pageSize);
            doc.SetMargins(0, 0, _marginTop, _marginBottom);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, stream);
            doc.Open();

            //设置Pdf表格内容 HeaderRows=1则表示第一行为表格的标题 可在每页顶部显示其别标题
            PdfPTable table = new PdfPTable(headerProperties.Select(x => x.CellWidth).ToArray())
            {
                WidthPercentage = _widthPercent,
                HeaderRows = 1
            };

            //添加表格标题
            AddHeader(table, headerProperties);

            //填充表格数据
            Font font = new Font(BsFont, 5, Font.BOLD, BaseColor.BLACK);
            foreach (var item in data)
            {
                foreach (var headerProperty in headerProperties)
                {
                    font.Size = headerProperty.FontSize;
                    var value = GetValue(item, headerProperty.ValueName);
                    PdfPCell cell = new PdfPCell(new Phrase(value, font)) { Border = 0 };
                    cell.Border = 1;
                    cell.BorderColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }
            }

            doc.Add(table);
            doc.Close();
            stream.Close();
            return stream;
        }

        public static PdfPTable ToPdfPTable<T>(this List<T> data, List<HeaderProperties> headerProperties, Rectangle rectangle, bool isLandscape = false)
        {
            Rectangle pageSize = rectangle;
            MemoryStream stream = new MemoryStream();

            Document doc = isLandscape ? new Document(pageSize.Rotate()) : new Document(pageSize);
            doc.SetMargins(0, 0, _marginTop, _marginBottom);
            PdfWriter pdfWriter = PdfWriter.GetInstance(doc, stream);
            doc.Open();

            //设置Pdf表格内容 HeaderRows=1则表示第一行为表格的标题 可在每页顶部显示其别标题
            PdfPTable table = new PdfPTable(headerProperties.Select(x => x.CellWidth).ToArray())
            {
                WidthPercentage = _widthPercent,
                HeaderRows = 1
            };
            
            //添加表格标题
            AddHeader(table, headerProperties);

            //填充表格数据
            Font font = new Font(BsFont, 5, Font.BOLD, BaseColor.BLUE);
            foreach (var item in data)
            {
                foreach (var headerProperty in headerProperties)
                {
                    font.Size = headerProperty.FontSize;
                    var value = GetValue(item, headerProperty.ValueName);
                    PdfPCell cell = new PdfPCell(new Phrase(value, font)) { Border = 0 };
                    cell.Border = 1;
                    cell.BorderColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }
            }
            return table;
        }


        private static string GetValue<T>(T t, string propertyName)
        {
            string str = string.Empty;
            var item = t.GetType().GetProperty(propertyName);
            if (item != null)
                str = item.GetValue(t, null).ToString();
            return str;
        }

        /// <summary>
        /// 添加标题
        /// </summary>
        /// <param name="table">Pdf表格</param>
        /// <param name="headerProperties">标题设置内容</param>
        private static void AddHeader(PdfPTable table, List<HeaderProperties> headerProperties)
        {
            Font headerFont = new Font(BsFont, 5, 1, BaseColor.BLACK);
            foreach (var header in headerProperties)
            {
                headerFont.Size = header.HeaderFontSize;
                PdfPCell cell = new PdfPCell(new Phrase(header.DisplayName, headerFont)) { Border = 0 };
                table.AddCell(cell);
            }
        }

        public static void ExportListPDF(List<OrderView> DataList)
        {

            string PrintDateAndTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            string templatefilePath = @"D:\C#\撿貨單.pdf";

            using (var inputStream = new FileStream(templatefilePath, FileMode.Open))

            using (var outputStream = new FileStream(@"D:\C#\newPdf.pdf", FileMode.Create))
            {
                PdfReader pdfReader = new PdfReader(inputStream);

                var pdfStamper = new PdfStamper(pdfReader, outputStream);

                BaseFont chBaseFont = BaseFont.CreateFont(@"C:\windows\fonts\msjh.ttc,0", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);


                AcroFields acroFields = pdfStamper.AcroFields;


                foreach (string field in acroFields.Fields.Keys)
                {
                    // 更新字體
                    acroFields.SetFieldProperty(field, "textsize", (float)12, null);
                    acroFields.SetFieldProperty(field, "textfont", chBaseFont, null);

                    //acroFields.RegenerateField(field);

                }

                var OwnerName = DataList.First(s => s.OwnerName != null || s.OwnerName != "").OwnerName;
                var OwnerNumber = DataList.First(s => s.OwnerNumber != null || s.OwnerNumber != "").OwnerNumber;

                acroFields.SetField("PrintDate", $"{PrintDateAndTime}");
                acroFields.SetField("OwnerName", $"{OwnerName}");
                acroFields.SetField("OwnerNumber", $"{OwnerNumber}");

                // PDF表單扁平化
                pdfStamper.FormFlattening = true;


                ColumnText ct = new ColumnText(pdfStamper.GetOverContent(1));

                var test1 = new List<HeaderProperties>();
                test1.Add(new HeaderProperties() { DisplayName = "訂單編號", ValueName = "OrderNumber" });
                test1.Add(new HeaderProperties() { DisplayName = "建立日期", ValueName = "DateCreate" });
                test1.Add(new HeaderProperties() { DisplayName = "顧客姓名", ValueName = "CustomerName" });
                test1.Add(new HeaderProperties() { DisplayName = "會員", ValueName = "Membership" });
                test1.Add(new HeaderProperties() { DisplayName = "產品SKU", ValueName = "ProductSerial" });
                test1.Add(new HeaderProperties() { DisplayName = "產品名稱", ValueName = "ProductName" });
                test1.Add(new HeaderProperties() { DisplayName = "產品數量", ValueName = "ProductQuantity" });

                ct.AddElement(DataList.ToPdfPTable(test1, PageSize.A4, true));
                // ct.setCanvas(stamper.getOverContent(1)); // 可用建構值，也可以直接SET
                //ct.AddElement(new Paragraph(24, new Chunk("INSERT PAGE")));
                //ct.AddElement(new Paragraph(24, new Chunk("YOU ASS HOLE")));
                // (字串, 左邊界, 底界, 右邊界, 上界(可調整Y位置), 縮排, 對齊)，此方法和addElement只能擇一
                // ct.setSimpleColumn(new Paragraph("INSERT PAGE TEST"), 0, 0, 300, 700, 0, Element.ALIGN_RIGHT);
                // X起始點，Y起始點，X邊界，Y邊界
                ct.SetSimpleColumn(40, 700, 553, 100);
                ct.Go(); // 不加入這行，字不會出來

                pdfStamper.Close();

            }

        }

    }
}

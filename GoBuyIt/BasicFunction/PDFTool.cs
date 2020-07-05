using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GoBuyIt.BasicFunction
{

    public static class PDFTool
    {
        /// <summary>
        /// 文档字体BaseFont类引入字体类型
        /// </summary>
        private static readonly PdfFont HeadFont = PdfFontFactory.CreateFont(@"C:\windows\fonts\msjh.ttc,0", PdfEncodings.IDENTITY_H, false);


        public static void ExportListPDF<T>(List<T> DataList,string outputPath)
        {

            string PrintDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(outputPath);
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);

            // Title
            string Title = "撿貨單";
            PdfFont Titlefont = PdfFontFactory.CreateFont(@"C:\windows\fonts\msjh.ttc,0", PdfEncodings.IDENTITY_H, false);
            int TitlefontSize = 20;
            Paragraph header = new Paragraph($"{Title}")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetUnderline()
               .SetFont(Titlefont).SetFontSize(TitlefontSize);
            document.Add(header);

            PdfFont subItemfont = PdfFontFactory.CreateFont(@"C:\windows\fonts\msjh.ttc,0", PdfEncodings.IDENTITY_H, false);
            int subItemfontSize = 12;


            Table subItemTable = new Table(3, true);
            Cell cell11 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetBorder(Border.NO_BORDER)
               .Add(new Paragraph("廠商名稱:")
               .SetFont(subItemfont).SetFontSize(subItemfontSize));
            Cell cell12 = new Cell(1, 1)
               .SetTextAlignment(TextAlignment.LEFT)
               .SetBorder(Border.NO_BORDER)
               .Add(new Paragraph("廠商編號:")
               .SetFont(subItemfont).SetFontSize(subItemfontSize));
            Cell cell13 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph($"列印日期: {PrintDate}")
                .SetFont(subItemfont).SetFontSize(subItemfontSize));
            subItemTable.AddCell(cell11);
            subItemTable.AddCell(cell12);
            subItemTable.AddCell(cell13);

            document.Add(subItemTable);

            // Line separator
            LineSeparator ls = new LineSeparator(new SolidLine(4));
            document.Add(ls);

            document.Add(DataList.ToPdfPTable(PageSize.A4, true));


            document.Close();
        }
    
    /// <summary>
    /// 由List生成Table擴充方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="data"></param>
    /// <param name="rectangle"></param>
    /// <param name="isLandscape"></param>
    /// <returns></returns>
    public static Table ToPdfPTable<T>(this List<T> data, Rectangle rectangle, bool isLandscape = false)
        {
            PropertyInfo[] props = typeof(T).GetProperties();

            //设置Pdf表格Header
            Table table = new Table(props.Length, true);

            props.ToList().ForEach(p =>
            {
                Cell CellHeader = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.LEFT)
                .SetBorder(Border.NO_BORDER)
                .SetFont(HeadFont).SetFontSize(14)
                .Add(new Paragraph((p.GetCustomAttribute(typeof(DataMemberAttribute), true) as DataMemberAttribute).Name));

                table.AddCell(CellHeader);
            });

            //填充表格数据
            foreach (var item in data)
            {
                foreach (var prop in props)
                {
                    Cell CellHeader = new Cell(1, 1)
                        .SetTextAlignment(TextAlignment.LEFT)
                        .SetBorder(Border.NO_BORDER)
                        .Add(new Paragraph(GetValue(item, prop.Name)));
                    table.AddCell(CellHeader);
                }
            }
            return table;
        }

        /// <summary>
        /// 取得類別中該項目的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        private static string GetValue<T>(T t, string propertyName)
        {
            string str = string.Empty;
            var item = t.GetType().GetProperty(propertyName);
            if (item != null)
                str = item.GetValue(t, null).ToString();
            return str;
        }
    }
}

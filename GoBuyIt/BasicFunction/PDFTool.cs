using GoBuyIt.ViewModel;
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
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.IO;
using iText.IO.Image;



namespace GoBuyIt.BasicFunction
{

    public static class PDFTool
    {

        static string PrintDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
        /// <summary>
        /// 選擇輸出為單一檔案或是合併檔案
        /// </summary>
        /// <param name="individualList"></param>
        /// <param name="isIndividual"></param>
        public static void ExportIndividualList(Dictionary<string, List<OrderView>> individualList, bool isIndividual)
        {
            if (isIndividual)//多檔分開
            {
                individualList.Keys.ToList().ForEach(key =>
                {
                    string outputPath = System.IO.Path.Combine(DataAccess.PDFDefaultPath, $"{key}.pdf");
                    ExportListPDF(individualList[key], key, outputPath);
                });
            }
            else//單檔合併
            {
                individualList.Keys.ToList().ForEach(key =>
                {
                    string outputPath = System.IO.Path.Combine(DataAccess.PDFDefaultPath, "TotalOrder.pdf");
                    ExportListPDF(individualList, outputPath);
                });
            }
        }

        /// <summary>
        /// 依照訂單編號拆分為多個檔案
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="DataList"></param>
        /// <param name="outputPath"></param>
        public static void ExportListPDF<T>(List<T> DataList, string orderNumber, string outputPath)
        {

            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(outputPath);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document document = new Document(pdf);

            // Title
            string Title = "撿貨單";
            PdfFont Titlefont = PdfFontFactory.CreateFont(DataAccess.HeaderFontPath, PdfEncodings.IDENTITY_H, false);
            int TitlefontSize = 20;
            Paragraph header = new Paragraph($"{Title}")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetUnderline()
               .SetFont(Titlefont).SetFontSize(TitlefontSize);
            document.Add(header);

            //subItemTable
            PdfFont subItemfont = PdfFontFactory.CreateFont(DataAccess.ContentFontPath, PdfEncodings.IDENTITY_H, false);
            int subItemfontSize = 12;

            Table subItemTable = new Table(1, true);

            Cell cell13 = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.RIGHT)
                .SetBorder(Border.NO_BORDER)
                .Add(new Paragraph($"列印日期: {PrintDate}")
                .SetFont(subItemfont).SetFontSize(subItemfontSize));
            subItemTable.AddCell(cell13);

            document.Add(subItemTable);

            // Line separator
            LineSeparator lsfront = new LineSeparator(new SolidLine(4));
            document.Add(lsfront);

            document.Add(DataList.ToPdfPTable());

            // Line separator
            LineSeparator lsEnd = new LineSeparator(new SolidLine(4));
            document.Add(lsEnd);

            //插入物流單
            CreatePicture(System.IO.Path.Combine(DataAccess.LogisticsDirectoryPath, $"{orderNumber}{DataAccess.LogisticsFileNameExtensionType}"), document);

            document.Close();
        }

        /// <summary>
        /// 依照訂單編號合併成單一檔案
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="individualList"></param>
        /// <param name="outputPath"></param>
        public static void ExportListPDF<T>(Dictionary<string, List<T>> individualList, string outputPath)
        {
            // Must have write permissions to the path folder
            PdfWriter writer = new PdfWriter(outputPath);
            PdfDocument pdf = new PdfDocument(writer);
            pdf.SetDefaultPageSize(PageSize.A4.Rotate());
            Document document = new Document(pdf);

            individualList.Keys.ToList().ForEach(key =>
            {

                // Title
                PdfFont Titlefont = PdfFontFactory.CreateFont(DataAccess.HeaderFontPath, PdfEncodings.IDENTITY_H, false);
                int TitlefontSize = 20;
                Paragraph header = new Paragraph($"撿貨單")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetUnderline()
                   .SetFont(Titlefont).SetFontSize(TitlefontSize);
                document.Add(header);

                //subItemTable
                PdfFont subItemfont = PdfFontFactory.CreateFont(DataAccess.ContentFontPath, PdfEncodings.IDENTITY_H, false);
                int subItemfontSize = 12;

                Table subItemTable = new Table(1, true);

                Cell cell13 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph($"列印日期: {PrintDate}")
                    .SetFont(subItemfont).SetFontSize(subItemfontSize));
                subItemTable.AddCell(cell13);

                document.Add(subItemTable);


                // Line separator
                LineSeparator lsfront = new LineSeparator(new SolidLine(4));
                document.Add(lsfront);

                document.Add(individualList[key].ToPdfPTable());

                // Line separator
                LineSeparator lsEnd = new LineSeparator(new SolidLine(4));
                document.Add(lsEnd);

                //插入物流單
                CreatePicture(System.IO.Path.Combine(DataAccess.LogisticsDirectoryPath, $"{key}{DataAccess.LogisticsFileNameExtensionType}"), document);

                //插入分頁
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

            });
            //拿掉最後一頁空白
            pdf.RemovePage(pdf.GetNumberOfPages());
            //pdf.RemovePage(individualList.Keys.Count + 1);
            document.Close();
        }

        /// <summary>
        /// 由List生成Table擴充方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static Table ToPdfPTable<T>(this List<T> data)
        {

            PropertyInfo[] props = typeof(T).GetProperties();

            //设置Pdf表格Header
            Table table = new Table(props.Length, false);
            PdfFont HeadFont = PdfFontFactory.CreateFont(DataAccess.HeaderFontPath, PdfEncodings.IDENTITY_H, false);

            props.ToList().ForEach(p =>
            {
                var HeaderText = (p.GetCustomAttribute(typeof(DataMemberAttribute), true) as DataMemberAttribute).Name;
                Cell CellHeader = new Cell(1, 1)
                .SetTextAlignment(TextAlignment.CENTER)
                .SetBorder(Border.NO_BORDER)
                .SetFont(HeadFont).SetFontSize(12)
                .Add(new Paragraph(HeaderText));

                //調整欄位寬度
                if (HeaderText == "會員")
                    CellHeader.SetWidth(30);
                else
                    CellHeader.SetWidth(90);

                table.AddCell(CellHeader);
            });

            //填充表格数据
            PdfFont contentFont = PdfFontFactory.CreateFont(DataAccess.ContentFontPath, PdfEncodings.IDENTITY_H, false);
            data.ForEach(item =>
            {
                props.ToList().ForEach(prop =>
                {
                    Cell CellHeader = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.CENTER)
                    .SetBorder(Border.NO_BORDER)
                    .SetFont(contentFont).SetFontSize(10)
                    .Add(new Paragraph(GetValue(item, prop.Name)));

                    table.AddCell(CellHeader);
                });
            });

            return table;
        }

        /// <summary>
        /// 插入圖片
        /// </summary>
        /// <param name="document"></param>
        private static void CreatePicture(string photoPath, Document document)
        {

            if (File.Exists(photoPath))
            {
                //從新分頁開始
                document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));
                // Title
                PdfFont Titlefont = PdfFontFactory.CreateFont(DataAccess.HeaderFontPath, PdfEncodings.IDENTITY_H, false);
                int TitlefontSize = 20;
                Paragraph header = new Paragraph($"物流單")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetUnderline()
                   .SetFont(Titlefont).SetFontSize(TitlefontSize);
                document.Add(header);

                //subItemTable
                PdfFont subItemfont = PdfFontFactory.CreateFont(DataAccess.ContentFontPath, PdfEncodings.IDENTITY_H, false);
                int subItemfontSize = 12;

                Table subItemTable = new Table(2, true);


                Cell cell12 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.LEFT)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph($"訂單編號: {System.IO.Path.GetFileNameWithoutExtension(photoPath)}")
                    .SetFont(subItemfont).SetFontSize(subItemfontSize));
                subItemTable.AddCell(cell12);

                Cell cell13 = new Cell(1, 1)
                    .SetTextAlignment(TextAlignment.RIGHT)
                    .SetBorder(Border.NO_BORDER)
                    .Add(new Paragraph($"列印日期: {PrintDate}")
                    .SetFont(subItemfont).SetFontSize(subItemfontSize));
                subItemTable.AddCell(cell13);

                document.Add(subItemTable);

                //分隔線
                document.Add(new LineSeparator(new SolidLine(4)));
                document.Add(new Paragraph("\n"));
                Image fox = new Image(ImageDataFactory.Create(photoPath))
                .SetHorizontalAlignment(HorizontalAlignment.CENTER);

                document.Add(fox);
            }
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

            if (item != null && item.GetValue(t, null) != null)//本身不是null 而且內容取值也不是null
                str = item.GetValue(t, null).ToString();

            return str;
        }
    }
}

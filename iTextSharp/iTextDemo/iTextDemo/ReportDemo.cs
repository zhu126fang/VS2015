using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.VisualBasic.FileIO;

namespace iTextDemo
{
    public class ReportDemo
    {

        BaseFont BF_Light = BaseFont.CreateFont(@"C:\Windows\Fonts\simsun.ttc,0", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        string imagePath = "../../Data/分辨率使用情况报告_2014.04-2014.06.jpg";
        

        public ReportDemo()
        {

        }

        public void GeneratePDFReport()
        {
            Document document = new Document();
            using (document)
            {
               PdfWriter writer= PdfWriter.GetInstance(document, new FileStream(string.Format("{0}-{1}.pdf", DateTime.Now.Second, DateTime.Now.Millisecond),
                    FileMode.Create));

                document.Open();
                document.Add(GetBaseTable());            
                document.Add(GetBaseAndImageTable());

                DirectDrawReport(writer.DirectContentUnder);

                document.NewPage();

                document.Add(GetAllInfoTable());
            }
        }

        private PdfPTable GetAllInfoTable()
        {
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100f;
            table.SetWidths(new int[] { 1, 3, 2, 18 });

            PdfPCell cell;
            Paragraph p;
            int rowNum = 0;
            int textColumNum = 3;

            using (TextFieldParser parser = new TextFieldParser("../../Data/screen.csv", UTF8Encoding.UTF8, true))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (rowNum > 0)
                    {
                        for (int i = 0; i < textColumNum; i++)
                        {
                            p = new Paragraph(fields[i], new Font(BF_Light, 10));
                            cell = new PdfPCell(p);
                            cell.Border = Rectangle.NO_BORDER;
                            table.AddCell(cell);
                        }

                        string fileName = string.Format("../../Data/{0}.csv", fields[1]);
                        float yMax = float.Parse(fields[3]);
                        float yScale = float.Parse(fields[4]);
                        

                        cell = new PdfPCell(new Phrase(""));
                        cell.MinimumHeight = 55f;
                        cell.Border = Rectangle.NO_BORDER;
                        //画图的类，和cell关联                        
                        ResolutionChart chart = new ResolutionChart(fileName, yMax, yScale);
                        cell.CellEvent = chart;
                        table.AddCell (cell);
                        rowNum++;

                    }
                    else
                    {
                        rowNum++;
                    }
                }
            }
           

            return table;
        }

        private PdfPTable GetBaseAndImageTable()
        {
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100f;

            PdfPCell cell;

            //图片
            Image image = Image.GetInstance(imagePath);
            cell = new PdfPCell(image, true);
            table.AddCell(cell);

            //表格
            PdfPTable baseTable = GetBaseTable();
            cell = new PdfPCell(baseTable);
            table.AddCell(cell);

            table.SpacingBefore = 20f;

            return table;
        }

        private PdfPTable GetBaseTable()
        {
            PdfPTable table = new PdfPTable(3);

            PdfPCell cell;
            Paragraph p;
            int mainColumn = 3;
            int rowNum = 0;

            using (TextFieldParser parser = new TextFieldParser("../../Data/screen.csv", UTF8Encoding.UTF8, true))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields.Length > mainColumn-1)
                    {
                        for (int i = 0; i < mainColumn; i++)
                        {
                            //要设置字体和大小
                            p = new Paragraph(fields[i], new Font(BF_Light, 13));
                            cell = new PdfPCell(p);
                            //设置cell属性
                            //cell.Border = Rectangle.NO_BORDER;
                            if (rowNum == 0)
                            {
                                cell.BackgroundColor = BaseColor.GRAY;
                            }
                            if (i == mainColumn - 1)
                            {
                                cell.HorizontalAlignment = Element.ALIGN_RIGHT;
                            }
                            //添加单元格
                            table.AddCell(cell);
                        }
                        rowNum++;
                    }
                }
            }

            return table;
        }

        private void DirectDrawReport(PdfContentByte canvas)
        {
            //画线
            canvas.SaveState();
            canvas.SetLineWidth(2f);
            canvas.MoveTo(100, 100);
            canvas.LineTo(200, 200);
            canvas.Stroke();
            canvas.RestoreState();

            //文本
            ColumnText.ShowTextAligned(canvas, Element.ALIGN_RIGHT, new Phrase("JulyLuo测试", new Font(BF_Light, 10)), 100, 20, 0);
        }

        class ResolutionChart : IPdfPCellEvent
        {
            string fileName;
            float yMax;
            float yScaleNum;
            float marginLeft;
            float marginRight;
            float marginTop;
            float marginBottom;
           BaseFont BF_Light = BaseFont.CreateFont(ConfigurationManager.AppSettings["ReportFont"], BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            public ResolutionChart(string fileName, float yMax, float yScaleNum)
            {
                this.fileName = fileName;
                this.yMax = yMax;
                this.yScaleNum = yScaleNum;
                marginBottom =  marginRight = marginTop = 5f;
                marginLeft = 10f;
            }

            public void CellLayout(PdfPCell cell, Rectangle position, PdfContentByte[] canvases)
            {
                PdfContentByte cb = canvases[PdfPTable.BACKGROUNDCANVAS];
                PdfContentByte cbline = canvases[PdfPTable.LINECANVAS];

                cbline.SaveState();
                cb.SaveState();

                int totalMonths = 91;

                float leftX = position.Left + marginLeft;
                float bottomY = position.Bottom + marginBottom;

                float righX = position.Right - marginRight;
                float topY = position.Top - marginTop;

                float xScale = (righX - leftX) / totalMonths;
                float yScale = (topY - bottomY) / yMax;

                cb.SetLineWidth(0.4f);
                cbline.SetLineWidth(0.4f);
                //y 轴
                cb.MoveTo(leftX, bottomY);
                cb.LineTo(leftX, topY);
                cb.Stroke();
                //y 轴突出的短横线
                float yAxiseTextLinetWidth = 3f;
                float yAxisTextSpaceAdjust = 2.5f;
                for (float y = yScaleNum; y < yMax; y += yScaleNum)
                {
                    float yPoint = bottomY + (yScale * y);
                    cb.MoveTo(leftX, yPoint);
                    cb.LineTo(leftX - yAxiseTextLinetWidth, yPoint);
                    cb.Stroke();
                }
                //y 轴文本
                for (float y = yScaleNum; y < yMax; y += yScaleNum)
                {
                      float yPoint = bottomY + (yScale * y);
                      ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, new Phrase(string.Format("{0}%", y), new Font(BF_Light, 5)), leftX - yAxiseTextLinetWidth, yPoint - yAxisTextSpaceAdjust, 0);
                }
                
                //x 轴
                cb.MoveTo(leftX, bottomY);
                cb.LineTo(righX, bottomY);
                cb.Stroke();

                int monthNum = 1;

                cb.SetRGBColorStroke(0xFF, 0x45, 0x00);

                cbline.SetLineDash(2f);

                using (TextFieldParser parser = new TextFieldParser(fileName, UTF8Encoding.UTF8, true))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    while (!parser.EndOfData)
                    {
                        string[] fields = parser.ReadFields();
                        
                        if (fields.Length > 2)
                        {
                            float oneMonthValue=float.Parse(fields[1].TrimEnd('%'));
                            float xPoint = (monthNum - 1) * xScale + leftX;
                            float yPoint = bottomY + (yScale * oneMonthValue);

                            if (monthNum == 1)
                            {
                                cb.MoveTo(xPoint, yPoint);
                            }
                            else
                            {
                                cb.LineTo(xPoint, yPoint);
                            }

                            if (monthNum % 7 == 0)
                            {
                                cbline.MoveTo(xPoint, yPoint);
                                cbline.LineTo(xPoint, bottomY);
                               
                                cbline.Stroke();

                                string month = fields[0].Substring(7, 5);
                                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase(month, new Font(BF_Light, 5)), xPoint, bottomY-5f, 0);
                            }
                        }
                        monthNum++;
                    }
                }

                cb.Stroke();

                cb.RestoreState();
                cbline.RestoreState();
            }
        }
    }
}

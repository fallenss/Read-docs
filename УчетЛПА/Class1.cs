using OfficeOpenXml;
using OfficeOpenXml.Drawing;
using OfficeOpenXml.Drawing.Slicer;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace УчетЛПА
{
    class Class1
    {
        public byte[] Generate(List<Сотрудники> report)
        {
            FileInfo template = new FileInfo(@"C:\Windows\ЛПА\LPAReport.xlsx");

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage package = new ExcelPackage(null, template);
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];
            int row = 3;

            sheet.Columns.AutoFit();
            sheet.Column(1).Style.Numberformat.Format = "mm.dd.yyyy";
            sheet.Columns.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left; 
            foreach (Сотрудники aboitem in report)
                {
            foreach (ЛПА item in aboitem.Отдел.ЛПА)
            {

                    sheet.Cells[row, 1].Value = item.Наимемнование;
                    sheet.Cells[row, 2].Value = aboitem.Никнейм;
                    row++;
                }
            }

            PivotSlicers(sheet);
            sheet.Columns.AutoFit();
            return package.GetAsByteArray();
        }

        public byte[] DEGenerate(ЛПА report)
        {
            FileInfo template = new FileInfo(@"C:\Windows\ЛПА\Oznakomlenie.xlsx");

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage package = new ExcelPackage(null, template);
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];
            int row = 18;

            
            sheet.Columns.Style.HorizontalAlignment = ExcelHorizontalAlignment.Left;
            sheet.Cells[4, 2].Value = report.Отдел.Название_отдела;
            sheet.Cells[14, 2].Value =$"Отчёт по ознакомлению сотрудников {report.Отдел.Название_отдела}";
            sheet.Cells[15, 2].Value = $"с {report.Наимемнование}";
            bool chekus;
            foreach (var aboitem in ДипломEntities.GetContext().Сотрудники)
            {
                chekus = false;
                if (aboitem.Отдел == report.Отдел)
                {
                    sheet.Cells[row, 2].Value = row - 17;
                    sheet.Cells[row, 3].Value = aboitem.Никнейм;
                    foreach (var item1 in ДипломEntities.GetContext().Ознакомление)
                    {
                    
                         if (aboitem.ID == item1.id_сотрудника && item1.id_ЛПА == report.ID)
                         {
                            if (item1.Дата_время >= report.Дата_обновления && item1.Дата_время < report.Срок_контроля)
                            {
                                sheet.Cells[row, 4].Value = "Ознакомлен";
                                chekus = true;
                            }
                         }
        
                    }
                    if (chekus != true)
                    {
                        sheet.Cells[row, 4].Value = "Не ознакомлен";
                    }
                    row++;
                }
            }


            return package.GetAsByteArray();
        }

        public byte[] DEDEGenerate()
        {
            FileInfo template = new FileInfo(@"C:\Windows\ЛПА\Otdel.xlsx");

            ExcelPackage.LicenseContext = LicenseContext.Commercial;
            ExcelPackage package = new ExcelPackage(null, template);
            ExcelWorksheet sheet = package.Workbook.Worksheets[0];
            int row = 18;


            sheet.Columns.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            foreach (var aboitem in ДипломEntities.GetContext().Отдел)
            {
                int temp = 1;
                    
                    sheet.Cells[row, 3].Value = aboitem.Название_отдела;
                    foreach (var item1 in ДипломEntities.GetContext().ЛПА)
                    {

                        if (aboitem.ID==item1.id_отдела)
                        {
                        sheet.Cells[row, 2].Value = temp;
                        sheet.Cells[row, 4].Value = item1.Наимемнование;
                        temp++;
                        row++;
                        }

                    }

                    row++;
                
            }


            return package.GetAsByteArray();
        }

        private void PivotSlicers(ExcelWorksheet sheet)
        {
            var wsPivot = sheet.Workbook.Worksheets[1];
            ExcelPivotTableSlicer monthSlicer = wsPivot.PivotTables[0].Fields["ЛПА"].AddSlicer();
            monthSlicer.Caption = "ЛПА";
            monthSlicer.ChangeCellAnchor(eEditAs.Absolute);
            monthSlicer.SetPosition(80, 950);
            monthSlicer.SetSize(200, 600);
            monthSlicer.Style = eSlicerStyle.Other2;
        }
    }
}

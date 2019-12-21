using System.Collections.Generic;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using Backend.Common;
using Backend.Domain.Entities.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using OfficeOpenXml;
using OfficeOpenXml.Style.XmlAccess;
using OfficeOpenXml.Table;

namespace Backend.Service.Excel.Models
{
    public class ExportTrainingDataContainer: IExportDataContainer
    {
        public ApplicationUser User { get; set; }
        public IEnumerable<ExportTraining> Trainings { get; set; }
        public IEnumerable<string> Columns { get; set; }

        public (string Title, string Author, string Comments, string Company) GetExportFileProperties()
        {
            return (
                Title: $"{User.FullName} - Training data",
                Author: $"{User.FullName}", //TODO
                Comments: "Training report from - to... or entire report", // TODO
                Company: "Training companion d.o.o"
            );
        }

        public void WriteToSheet(ExcelWorksheet sheet, (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles)
        {
            var indexes = (
                FromColumn: 1,
                ToColumn: Columns.Count(),
                Row: 1,
                Cell: 1,
                ToRow: -1
            );

            foreach (var (training, index) in Trainings.WithIndex())
            {
                indexes.ToRow = training.Exercises.Aggregate(0, (acc, cur) => acc += cur.Sets.Count());

                CreateTable(sheet, indexes, $"Table{index}", styles);

                foreach (var column in Columns)
                {
                    sheet.Cells[indexes.Row, indexes.Cell++].Value = column.ToUpper();
                }

                indexes.Row += 1;
                indexes.Cell = 1;

                sheet.Cells[indexes.Row, indexes.Cell++].Value = training.Date?.ToString("dd/MM/yyyy");

                foreach (var exercise in training.Exercises)
                {
                    sheet.Cells[indexes.Row, indexes.Cell++].Value = exercise.Exercise;

                    var startCellValue = indexes.Cell;
                    foreach (var set in exercise.Sets)
                    {
                        if(Columns.Contains("Weight"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Weight;
                        
                        if (Columns.Contains("Reps"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Reps;
                        
                        if (Columns.Contains("Time"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Time;

                        if (Columns.Contains("RPE") || Columns.Contains("RIR"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Rpe;

                        if (Columns.Contains("Volume"))
                            sheet.Cells[indexes.Row, indexes.Cell++].Value = set.Volume;

                        indexes.Cell = startCellValue;
                        indexes.Row += 1;
                    }

                    indexes.Cell = 1;
                    indexes.Row += 1;
                }

                indexes.Row++;
            }
        }

        private void CreateTable(
            ExcelWorksheet sheet, 
            (int FromColumn, int ToColumn, int Row, int Cell, int ToRow) indexes, 
            string tableName, 
            (ExcelNamedStyleXml HeaderStyle, ExcelNamedStyleXml CellStyle) styles)
        {
            var table = sheet.Tables.Add(new ExcelAddressBase(indexes.Row, indexes.FromColumn, indexes.Row + indexes.ToRow, indexes.ToColumn), tableName);
            //table.TableStyle = TableStyles.Light1;
            table.DataCellStyleName = styles.CellStyle.Name;
            table.HeaderRowCellStyle = styles.HeaderStyle.Name;

            table.ShowTotal = true;
            table.Columns[Columns.IndexOf("Volume")].TotalsRowLabel = "Total Volume";
            table.Columns[Index: Columns.IndexOf("Volume")].TotalsRowFunction = RowFunctions.Sum;
        }
    }
}
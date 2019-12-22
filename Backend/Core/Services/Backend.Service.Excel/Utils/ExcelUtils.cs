using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Backend.Common;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.RefAndLookup;

namespace Backend.Service.Excel.Utils
{
    public static class ExcelUtils
    {
        public static ExcelWorkbook SetProperties(this ExcelWorkbook book, (string Title, string Author, string Comments, string Company) props)
        {
            book.Properties.Title = props.Title;
            book.Properties.Author = props.Author;
            book.Properties.Comments = props.Comments;
            book.Properties.Company = props.Company;

            return book;
        }

        public static async Task<Stream> GetResultStream(this ExcelPackage package)
        {
            package.Stream.Position = 0;

            var resultStream = new MemoryStream();
            await package.Stream.CopyToAsync(resultStream);
            resultStream.Position = 0;

            return resultStream;
        }

        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet) where T : new()
        {
            bool IsColumn(CustomAttributeData y) => y.AttributeType == typeof(Models.Import.Column);

            var typeColumns = typeof(T)
                    .GetProperties()
                    .Where(x => x.CustomAttributes.Any(IsColumn))
            .Select(p => new
            {
                Property = p,
                Column = p.GetCustomAttributes<Models.Import.Column>().First().ColumnName 
            }).ToList();

            var rows = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);

            var importColumns = new List<string>();
            for (var col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                var cellValue = worksheet.Cells[1, col].Value.ToString();

                if (string.IsNullOrEmpty(cellValue))
                    break;

                importColumns.Add(worksheet.Cells[1, col].Value.ToString());
            }

            var collection = new List<T>();
            for (var rowIndex = 1; rowIndex < rows.Count(); rowIndex++)
            {
                var row = rows.ElementAt(rowIndex);

                var newType = new T();

                foreach (var (column, index) in importColumns.WithIndex())
                {
                    var typeColumn = typeColumns.FirstOrDefault(x => x.Column.ToLower() == column.ToLower());
                    if (typeColumn == null)
                        continue;

                    //This is the real wrinkle to using reflection - Excel stores all numbers as double including int
                    var val = worksheet.Cells[row, index + 1];

                    //If it is numeric it is a double since that is how excel stores all numbers
                    if (val.Value == null)
                    {
                        typeColumn.Property.SetValue(newType, null);
                        continue;
                    }
                    if (typeColumn.Property.PropertyType == typeof(Int32))
                    {
                        typeColumn.Property.SetValue(newType, val.GetValue<int>());
                        continue;
                    }
                    if (typeColumn.Property.PropertyType == typeof(double))
                    {
                        typeColumn.Property.SetValue(newType, val.GetValue<double>());
                        continue;
                    }
                    if (typeColumn.Property.PropertyType == typeof(DateTime))
                    {
                        typeColumn.Property.SetValue(newType, val.GetValue<DateTime>());
                        continue;
                    }

                    //Its a string
                    typeColumn.Property.SetValue(newType, val.GetValue<string>());
                }

                collection.Add(newType);
            }

            return collection;
        }

    }
}
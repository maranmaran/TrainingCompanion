using Backend.Business.Import.Models;
using Backend.Common;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Backend.Business.Import
{
    public static class ExcelUtils
    {
        public static IEnumerable<T> ConvertSheetToObjects<T>(this ExcelWorksheet worksheet) where T : new()
        {
            bool IsColumn(CustomAttributeData y) => y.AttributeType == typeof(Column);

            // columns from model you wish to parse to
            var typeColumns = typeof(T)
                    .GetProperties()
                    .Where(x => x.CustomAttributes.Any(IsColumn))
            .Select(p => new
            {
                Property = p,
                Column = p.GetCustomAttributes<Column>().First().ColumnName,
                Required = p.GetCustomAttributes<Column>().First().Required
            }).ToList();

            // all excel data
            var rows = worksheet.Cells
                .Select(cell => cell.Start.Row)
                .Distinct()
                .OrderBy(x => x);

            // header columns
            var importColumns = new HashSet<string>();
            for (var col = 1; col <= worksheet.Dimension.End.Column; col++)
            {
                var cellValue = worksheet.Cells[1, col].Value.ToString();

                if (string.IsNullOrEmpty(cellValue))
                    break;

                if (importColumns.Contains(cellValue))
                    throw new Exception("Duplicate columns");

                importColumns.Add(cellValue);
            }

            // validate if all required columns are here
            var requiredCount = typeColumns.Count(x => x.Required);
            foreach (var header in importColumns)
            {
                var column = typeColumns.FirstOrDefault(x => x.Column.ToLower() == header.ToLower());
                if (column == null)
                {
                    throw new Exception("Invalid column");
                }

                if (column.Required)
                    requiredCount--;
            }

            if (requiredCount > 0)
                throw new Exception("Required columns missing");

            // map
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
                    if (typeColumn.Property.PropertyType == typeof(bool))
                    {
                        typeColumn.Property.SetValue(newType, val.GetValue<bool>());
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
using System;

namespace Backend.Service.Excel.Models.Import
{
    [AttributeUsage(AttributeTargets.All)]
    public class Column : System.Attribute
    {
        public string ColumnName { get; set; }

        public Column(string name)
        {
            ColumnName = name;
        }
    }
}
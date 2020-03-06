using System;

namespace Backend.Business.Import.Models
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
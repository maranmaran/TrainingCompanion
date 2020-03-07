namespace Backend.Business.Import.Models
{
    public class ImportColumn
    {
        public string Name { get; set; }
        public bool Required { get; set; }

        public ImportColumn(string name, bool required)
        {
            Name = name;
            Required = required;
        }
    }
}

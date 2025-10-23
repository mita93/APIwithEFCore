namespace WebAPIApp.Models
{
    public class Maintenance
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Description { get; set; }
        public List<Setting> Settings { get; set; }
    }
    public class Setting
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<SettingItem> Items { get; set; }
    }
    public class SettingItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ItemData { get; set; }
        public List<DataVariant> DataVariants { get; set; }
    }
    public class DataVariant
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string Description { get; set; }
    }
}

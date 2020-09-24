using Newtonsoft.Json;
using SQLite;

namespace SCCE.Data
{
    [Table("DataString")]
    public class DataTable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [JsonProperty("DataString")]
        public string DataString { get; set; }

    }
}

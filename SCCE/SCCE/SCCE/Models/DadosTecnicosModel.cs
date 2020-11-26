using Newtonsoft.Json;

namespace SCCE.Models
{
    public class DadosTecnicosModel
    {
        [JsonProperty("Key_Value")]
        public string Key_Value { get; set; }
        [JsonProperty("Mch_Code")]
        public string ID { get; set; }
        [JsonProperty("Attrib_Desc")]
        public string Descricao { get; set; }
        [JsonProperty ("Value_No")]
        public string ValorNo { get; set; }
        [JsonProperty ("Value_Text")]
        public string ValorTexto { get; set; }
        [JsonProperty ("Unit")]
        public string Unidade { get; set; }
    }
}

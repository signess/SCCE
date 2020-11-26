using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SCCE.Models
{
    public class ObjetoSerialModel
    {
        [JsonProperty("Contract")]
        public int Site { get; set; }

        [JsonProperty("Mch_Code")]
        public string Codigo { get; set; }

        [JsonProperty("Mch_Name")]
        public string Descricao { get; set; }

        [JsonProperty("Sup_Mch_Code")]
        public string Ligacao { get; set; }
        [JsonProperty("Mch_Type")]
        public string Tipo { get; set; }
        [JsonProperty("Serial_No")]
        public string NumeroSerie { get; set; }
        [JsonProperty("Patrimonio")]
        public string Patrimonio { get; set; }
        [JsonProperty("Nota")]
        public string Nota { get; set; }
        [JsonProperty("ClasseTecnica")]
        public string ClasseTecnica { get; set; }
        [JsonProperty ("DescricaoClasseTecnica")]
        public string DescricaoClasseTecnica { get; set; }
        [JsonProperty ("Key_Value")]
        public string KeyValue { get; set; }
        [TextBlob("dadosTecnicosBlobbled")]
        public List<DadosTecnicosModel> DadosTecnicos { get; set; }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
    }
}

using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class LocalidadeModel
    {
        public string Id => Guid.NewGuid().ToString();
        [JsonProperty("Contract")]
        public int Site { get; set; }

        [JsonProperty("Mch_Code")]
        public string Codigo { get; set; }

        [JsonProperty("Mch_Name")]
        public string Descricao { get; set; }

        [JsonProperty("Sup_Mch_Code")]
        public string Ligacao { get; set; }

        [JsonProperty("Obj_Level")]
        public string TipoDeObjeto { get; set; }

        [TextBlob("processosBlobbed")]
        public List<ProcessosModel> Processos { get; set; }
        public string Image { get; set; }
    }
}
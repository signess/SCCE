using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class ProcessosModel
    {
        public string Id => Guid.NewGuid().ToString("N");
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

        [TextBlob("objetoSerialBlobbled")]
        public List<ObjetoSerialModel> ObjetosSerial { get; set; }

        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
    }
}
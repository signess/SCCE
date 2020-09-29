using Newtonsoft.Json;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class LocalidadeModel
    {
        public string Id => Guid.NewGuid().ToString();
        [JsonProperty("codigo")]
        public int Codigo { get; set; }
        [JsonProperty("apelido")]
        public string Apelido { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("centroCusto")]
        public string CentroCusto { get; set; }
        [TextBlob("processosBlobbed")]
        public List<ProcessosModel> Processos { get; set; }
        public string Image { get; set; }
    }
}
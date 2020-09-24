using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class ProcessosModel
    {
        public string Id => Guid.NewGuid().ToString("N");
        [JsonProperty("Codigo")]
        public string Codigo { get; set; }
        [JsonProperty("Locins")]
        public string Locins { get; set; }
        [JsonProperty("Apelido")]
        public string Apelido { get; set; }
        [JsonProperty("Endereco")]
        public string Endereco { get; set; }
        [JsonProperty("Latitude")]
        public string Latitude { get; set; }
        [JsonProperty("Longitude")]
        public string Longitude { get; set; }
        [JsonProperty("Ativo")]
        public bool Ativo { get; set; }

        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
    }
}
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class RegionalModel
    {
        [JsonProperty("codigo")]
        public int Codigo { get; set; }
        [JsonProperty("sigla")]
        public string Sigla { get; set; }
        [JsonProperty("nome")]
        public string Nome { get; set; }
        [JsonProperty("centroCusto")]
        public string CentroCusto { get; set; }
        public List<LocalidadeModel> Localidades { get; set; }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
    }
}

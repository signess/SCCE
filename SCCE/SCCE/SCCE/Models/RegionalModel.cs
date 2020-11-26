using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace SCCE.Models
{
    public class RegionalModel
    {
        [JsonProperty("Contract")]
        public int Site { get; set; }
        [JsonProperty("Description")]
        public string Nome { get; set; }
        public List<ObjetoFuncionalModel> Localidades { get; set; }
        public string BackgroundStartColor { get; set; }
        public string BackgroundEndColor { get; set; }
        public bool IsClickable { get; set; }
    }
}

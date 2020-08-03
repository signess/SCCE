using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SCCE.Models
{
    public class UnidadeItem : Regional
    {
        public string Id => Guid.NewGuid().ToString("N");
        public override string Nome { get; set; }
        public string Image { get; set; }
        public List<ProcessosItem> ProcessosList { get; set; }

        public override string backgroundEndColor { get; set; }
        public override string backgroundStartColor { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SCCE.Models
{
    public class ProcessosItem
    {
        public string Id => Guid.NewGuid().ToString("N");
        public string Locins { get; set; }
        public string ProcessoName { get; set; }
        public string Address { get; set; }

        public BombaSubmersaItem BombaSubmersa { get; set; }

    }
}

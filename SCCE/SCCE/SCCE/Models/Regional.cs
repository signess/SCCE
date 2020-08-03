using System.Collections.Generic;

namespace SCCE.Models
{
    public class Regional : ItemModel
    {
        public override string Nome { get; set; }
        public override string backgroundStartColor { get; set; }
        public override string backgroundEndColor { get; set; }

        public List <UnidadeItem> Unidades { get; set; }

    }
}

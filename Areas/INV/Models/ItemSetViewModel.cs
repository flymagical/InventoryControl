using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Areas.INV.Models
{
    public class ItemSetViewModel : Dictionary<List<Guid>, int>
    {
        public string Label { get; set; }
        public int Support { get; set; }
        public string ListBarang { get; set; }
        public string Rules { get; set; }
        public int SupportAUB { get; set; }
        public int SupportA { get; set; }
        public decimal? Confidence { get; set; }
    }
}

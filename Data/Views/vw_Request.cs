using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControl.Data.Views
{
    public class vw_Request
    {
        public Guid Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ItemList { get; set; }
    }
}

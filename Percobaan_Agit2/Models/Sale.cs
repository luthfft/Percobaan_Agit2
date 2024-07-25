using System;
using System.Collections.Generic;

namespace Percobaan_Agit2.Models
{
    public partial class Sale
    {
        public long Id { get; set; }
        public string Item { get; set; } = null!;
        public decimal Revenue { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

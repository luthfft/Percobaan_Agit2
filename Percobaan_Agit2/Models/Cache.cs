﻿using System;
using System.Collections.Generic;

namespace Percobaan_Agit2.Models
{
    public partial class Cache
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
        public int Expiration { get; set; }
    }
}

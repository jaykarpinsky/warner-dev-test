﻿using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.Models
{
    public partial class OtherName : BaseEntity
    {
        public int? TitleId { get; set; }
        public string TitleNameLanguage { get; set; }
        public string TitleNameType { get; set; }
        public string TitleNameSortable { get; set; }
        public string TitleName { get; set; }

        public virtual Title Title { get; set; }
    }
}
using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.DTO
{
    public partial class TitleDTO : BaseDTO
    {
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? ReleaseYear { get; set; }
    }
}

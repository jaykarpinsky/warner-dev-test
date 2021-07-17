using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.Models
{
    public partial class Award : BaseEntity
    {
        public int TitleId { get; set; }
        public bool? AwardWon { get; set; }
        public int? AwardYear { get; set; }
        public string AwardCategory { get; set; }
        public string AwardCompany { get; set; }

        public virtual Title Title { get; set; }
    }
}

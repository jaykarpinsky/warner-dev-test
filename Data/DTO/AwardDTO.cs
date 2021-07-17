using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.DTO
{
    public partial class AwardDTO : BaseDTO
    {
        public int TitleId { get; set; }
        public bool? AwardWon { get; set; }
        public int? AwardYear { get; set; }
        public string AwardCategory { get; set; }
        public string AwardCompany { get; set; }

    }

}

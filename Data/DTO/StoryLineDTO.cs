using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.DTO
{
    public partial class StoryLineDTO : BaseDTO
    {
        public int TitleId { get; set; }
        public string Type { get; set; }
        public string Language { get; set; }
        public string Description { get; set; }

    }
}

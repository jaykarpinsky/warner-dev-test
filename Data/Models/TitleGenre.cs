using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.Models
{
    public partial class TitleGenre : BaseEntity
    {
        public int TitleId { get; set; }
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Title Title { get; set; }
    }
}

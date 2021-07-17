using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.Models
{
    public partial class Genre : BaseEntity
    {
        public Genre()
        {
            TitleGenres = new HashSet<TitleGenre>();
        }

        public string Name { get; set; }

        public virtual ICollection<TitleGenre> TitleGenres { get; set; }
    }
}

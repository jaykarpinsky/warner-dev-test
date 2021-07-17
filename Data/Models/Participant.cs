using System;
using System.Collections.Generic;

#nullable disable

namespace WarnerTestJK.Data.Models
{
    public partial class Participant : BaseEntity
    {
        public Participant()
        {
            TitleParticipants = new HashSet<TitleParticipant>();
        }

        public string Name { get; set; }
        public string ParticipantType { get; set; }

        public virtual ICollection<TitleParticipant> TitleParticipants { get; set; }
    }
}

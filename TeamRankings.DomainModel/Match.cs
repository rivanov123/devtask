using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamRankings.DomainModel
{
    [Table("Matches")]
    public class Match
    {
        public int Id { get; set; }

        public DateTime MatchDateTime { get; set; }

        public virtual ICollection<TeamMatchScore> TeamScores { get; set; }
    }
}

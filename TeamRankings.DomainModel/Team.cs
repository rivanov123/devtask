using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamRankings.DomainModel
{
    [Table("Teams")]
    public class Team
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public int Score { get; set; }

        public virtual ICollection<TeamMatchScore> TeamScores { get; set; }
    }
}

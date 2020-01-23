using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamRankings.DomainModel
{
    [Table("TeamMatchScores")]
    public class TeamMatchScore
    {
        [Key]
        public int Id { get; set; }

        public int TeamId { get; set; }

        public int Score { get; set; }

        public int MatchId { get; set; }

        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }

        [ForeignKey(nameof(MatchId))]
        public virtual Match Match { get; set; }
    }
}

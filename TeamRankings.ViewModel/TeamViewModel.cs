using System.ComponentModel.DataAnnotations;

namespace TeamRankings.ViewModel
{
    public class TeamViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(0,99)]
        public int Rank { get; set; }

        [Required]
        [Range(0,99)]
        public int Score { get; set; }
    }
}

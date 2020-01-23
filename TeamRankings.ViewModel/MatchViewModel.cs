using System;
using System.ComponentModel.DataAnnotations;

namespace TeamRankings.ViewModel
{
    public class MatchViewModel
    {
        public int Id { get; set; }

        [Required]
        [MustBeInThePast]
        public DateTime MatchDateTime { get; set; }

        [Required]
        public string TeamA { get; set; }

        [Required]
        public string TeamB { get; set; }

        [Range(0, 99)]
        [Required]
        public int TeamAScore { get; set; }

        [Range(0, 99)]
        [Required]
        public int TeamBScore { get; set; }
    }
}

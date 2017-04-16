﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BrotherBetsLibrary.Models
{
    public class Bet
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Prediction { get; set; }
        public DateTime Expiration { get; set; }
        [Required]
        [DisplayName("Bet Creator")]
        public string Creator { get; set; }
        public virtual Brother TargetOfBet { get; set; }
        public virtual List<BetOption> BetOptions { get; set; }
    }
}

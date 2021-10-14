﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Models
{
    public class Ability
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbilityId { get; set; }

        public string Name { get; set; }
        public int ManaCost { get; set; }
        public int DMG { get; set; }

        [NotMapped]
        public virtual Hero Hero { get; set; }

        [ForeignKey(nameof(Hero))]
        public int HeroId { get; set; }


    }
}
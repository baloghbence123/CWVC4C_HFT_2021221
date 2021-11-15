using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public virtual Hero Hero { get; set; }

        [ForeignKey(nameof(Hero))]
        public int HeroId { get; set; }

        public override string ToString()
        {
            return "Ability ID: " + AbilityId + " |Name: " + Name + " |Damage: " + DMG+" |HeroId: "+HeroId;
        }

    }
}
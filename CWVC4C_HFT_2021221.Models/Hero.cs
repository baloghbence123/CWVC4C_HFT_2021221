using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Models
{
    public class Hero
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HeroId { get; set; }

        public string Name { get; set; }

        public int AttackPower { get; set; }

        public int DefensePower { get; set; }

        [NotMapped]
        public virtual Element Element { get; set; }

        [ForeignKey(nameof(Element))]
        public int ElementId { get; set; }

        [NotMapped]
        public virtual ICollection<Ability> Abilities { get; set; }

        public Hero()
        {
            Abilities = new HashSet<Ability>();
        }




    }
}
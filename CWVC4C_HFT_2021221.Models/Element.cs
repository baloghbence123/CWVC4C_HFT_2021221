using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWVC4C_HFT_2021221.Models
{
    public class Element
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ElementId { get; set; }

        public string Name { get; set; }


        [NotMapped]
        public virtual ICollection<Hero> Heroes { get; set; }

        public Element()
        {
            Heroes = new HashSet<Hero>();
        }

    }
}
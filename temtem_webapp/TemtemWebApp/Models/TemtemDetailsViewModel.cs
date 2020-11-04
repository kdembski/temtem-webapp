using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemtemWebApp.Models
{
    public class TemtemDetailsViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public string LumaImage { get; set; }
        public string Trait1 { get; set; }
        public string Trait2 { get; set; }
        public string Type1Name { get; set; }
        public string Type1Icon { get; set; }
        public string Type1Defense { get; set; }
        public string Type2Name { get; set; }
        public string Type2Icon { get; set; }
        public string Type2Defense { get; set; }
        public string DualTypeDefense { get; set; }
        public int HP { get; set; }
        public int STA { get; set; }
        public int SPD { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPATK { get; set; }
        public int SPDEF { get; set; }
        public string PreEvolution { get; set; }
        public string Evolution { get; set; }
    }
}
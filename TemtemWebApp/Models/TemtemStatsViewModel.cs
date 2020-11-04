using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemtemWebApp.Models
{
    public class TemtemStatsViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Trait1 { get; set; }
        public string Trait2 { get; set; }
        public string Type1 { get; set; }
        public string Type2 { get; set; }
        public int HP { get; set; }
        public int STA { get; set; }
        public int SPD { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPATK { get; set; }
        public int SPDEF { get; set; }
        public int Total { get; set; }
    }
}
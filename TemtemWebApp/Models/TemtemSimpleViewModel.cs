using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemtemWebApp.Models
{
    public class TemtemSimpleViewModel
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Image { get; set; }
        public string TypeName1 { get; set; }
        public string TypeIcon1 { get; set; }
        public string TypeName2 { get; set; }
        public string TypeIcon2 { get; set; }
    }
}
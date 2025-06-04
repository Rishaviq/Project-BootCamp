using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models
{
    public class WorkSpace
    {
        public int spaceId { get; set; }
        [Required]  
        public int SpaceLocationFloor { get; set; }
        [Required]
        public required string SpaceLocationZone { get; set; }
        [Required]
        public bool HasMonitor { get; set; }
        [Required]
        public bool hasDockStation { get; set; }
        [Required]
        public bool HasWindow { get; set; }
        [Required]
        public bool HasPrinter { get; set; }

    }
}

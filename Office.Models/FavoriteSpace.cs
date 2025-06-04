using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office.Models
{
    public class FavoriteSpace
    {
        public int id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int SpaceId { get; set; }
    }
}

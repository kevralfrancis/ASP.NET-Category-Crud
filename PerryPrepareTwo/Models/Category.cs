using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PerryPrepareTwo.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter your Name"), MaxLength(50)]
        public string Name { get; set; }
        
        public int DisplayOrder { get; set; }

        public DateTime CreatedDateime { get; set; }
    }
}

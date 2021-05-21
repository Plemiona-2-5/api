using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Dtos
{
    public class TribeDescriptionDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}

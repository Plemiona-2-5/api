using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Dtos
{
    public class TribeDescriptionDto
    {
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}

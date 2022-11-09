using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FreeCourses.Web.Models.Catalogs
{
    public class FeatureViewModel
    {
        [Display(Name = "Kurs süre")]
        [Required]
        public int Duration { get; set; }
    }
}

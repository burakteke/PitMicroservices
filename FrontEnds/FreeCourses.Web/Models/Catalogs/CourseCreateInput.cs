using System.ComponentModel.DataAnnotations;

namespace FreeCourses.Web.Models.Catalogs
{
    public class CourseCreateInput
    {
        [Display(Name="Kurs ismi")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Kurs fiyat")]
        [Required]
        public decimal Price { get; set; }
        public string? UserId { get; set; }
        public string? Picture { get; set; }
        public FeatureViewModel Feature { get; set; } //bire bir ilişki
        [Display(Name = "Kurs kategori")]
        [Required]
        public string CategoryId { get; set; }//bire çok
        [Display(Name = "Kurs açıklama")]
        [Required]
        public string Description { get; set; }
    }
}

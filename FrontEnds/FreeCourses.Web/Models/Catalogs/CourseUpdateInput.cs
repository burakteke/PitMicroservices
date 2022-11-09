namespace FreeCourses.Web.Models.Catalogs
{
    public class CourseUpdateInput
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string? Picture { get; set; }
        public FeatureViewModel Feature { get; set; } //bire bir ilişki
        public string CategoryId { get; set; }//bire çok
        public string Description { get; set; }
    }
}

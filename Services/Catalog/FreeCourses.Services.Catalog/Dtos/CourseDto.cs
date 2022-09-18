using FreeCourses.Services.Catalog.Models;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace FreeCourses.Services.Catalog.Dtos
{
    internal class CourseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string UserId { get; set; }
        public string Picture { get; set; }
        public DateTime CreatedTime { get; set; }
        public FeatureDto Feature { get; set; } //bire bir ilişki
        public string CategoryId { get; set; }//bire çok
        public string Description { get; set; }
        public CategoryDto Category { get; set; }
    }
}

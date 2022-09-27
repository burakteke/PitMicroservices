namespace FreeCourses.Services.Basket.Dtos
{
    public class BasketItemDto
    {
        public int Quantity { get; set; }
        public string CourseId { get; set; } //mongodb'de string olarak tutuluyordu. Bu yüzden string Id
        public string CourseName { get; set; }
        public decimal Price { get; set; }
    }
}

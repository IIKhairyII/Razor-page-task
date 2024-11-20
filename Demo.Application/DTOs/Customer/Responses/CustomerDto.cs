namespace Demo.Application.DTOs.Customer.Responses
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public float Age { get; set; }
        public bool IsActive { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public bool IsActive { get; set; }
    }
}

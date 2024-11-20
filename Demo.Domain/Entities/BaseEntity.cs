using System.ComponentModel.DataAnnotations;

namespace Demo.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

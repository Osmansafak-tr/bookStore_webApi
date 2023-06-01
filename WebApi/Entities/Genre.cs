using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

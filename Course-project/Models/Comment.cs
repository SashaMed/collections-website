using System.ComponentModel.DataAnnotations;

namespace Course_project.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public string? Message { get; set; }
    }
}

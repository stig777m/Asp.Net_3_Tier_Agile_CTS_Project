using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_demo_1.DAL.Models
{
    public class Epics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int ProjectCode { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int SprintId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime CompletedOn { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("InProgress|Done", ErrorMessage = "Status should be either InProgress or Done")]
        public string Status { get; set; }

        //for foreign key
        public ICollection<UserStories> UserStories { get; set; }


    }
}

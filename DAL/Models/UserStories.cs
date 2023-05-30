using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace project_demo_1.DAL.Models
{
    public class UserStories
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(1000)]
        public string UserStoriesDetails { get; set; }

        [Required]
        [StringLength(1000)]
        public string AcceptanceCriteria { get; set; }

        [Required]
        [StringLength(2)]
        public string Priority { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime DoneOn { get; set; }

        [Required]
        [StringLength(6)]
        public string AssignedToDeveloperId { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Story points should be in the range 1-20")]
        public int StoryPoints { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("New|Planning|Coding|Testing|Done", ErrorMessage = "Status should be either New/Planning/Coding/Testing/Done")]
        public string Status { get; set; }



        [ForeignKey("Epics")]
        public int EpicsId { get; set; }
        //reference for one to many realtion
        public virtual Epics Epics { get; set; } 

        
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using project_demo_1.DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace project_demo_1.BLL.DTOs
{
    public class UserStoriesDTO
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string UserStoriesDetails { get; set; }

        [Required]
        public string AcceptanceCriteria { get; set; }

        [Required]
        public string Priority { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime DoneOn { get; set; }

        [Required]
        public string AssignedToDeveloperId { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "Story points should be in the range 1-20")]
        public int StoryPoints { get; set; }

        [Required]
        [RegularExpression("New|Planning|Coding|Testing|Done", ErrorMessage = "Status should be either New/Planning/Coding/Testing/Done")]
        public string Status { get; set; }

        public int EpicsId { get; set; }


        public static explicit operator UserStories(UserStoriesDTO usdto)
        {
            if (usdto == null)
            {
                return null;
            }
            return new UserStories
            {
                Title = usdto.Title,
                UserStoriesDetails = usdto.UserStoriesDetails,
                AcceptanceCriteria = usdto.AcceptanceCriteria,
                Priority = usdto.Priority,
                CreatedOn = usdto.CreatedOn,
                DoneOn = usdto.DoneOn,
                AssignedToDeveloperId = usdto.AssignedToDeveloperId,
                StoryPoints = usdto.StoryPoints,
                Status = usdto.Status,
                EpicsId = usdto.EpicsId
            };

        }

        public static implicit operator UserStoriesDTO(UserStories dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new UserStoriesDTO
            {
                Title = dto.Title,
                UserStoriesDetails = dto.UserStoriesDetails,
                AcceptanceCriteria = dto.AcceptanceCriteria,
                Priority = dto.Priority,
                CreatedOn = dto.CreatedOn,
                DoneOn = dto.DoneOn,
                AssignedToDeveloperId = dto.AssignedToDeveloperId,
                StoryPoints = dto.StoryPoints,
                Status = dto.Status,
                EpicsId = dto.EpicsId
            };

        }
    }
}

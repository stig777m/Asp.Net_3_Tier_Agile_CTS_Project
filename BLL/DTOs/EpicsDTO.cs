using project_demo_1.DAL.Models;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.Xml;

namespace project_demo_1.BLL.DTOs
{
    public class EpicsDTO
    {
        [Key]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int Id { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int ProjectCode { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid interger number")]
        public int SprintId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public DateTime CompletedOn { get; set; }

        [Required]
        [RegularExpression("InProgress|Done", ErrorMessage = "Status should be either InProgress or Done")]
        public string Status { get; set; }


        //explicit operator
        public static explicit operator Epics(EpicsDTO edto)
        {
            if (edto == null)
            {
                return null;
            }
            return new Epics
            {
                Id = edto.Id,
                ProjectCode = edto.ProjectCode,
                SprintId = edto.SprintId,
                Name = edto.Name,
                CreatedOn = edto.CreatedOn,
                CompletedOn = edto.CompletedOn,
                Status = edto.Status,
            };
        }

        public static implicit operator EpicsDTO(Epics dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new EpicsDTO
            {
                Id = dto.Id,
                ProjectCode = dto.ProjectCode,
                SprintId = dto.SprintId,
                Name = dto.Name,
                CreatedOn = dto.CreatedOn,
                CompletedOn = dto.CompletedOn,
                Status = dto.Status,
            };
        }
    }
}

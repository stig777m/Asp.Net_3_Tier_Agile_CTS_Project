using project_demo_1.DAL.Models;

namespace project_demo_1.BLL.DTOs
{
    public class BacklogReportDTO
    {
        public string? EpicName { get; set; }

        public float EpicProgress { get; set; }

        public int New { get; set; } = 0;

        public int Planning { get; set; } = 0;

        public int Coding { get; set; } = 0;

        public int Testing { get; set; } = 0;

        public int Done { get; set; } = 0;


        public static implicit operator BacklogReportDTO?(BacklogReport dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new BacklogReportDTO
            { 
                EpicName = dto.EpicName,
                EpicProgress = dto.EpicProgress,
                New = dto.New,
                Planning = dto.Planning,
                Coding = dto.Coding,
                Testing = dto.Testing,
                Done = dto.Done
            };
        }

        public static explicit operator BacklogReport?(BacklogReportDTO dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new BacklogReport
            {
                EpicName = dto.EpicName,
                EpicProgress = dto.EpicProgress,
                New = dto.New,
                Planning = dto.Planning,
                Coding = dto.Coding,
                Testing = dto.Testing,
                Done = dto.Done
            };
        }

    }
}

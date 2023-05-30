using project_demo_1.DAL.Models;
using project_demo_1.BLL.DTOs;

namespace project_demo_1.BLL.Service
{
    public interface IUtilService
    {
        public Task<EpicsDTO> AddNewEpic(EpicsDTO newEpic);

        public Task<List<BacklogReportDTO>> ProductBacklogReport(int productId);

    }
}

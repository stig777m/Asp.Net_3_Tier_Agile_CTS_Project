using project_demo_1.DAL.Models;

namespace project_demo_1.DAL.Repository
{
    public interface IUtilRepository
    {
        public Task<Epics> AddNewEpic(Epics newEpic);

        public Task<List<Epics>> GetAllEpics();

        public int GetDevUserStoriesCnt(string devId);

        public Task<List<BacklogReport>> ProductBacklogReport(int productId);
    }
}
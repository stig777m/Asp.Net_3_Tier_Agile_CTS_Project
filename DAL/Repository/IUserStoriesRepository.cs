using project_demo_1.DAL.Models;

namespace project_demo_1.DAL.Repository
{
    public interface IUserStoriesRepository
    {
        public Task<UserStories> AddNewUserStories(UserStories newUserStories);

        public Task<List<UserStories>> GetAllUserStories();

        public UserStories UpdateStory(int userStoryId, string newStatus);

        public bool changeEpicStatus(int userStoryId);

        public Task<List<UserStories>> GetUserStoriesByDevId(string DevId);

        public UserStories GetUserStoryById(int userStoryId);
    }
}

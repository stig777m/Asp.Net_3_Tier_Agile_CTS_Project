using project_demo_1.BLL.DTOs;
using project_demo_1.DAL.Models;

namespace project_demo_1.BLL.Service
{
    public interface IUserStoriesService
    {
        public Task<UserStoriesDTO> AddNewUserStories(UserStoriesDTO newUserStoriesDTO);

        public Task<List<UserStoriesDTO>> GetAllUserStories();

        public Task<List<UserStoriesDTO>> GetUserStoriesByDevId(string DevId);

        public UserStoriesDTO UpdateStory(int userStoryId, string newStatus);

        public UserStoriesDTO GetUserStoryById(int userStoryId);
    }
}
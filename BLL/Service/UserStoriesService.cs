using project_demo_1.BLL.DTOs;
using project_demo_1.DAL.Models;
using project_demo_1.DAL.Repository;

namespace project_demo_1.BLL.Service
{
    public class UserStoriesService : IUserStoriesService
    {
        private readonly IUserStoriesRepository userStoriesRepository;

        public UserStoriesService(IUserStoriesRepository userStoriesRepository)
        {
            this.userStoriesRepository = userStoriesRepository;
        }

        public async Task<UserStoriesDTO> AddNewUserStories(UserStoriesDTO newUserStoriesDTO)
        {
            //char[] delimiters = new char[] { ',', ' ', '\r', '\n', '\t' };
            //int titleCnt = newUserStoriesDTO.Title.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            //int detailsCnt = newUserStoriesDTO.UserStoriesDetails.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            //int accCnt = newUserStoriesDTO.AcceptanceCriteria.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;
            //if (titleCnt < 10)
            //{
            //    throw new Exception("The Entered title is less than 10 words");
            //}
            //if (detailsCnt < 50)
            //{
            //    throw new Exception("The Entered Details is less than 50 words");
            //}
            //if (accCnt < 50)
            //{
            //    throw new Exception("The Entered acceptance criteria is less than 50 words");
            //}


            //if (utilRepository.GetDevUserStoriesCnt(newUserStoriesDTO.AssignedToDeveloperId) >= 5)
            //{
            //    //return dev has already 5 ongoing userstories, change devid
            //    throw new Exception("The Develop already has 5 active userStories, change devId");
            //}

            return await userStoriesRepository.AddNewUserStories((UserStories)newUserStoriesDTO);
        }

        public async Task<List<UserStoriesDTO>> GetAllUserStories()
        {
            var lst = await userStoriesRepository.GetAllUserStories();
            return lst.Select(userStories => (UserStoriesDTO)userStories).ToList();
        }

        public async Task<List<UserStoriesDTO>> GetUserStoriesByDevId(string DevId)
        {
            var lst = await userStoriesRepository.GetUserStoriesByDevId(DevId);
            return lst.Select(u => (UserStoriesDTO)u).ToList();
        }

        public UserStoriesDTO UpdateStory(int userStoryId, string newStatus)
        {
            var tmp = (UserStoriesDTO)userStoriesRepository.UpdateStory(userStoryId, newStatus);
            if (newStatus == "Done")
            {
                if (userStoriesRepository.changeEpicStatus(userStoryId))
                {
                    Console.WriteLine("All epic stories are done so epic is done");
                }
            }
            return (tmp);
        }

        public UserStoriesDTO GetUserStoryById(int userStoryId)
        {
            return (UserStoriesDTO)userStoriesRepository.GetUserStoryById(userStoryId);
        }
    }
}

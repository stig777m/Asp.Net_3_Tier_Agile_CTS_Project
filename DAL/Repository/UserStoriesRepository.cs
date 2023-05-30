using Microsoft.EntityFrameworkCore;
using project_demo_1.DAL.Data;
using project_demo_1.DAL.Models;

namespace project_demo_1.DAL.Repository
{
    public class UserStoriesRepository : IUserStoriesRepository
    {
        private ContextFile _context;

        public UserStoriesRepository(ContextFile context) 
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public async Task<UserStories> AddNewUserStories(UserStories newUserStories)
        {
            await _context.UserStoriesS.AddAsync(newUserStories);
            await _context.SaveChangesAsync();
            return newUserStories;
        }

        public async Task<List<UserStories>> GetAllUserStories()
        {
            return await _context.UserStoriesS.ToListAsync();
        }

        public UserStories UpdateStory(int userStoryId, string newStatus)
        {
            var us =_context.UserStoriesS.SingleOrDefault(u => u.Id == userStoryId);
            if (us != null)
            {
                us.Status = newStatus;
            }
            _context.SaveChanges();
            return us;
        }

         // method to update epic when all userStories are done
        public bool changeEpicStatus(int userStoryId)
        {
            var epic = _context.UserStoriesS.FirstOrDefault(u => u.Id == userStoryId);
            var epicId = epic.EpicsId;
            if(_context.UserStoriesS.Count(x =>x.EpicsId == epicId) == 
                _context.UserStoriesS.Count(u => u.EpicsId == epicId && u.Status == "Done"))
            {
                var st =_context.EpicsS.SingleOrDefault(e => e.Id == epicId);
                st.Status = "Done";
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<UserStories>> GetUserStoriesByDevId(string DevId)
        {
            return await _context.UserStoriesS.Where(u => u.AssignedToDeveloperId == DevId).ToListAsync();
        }

        public UserStories GetUserStoryById(int userStoryId)
        {
            return _context.UserStoriesS.SingleOrDefault(u => u.Id == userStoryId);
        }
    }
}

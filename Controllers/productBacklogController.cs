using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using project_demo_1.DAL.Data;
using project_demo_1.DAL.Models;
using project_demo_1.DAL.Repository;
using project_demo_1.BLL.Service;
using project_demo_1.BLL.DTOs;
using Microsoft.AspNetCore.Authorization;
//using System.Web.Http;

namespace project_demo_1.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class productBacklogController : Controller
    {
        private readonly IUtilService _utilService;

        private readonly IUserStoriesService _userStoriesService;
        

        public productBacklogController(IUtilService utilService, IUserStoriesService userStoriesService)
        {
            this._utilService = utilService;
            this._userStoriesService = userStoriesService;
        }

        [Authorize(Roles ="ProductOwner")]
        [HttpPost("createEpics")]
        [Consumes(contentType:"application/json")]
        public async Task<IActionResult> NewEpicUserStories([FromBody] EpicsDTO _epicsDTO)
        {
            var result =await _utilService.AddNewEpic(_epicsDTO);
            if (result==null) 
                    return NotFound();
            Console.WriteLine("inside newEpics");
            return Ok(result);
        }

        [Authorize(Roles = "ProductOwner")]
        [HttpPost("createUserStories")]
        [Consumes(contentType: "application/json")]
        public async Task<IActionResult> NewUserStories([FromBody] UserStoriesDTO _userStoriesDTO)
        {
            var result = await _userStoriesService.AddNewUserStories(_userStoriesDTO);
            if (result == null)
                return NotFound();
            Console.WriteLine("inside newUseStories");
            return Ok(result);
        }



        [HttpGet]
        [Route("GetAlluserstories")]
        public async Task<IActionResult> GetAllUserStories()
        {
            var userStories =await _userStoriesService.GetAllUserStories();
            if (userStories == null)
                return StatusCode(500);
            return Ok(userStories);
        }

        [Authorize(Roles = "Developer")]
        [HttpGet]
        [Route("GetUserStoriesByDevId/{DevId}")]
        public async Task<IActionResult> GetUserStoriesByDevId(string DevId)
        {
            var userStories =await _userStoriesService.GetUserStoriesByDevId(DevId);
            if (userStories == null)
                return StatusCode(500);
            return Ok(userStories);
        }


        [Authorize(Roles = "Developer")]
        [HttpPut("UpdateStory/{userStoryId}")]
        public async Task<IActionResult> UpdateStory(int userStoryId, string newStatus)
        {
            var res = _userStoriesService.UpdateStory(userStoryId, newStatus);
            if (res==null) 
                return StatusCode(500);
            Console.WriteLine("inside UpdateUserStoryStatus");
            return Ok(res);
        }

        //one remaining
        //[Authorize(Roles = "ProductOwner")]
        [HttpGet]
        [Route("report/{projectId}")]
        public async Task<IActionResult> GetBackLogReport(int projectId)
        {   
            var result = await _utilService.ProductBacklogReport(projectId);
            if (result == null)
                return StatusCode(500);
            return Ok(result);
        }


        [Authorize(Roles = "Developer")]
        [HttpGet]
        [Route("GetUserStoryById/{userStoryId}")]
        public async Task<IActionResult> GetUserStoryById(int userStoryId)
        {
            var userStories = _userStoriesService.GetUserStoryById(userStoryId);
            if (userStories == null)
                return StatusCode(500);
            return Ok(userStories);
        }
    }
}

using project_demo_1.BLL.DTOs;
using project_demo_1.DAL.Models;
using project_demo_1.DAL.Repository;
using project_demo_1.BLL.Exceptions;
using System.Text.RegularExpressions;

namespace project_demo_1.BLL.Service
{
    public class UtilService : IUtilService
    {
        private readonly IUtilRepository utilRepository;
        

        public UtilService(IUtilRepository utilRepository) 
        {
            this.utilRepository=utilRepository;
            
        }


        public async Task<EpicsDTO> AddNewEpic(EpicsDTO newEpicDTO)
        {
            if (newEpicDTO.Id < 0)
                throw new BadRequestException("Id should be a positive integer");
            
            if(newEpicDTO.ProjectCode < 0)
                throw new BadRequestException("Project Code should be a positive integer");

            if (newEpicDTO.SprintId < 0)
                throw new BadRequestException("Sprint Id should be a positive integer");

            if(newEpicDTO.Name.Length < 3)
                throw new BadRequestException("Name should be minimum 3 characters");
            if(!Regex.IsMatch(newEpicDTO.Name, @"[a-zA-Z]+$"))
                throw new BadRequestException("Name should only contain alphabets");

            if(newEpicDTO.CompletedOn < newEpicDTO.CreatedOn)
                throw new BadRequestException("Completed date cannot be before created date");

            return await utilRepository.AddNewEpic((Epics)newEpicDTO);
        }


        public async Task<List<BacklogReportDTO?>> ProductBacklogReport(int productId)
        {
            var list = await utilRepository.ProductBacklogReport(productId);
            return list.Select(backlogreport=>(BacklogReportDTO?)backlogreport).ToList();
        }


    }
}

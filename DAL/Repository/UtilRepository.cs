using Microsoft.EntityFrameworkCore;
using project_demo_1.BLL.DTOs;
using project_demo_1.DAL.Data;
using project_demo_1.DAL.Models;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;


namespace project_demo_1.DAL.Repository

{
    public class UtilRepository : IUtilRepository
    {
        private ContextFile _context;

        public UtilRepository(ContextFile context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }


        //inserting new epics
        public async Task<Epics> AddNewEpic(Epics newEpic)
        {
            await _context.EpicsS.AddAsync(newEpic);
            await _context.SaveChangesAsync();
            return newEpic;
        }

        public async Task<List<Epics>> GetAllEpics()
        {
            var tmp = await Task.FromResult(_context.EpicsS.ToList());
            return tmp;
        }
        

        public int GetDevUserStoriesCnt(string devId)
        { 
            return _context.UserStoriesS.Count(c=>c.AssignedToDeveloperId == devId &&
            (c.Status == "New" || c.Status == "Planning" || c.Status == "Coding"));
        }


        //creating the report usign the epic and userstories
        public async Task<List<BacklogReport>> ProductBacklogReport(int productId)
        {
            List<BacklogReport> blReport = new List<BacklogReport>();
            BacklogReport? rtemp = new BacklogReport() {EpicName="Temp1",EpicProgress=0,New=2,Planning=3,Coding=4,Testing=5,Done=6 };
            blReport.Add(rtemp);
            var Ids = await _context.EpicsS.Where(y => y.ProjectCode == productId).Select(x => x.Id).ToListAsync();
            foreach (var epicIdItem in Ids)
            {
                Epics? e = _context.EpicsS.SingleOrDefault(x => x.Id == epicIdItem);
                if (e == null)
                    continue;
                BacklogReport? r = new BacklogReport();
                r.EpicName = e.Name;
                r.EpicProgress = 0;
                var res = await _context.UserStoriesS.Where(u => u.EpicsId == epicIdItem).GroupBy(u => u.Status).Select(g => new { Status = g.Key, count = g.Count() }).ToListAsync();
                Console.WriteLine(res[0].count);
                
                r.New=res[0].count;
                r.Planning = res[1].count;
                r.Coding = res[2].count;
                r.Testing = res[3].count;
                r.Done = res[4].count;



                //r.EpicName = e.Name;
                //r.EpicProgress = 0;
                //r.New = _context.UserStoriesS.Count(x => x.EpicsId == epicIdItem && x.Status == "New");
                //r.Planning = _context.UserStoriesS.Count(x => x.EpicsId == epicIdItem && x.Status == "Planning");
                //r.Coding = _context.UserStoriesS.Count(x => x.EpicsId == epicIdItem && x.Status == "Coding");
                //r.Testing = _context.UserStoriesS.Count(x => x.EpicsId == epicIdItem && x.Status == "Testing");
                //r.Done = _context.UserStoriesS.Count(x => x.EpicsId == epicIdItem && x.Status == "Done");
                blReport.Add(r);
            }
            return blReport;
        }
    }
}

namespace project_demo_1.DAL.Models
{
    //model to store the report which will be created using epics and userStories
    public class BacklogReport
    {
        
        public string? EpicName { get; set; }

        public float EpicProgress { get; set; }

        public int New { get; set; } = 0;

        public int Planning { get; set; } = 0;

        public int Coding { get; set; } = 0;

        public int Testing { get; set; } = 0;

        public int Done { get; set; } = 0;
    }
}
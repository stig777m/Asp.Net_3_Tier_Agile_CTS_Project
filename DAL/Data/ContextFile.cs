using Microsoft.EntityFrameworkCore;
//using System.Data.Entity;
//using System.Web;
using System.Linq;
using project_demo_1.DAL.Models;
using System.Xml.Linq;

namespace project_demo_1.DAL.Data
{
    public class ContextFile : DbContext
    {
        public ContextFile(DbContextOptions<ContextFile> options) : base(options) { }

        public DbSet<Epics> EpicsS { get; set; }

        public DbSet<UserStories> UserStoriesS { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //renaming tables
            //modelBuilder.Entity<Epics>().ToTable("Epics");
            //modelBuilder.Entity<UserStories>().ToTable("UserStories");

            //inserting data to both tables for testing
            modelBuilder.Entity<Epics>().HasData(
                new Epics { Id = 10, ProjectCode = 20, SprintId = 30, Name = "stig0", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), CompletedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), Status = "InProgress"},
                new Epics { Id = 11, ProjectCode = 21, SprintId = 31, Name = "stig1", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), CompletedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), Status = "InProgress" },
                new Epics { Id = 12, ProjectCode = 22, SprintId = 32, Name = "stig2", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), CompletedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), Status = "InProgress" }
            );

            modelBuilder.Entity<UserStories>().HasData(
                new UserStories { Id = 100, Title = "us100", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "1", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev0", EpicsId = 10, Status = "New", StoryPoints = 3 },
                new UserStories { Id = 101, Title = "us101", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "1", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev3", EpicsId = 10, Status = "Planning", StoryPoints = 3 },
                new UserStories { Id = 110, Title = "us111", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "3", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev2", EpicsId = 11, Status = "New", StoryPoints = 3 },
                new UserStories { Id = 111, Title = "us111", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "3", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev2", EpicsId = 11, Status = "Planning", StoryPoints = 3 },
                new UserStories { Id = 112, Title = "us110", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "2", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev4", EpicsId = 11, Status = "Coding", StoryPoints = 3 },
                new UserStories { Id = 113, Title = "us111", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "3", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev2", EpicsId = 11, Status = "Testing", StoryPoints = 3 },
                new UserStories { Id = 114, Title = "us111", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "3", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev2", EpicsId = 11, Status = "Done", StoryPoints = 3 },
                new UserStories { Id = 115, Title = "us111", UserStoriesDetails = "us00details", AcceptanceCriteria = "rand", Priority = "3", CreatedOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), DoneOn = DateTime.Parse("2023-05-02T05:52:51.383Z"), AssignedToDeveloperId = "dev4", EpicsId = 11, Status = "Done", StoryPoints = 3 }
            );
            base.OnModelCreating(modelBuilder);
        }

    }
}

using KnowledgeBase.Models;
using System.Data.Entity;


namespace KnowledgeBase.DAL
{
    public class BaseContext : DbContext
    {

        public BaseContext(): base ("BaseContext") 
        {}

        public DbSet<Product> Products { get; set; }
        public DbSet<Issue> Issues { get; set; }
        public DbSet<Solution> Solutions { get; set; }
    }
}
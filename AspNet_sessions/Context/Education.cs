namespace AspNet_sessions.Context
{
    using AspNet_sessions.Models;
    using System.Data.Entity;

    public class Education : DbContext
    {
        public Education() : base("name=Education") {}

        public virtual DbSet<User> Users { get; set; }
    }

}
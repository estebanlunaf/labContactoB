namespace apiContactSecurity.Models
{
    using System.Data.Entity;

    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<apiContactSecurity.Models.Contact> Contacts { get; set; }
    }
}
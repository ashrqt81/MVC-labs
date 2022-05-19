using lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace lab6
{
    public class ITIDBContext:DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public ITIDBContext(DbContextOptions options) : base(options)
        {

        } 
    }
}

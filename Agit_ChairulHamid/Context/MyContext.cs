using Agit_ChairulHamid.Models;
using Microsoft.EntityFrameworkCore;

namespace Agit_ChairulHamid.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
        : base(options)
        {
        }

        public DbSet<MD_Produksi> Products { get; set; }
    }
}

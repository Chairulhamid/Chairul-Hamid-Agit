using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Agit_ChairulHamid.Models;
namespace Agit_ChairulHamid.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
            }

        public DbSet<MD_Produksi> MD_Produksis { get; set; }
    }
}

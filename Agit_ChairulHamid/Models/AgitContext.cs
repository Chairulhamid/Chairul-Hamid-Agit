using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
namespace Agit_ChairulHamid.Models
{
    public partial class AgitContext : DbContext
    {
        public AgitContext()
        {
        }

        public AgitContext(DbContextOptions<AgitContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       => optionsBuilder.UseSqlite("Name=DefaultConnection");
    }
      
}

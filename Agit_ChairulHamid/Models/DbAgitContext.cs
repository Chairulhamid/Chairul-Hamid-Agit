using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Agit_ChairulHamid.Models;

public partial class DbAgitContext : DbContext
{
    public DbAgitContext()
    {
    }

    public DbAgitContext(DbContextOptions<DbAgitContext> options)
        : base(options)
    {
    }
    public virtual DbSet<MD_Produksi> MD_Produksis { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

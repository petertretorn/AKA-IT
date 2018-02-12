using FormManager.Domain;
using Microsoft.EntityFrameworkCore;
using System;


namespace FormManager.Data
{
    public class FormContext : DbContext
    {
        public FormContext(DbContextOptions<FormContext> options) : base(options)
        {
            Database.Migrate();
        }
        
        public DbSet<Form> Forms { get; set; }
        public DbSet<UnemployedForm> UnemployedForms { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Form>()
        //        .HasOne(f => f.CaseWorker)
        //        .WithMany(c => c.Forms);
        //}
    }
}

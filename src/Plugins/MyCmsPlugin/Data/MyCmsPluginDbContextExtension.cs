using Microsoft.EntityFrameworkCore;
using MyCmsPlugin.Models;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace MyCmsPlugin.Data
{
    [ConnectionStringName("Default")]
    public class MyCmsPluginDbContextExtension : AbpDbContext<MyCmsPluginDbContextExtension>
    {
        public MyCmsPluginDbContextExtension(DbContextOptions<MyCmsPluginDbContextExtension> options) : base(options)
        {
        }

        public DbSet<PageModel> Pages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Todo : Configure your own tables
            modelBuilder.Entity<PageModel>(b =>
            {
                b.ToTable("CmsPages");
                b.ConfigureByConvention();
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

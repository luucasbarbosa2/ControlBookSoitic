using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using ControlBooks.EntityFramework;

namespace ControlBooks.Migrator
{
    [DependsOn(typeof(ControlBooksDataModule))]
    public class ControlBooksMigratorModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer<ControlBooksDbContext>(null);

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using ControlBooks.EntityFramework;

namespace ControlBooks
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(ControlBooksCoreModule))]
    public class ControlBooksDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ControlBooksDbContext>());

            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

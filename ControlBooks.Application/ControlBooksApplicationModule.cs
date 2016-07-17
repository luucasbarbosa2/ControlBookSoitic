using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace ControlBooks
{
    [DependsOn(typeof(ControlBooksCoreModule), typeof(AbpAutoMapperModule))]
    public class ControlBooksApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

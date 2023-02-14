using SoftUniDIFramework.Library.Injectors;
using SoftUniDIFramework.Library.Modules;

namespace SoftUniDIFramework.Library
{
    public class DInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}

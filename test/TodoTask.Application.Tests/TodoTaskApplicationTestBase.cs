using Volo.Abp.Modularity;

namespace TodoTask;

public abstract class TodoTaskApplicationTestBase<TStartupModule> : TodoTaskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

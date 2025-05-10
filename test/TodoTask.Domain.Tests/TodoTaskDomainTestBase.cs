using Volo.Abp.Modularity;

namespace TodoTask;

/* Inherit from this class for your domain layer tests. */
public abstract class TodoTaskDomainTestBase<TStartupModule> : TodoTaskTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

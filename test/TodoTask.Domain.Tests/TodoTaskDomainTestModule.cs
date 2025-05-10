using Volo.Abp.Modularity;

namespace TodoTask;

[DependsOn(
    typeof(TodoTaskDomainModule),
    typeof(TodoTaskTestBaseModule)
)]
public class TodoTaskDomainTestModule : AbpModule
{

}

using Volo.Abp.Modularity;

namespace TodoTask;

[DependsOn(
    typeof(TodoTaskApplicationModule),
    typeof(TodoTaskDomainTestModule)
)]
public class TodoTaskApplicationTestModule : AbpModule
{

}

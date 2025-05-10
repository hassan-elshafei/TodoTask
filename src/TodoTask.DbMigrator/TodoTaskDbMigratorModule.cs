using TodoTask.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace TodoTask.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(TodoTaskEntityFrameworkCoreModule),
    typeof(TodoTaskApplicationContractsModule)
    )]
public class TodoTaskDbMigratorModule : AbpModule
{
}

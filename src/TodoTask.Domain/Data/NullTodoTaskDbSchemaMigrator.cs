using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TodoTask.Data;

/* This is used if database provider does't define
 * ITodoTaskDbSchemaMigrator implementation.
 */
public class NullTodoTaskDbSchemaMigrator : ITodoTaskDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

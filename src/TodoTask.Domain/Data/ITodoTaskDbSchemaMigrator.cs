using System.Threading.Tasks;

namespace TodoTask.Data;

public interface ITodoTaskDbSchemaMigrator
{
    Task MigrateAsync();
}

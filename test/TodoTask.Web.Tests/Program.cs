using Microsoft.AspNetCore.Builder;
using TodoTask;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<TodoTaskWebTestModule>();

public partial class Program
{
}

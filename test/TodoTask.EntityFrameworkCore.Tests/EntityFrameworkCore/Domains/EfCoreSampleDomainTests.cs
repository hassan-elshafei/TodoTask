using TodoTask.Samples;
using Xunit;

namespace TodoTask.EntityFrameworkCore.Domains;

[Collection(TodoTaskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<TodoTaskEntityFrameworkCoreTestModule>
{

}

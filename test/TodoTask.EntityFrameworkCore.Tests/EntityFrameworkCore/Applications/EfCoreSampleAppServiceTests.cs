using TodoTask.Samples;
using Xunit;

namespace TodoTask.EntityFrameworkCore.Applications;

[Collection(TodoTaskTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<TodoTaskEntityFrameworkCoreTestModule>
{

}

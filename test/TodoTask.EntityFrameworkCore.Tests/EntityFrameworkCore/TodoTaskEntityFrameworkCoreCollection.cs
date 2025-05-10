using Xunit;

namespace TodoTask.EntityFrameworkCore;

[CollectionDefinition(TodoTaskTestConsts.CollectionDefinitionName)]
public class TodoTaskEntityFrameworkCoreCollection : ICollectionFixture<TodoTaskEntityFrameworkCoreFixture>
{

}

using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace TodoTask.Pages;

public class Index_Tests : TodoTaskWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

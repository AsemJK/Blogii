using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace Blogii.Pages;

public class Index_Tests : BlogiiWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}

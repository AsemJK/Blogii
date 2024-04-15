using Blogii.Samples;
using Xunit;

namespace Blogii.EntityFrameworkCore.Applications;

[Collection(BlogiiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<BlogiiEntityFrameworkCoreTestModule>
{

}

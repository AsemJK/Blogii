using Blogii.Samples;
using Xunit;

namespace Blogii.EntityFrameworkCore.Domains;

[Collection(BlogiiTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<BlogiiEntityFrameworkCoreTestModule>
{

}

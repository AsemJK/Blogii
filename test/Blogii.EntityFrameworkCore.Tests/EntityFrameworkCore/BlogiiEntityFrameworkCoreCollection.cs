using Xunit;

namespace Blogii.EntityFrameworkCore;

[CollectionDefinition(BlogiiTestConsts.CollectionDefinitionName)]
public class BlogiiEntityFrameworkCoreCollection : ICollectionFixture<BlogiiEntityFrameworkCoreFixture>
{

}

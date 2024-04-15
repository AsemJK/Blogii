using Microsoft.AspNetCore.Builder;
using Blogii;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<BlogiiWebTestModule>();

public partial class Program
{
}

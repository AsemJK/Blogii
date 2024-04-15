using Volo.Abp.Domain.Entities;

namespace MyCmsPlugin.Models
{
    public class PageModel : BasicAggregateRoot<int>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
    }
}

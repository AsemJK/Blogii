using MyCmsPlugin.Data;
using MyCmsPlugin.Models;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Application.Services;

namespace MyCmsPlugin.Services
{
    public class PageService : ApplicationService, IPageService
    {
        public PageService(MyCmsPluginDbContextExtension dbContextExtension)
        {
            _dbContextExtension = dbContextExtension;
        }

        public MyCmsPluginDbContextExtension _dbContextExtension { get; }

        public List<PageModel> GetPages()
        {
            return _dbContextExtension.Pages.ToList();
        }
        public void CreatePage()
        {
            _dbContextExtension.Pages.Add(new PageModel
            {
                Title = "New Page",
                Content = "This is a new page"
            });
            _dbContextExtension.SaveChanges();
        }
        public void DeletePage()
        {
            _dbContextExtension.Pages.RemoveRange(_dbContextExtension.Pages);
            _dbContextExtension.SaveChanges();
        }
        public void UpdatePage()
        {
            var page = _dbContextExtension.Pages.Find(1);
            page.Title = "Updated Page";
            _dbContextExtension.SaveChanges();
        }

    }
}

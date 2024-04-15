using MyCmsPlugin.Models;
using System.Collections.Generic;
using Volo.Abp.Application.Services;

namespace MyCmsPlugin.Services
{
    public interface IPageService : IApplicationService
    {
        List<PageModel> GetPages();
        void CreatePage();
        void DeletePage();
        void UpdatePage();
    }
}

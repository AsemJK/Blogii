using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyCmsPlugin.Data;
using MyCmsPlugin.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCmsPlugin.Controllers.API
{
    [Route("api/cms/[controller]")]
    [ApiController]
    public class PageController : ControllerBase
    {
        private readonly MyCmsPluginDbContextExtension _dbContextExtension;

        public PageController(MyCmsPluginDbContextExtension dbContextExtension)
        {
            _dbContextExtension = dbContextExtension;
        }

        [HttpGet]
        public Task<List<PageModel>> Get()
        {
            var pages = _dbContextExtension.Pages.ToListAsync();
            return pages;
        }

        [HttpGet("{slug}")]
        public IActionResult Get(string slug)
        {
            var page = _dbContextExtension.Pages.FirstOrDefault(p => p.Slug == slug);
            if (page == null)
            {
                return NotFound();
            }
            return Ok(page);
        }

        [HttpPost]
        public IActionResult Create(PageModel page)
        {
            var existingPage = _dbContextExtension.Pages.FirstOrDefault(p => p.Slug == page.Slug);
            if (existingPage == null)
            {
                _dbContextExtension.Pages.Add(page);
            }
            else
            {
                existingPage.Title = page.Title;
                existingPage.Content = page.Content;

                _dbContextExtension.Pages.Update(existingPage);
            }

            _dbContextExtension.SaveChanges();
            return CreatedAtAction(nameof(Get), new { slug = page.Slug }, page);
        }
        [HttpPost("[action]/{slug}")]
        public IActionResult Delete(string slug)
        {
            var page = _dbContextExtension.Pages.FirstOrDefault(p => p.Slug == slug);
            if (page == null)
            {
                return NotFound();
            }
            _dbContextExtension.Pages.Remove(page);
            _dbContextExtension.SaveChanges();
            return Ok();
        }
    }
}

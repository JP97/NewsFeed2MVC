using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsFeed2MVC.Data;
using Microsoft.EntityFrameworkCore;

namespace NewsFeed2MVC.Models
{
    
    public class NewsViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public NewsViewComponent(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync(DateTime createdDate)
        {
            List<News> newsList = await GetItemsAsync(createdDate);
            return View(newsList);
        }

        private Task<List<News>> GetItemsAsync(DateTime createdDate)
        {
           return _context.News.Where(x => x.CreatedDate >= createdDate).OrderBy(date => date.CreatedDate).ToListAsync();
        }
    }
}

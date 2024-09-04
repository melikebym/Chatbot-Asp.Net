using AIChat.Entity;
using AIChat.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace AIChat.Controllers
{
    public class OptionsController : Controller
    {
        private readonly DataContext _context;

        public OptionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<JsonResult> GetHierarchy()
        {
            var options = await _context.Options
                .Where(o => o.ParentID == null) // Root level options
                .ToListAsync();

            return Json(options);
        }

        [HttpGet]
        public async Task<JsonResult> GetChildren(int id)
        {
            var options = await _context.Options
                .Where(o => o.ParentID == id) // Child level options
                .ToListAsync();
            Console.WriteLine(id);
            return Json(options);
        }
    }
}

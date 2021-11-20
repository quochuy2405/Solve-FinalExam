using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DETHI.Models;
using System.Dynamic;

namespace DETHI.Controllers
{
    public class CanHoController : Controller
    {   private readonly Storectx _context;
        public CanHoController(Storectx context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {  
            
            return View();
        }
        public IActionResult ThemCanHo()
        {
         
            return View();
        }
         
        public IActionResult InsertCanHo(Canho canho)
        {
        
            try
            {
                _context.AddCanHo(canho);
                TempData["status"] = "Thành Công";
            }
            catch(Exception e)
            {
                TempData["status"] = "Thất Bại";
            };
      
            return View("ThemCanHo");
        }
      
    }
}

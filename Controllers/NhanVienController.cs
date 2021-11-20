using DETHI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DETHI.Controllers
{
    public class NhanVienController : Controller
    {
        private readonly Storectx _context;
        public NhanVienController(Storectx context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult LietKeBT()
        {
            return View();
        }
        public IActionResult LietKeDanhSach(int so)
        {
            try
            {
                return View(_context.LietKeBT(so));
            }
            catch (Exception e)
            {
                return View();
            }
          

        }
        public IActionResult LietKeNhanVien()
        {
            try
            {
                return View(_context.LietKeNhanVien());
            }
            catch (Exception e)
            {
                return View();
            }
   

        }
        public IActionResult DanhSachBaoTri(string manv)
        {
            try
            {   
                return View(_context.LietKeDanhSachSua(manv));
            }
            catch (Exception e)
            {
                return View();
            }
     

        }
    
        public ActionResult XoaBT(string matb)
        {
            try
            {
                TempData["status"] = "Đã Xóa";
                _context.XoaBTBT(matb);
                return RedirectToAction("LietKeNhanVien");
            }
            catch (Exception e)
            {
                TempData["status"] = "Không Thể Xóa";
                return View("LietKeNhanVien");
            }
        

        }
        public ActionResult ViewBT(string matb, string mach, int lanthu)
        {

            try
            {
                return View(_context.ViewTTNV(matb, mach, lanthu));
            }
            catch (Exception e)
            {
                return View();
            }

        }
        public ActionResult UpdateBT(Nvbt bt)
        {
            try
            {
                TempData["status"] = "Đã Cập Nhật";
                _context.UpDateBT(bt);
                return RedirectToAction("LietKeNhanVien", ViewBag.status);
            }
            catch (Exception e)
            {
                TempData["status"] = "Lỗi Cập Nhật";
                return View("LietKeNhanVien");
            }

          
        }
    }
}

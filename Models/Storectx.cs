using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DETHI.Models
{
    public class Storectx
    {
        public string ConnectionString { get; set; } // Biến thành viên

        public Storectx(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public void AddCanHo(Canho canho)
        {
           

                chungcuContext _context = new chungcuContext();
            var newCanHo = new Canho()
            {
                MaCanHo = canho.MaCanHo,
                ChuCanHo = canho.ChuCanHo
            };

            _context.Canho.Add(newCanHo);
            _context.SaveChanges();
         
          
        
        }
        public void SuaCanHo(Canho canho)
        {  
            chungcuContext _context = new chungcuContext();
            var newCanHo = new Canho();
            newCanHo.MaCanHo = canho.MaCanHo;
            newCanHo.ChuCanHo = canho.ChuCanHo;
            _context.Canho.Add(newCanHo);
            _context.SaveChanges();

        }
        public List<Object> LietKeBT(int so)
        {
            chungcuContext context = new chungcuContext();
            var query = (from nv in context.Nhanvien
                        join nvbt in context.Nvbt on nv.MaNhanVien equals nvbt.MaNhanVien
                        group nv by
                        new
                        {
                            nv.TenNhanVien,
                            nv.SoDienThoai
                        } into g
                        where g.Count() >so
                        select new 
                        {
                            TenNhanVien = g.Key.TenNhanVien,
                            SoDienThoai = g.Key.SoDienThoai,
                            SoLanSua = g.Count()
                        }).ToList<Object>();


            return query;
        }
        public IQueryable<Nhanvien> LietKeNhanVien()
        {
            chungcuContext context = new chungcuContext();
            var query = from nv in context.Nhanvien
                        select new Nhanvien
                        {
                            TenNhanVien = nv.TenNhanVien,
                            MaNhanVien = nv.MaNhanVien
                        };
            return query;


                 
        }
        public IQueryable<Nvbt> LietKeDanhSachSua(string manv)
        {
            chungcuContext context = new chungcuContext();
            var query = from nvbt in context.Nvbt
                        where nvbt.MaNhanVien == manv
                        select nvbt;
            return query;



        }
        public void XoaBTBT(string MaThietBi)
        {
            chungcuContext db = new chungcuContext();
            var pg = db.Nvbt.First(p => p.MaThietBi == MaThietBi);
            db.Nvbt.Remove(pg);
            db.SaveChanges();
    
        }
        public IQueryable<Nvbt> ViewTTNV(string matb, string mach, int lanthu)
        {
            chungcuContext context = new chungcuContext();
            var query = from nvbt in context.Nvbt
                        where nvbt.MaThietBi == matb && nvbt.MaCanHo == mach && nvbt.LanThu == lanthu
                        select nvbt;
            return query;
        }
        public void UpDateBT(Nvbt bt)
        {
            chungcuContext context = new chungcuContext();
 
            var listtb = context.Nvbt;
            foreach(var item in listtb)
            {
                if(item.MaNhanVien == bt.MaNhanVien && item.MaThietBi == bt.MaThietBi && item.LanThu == bt.LanThu && item.MaCanHo == bt.MaCanHo)
                {

                   ;
                    item.NgayBaoTri = bt.NgayBaoTri;
                  
                    break;
                }
            } 
        
   
            context.SaveChanges();

        }
    }
}

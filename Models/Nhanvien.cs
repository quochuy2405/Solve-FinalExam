using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DETHI.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Nvbt = new HashSet<Nvbt>();
        }

        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string SoDienThoai { get; set; }
        public short? GioiTinh { get; set; }

        public virtual ICollection<Nvbt> Nvbt { get; set; }
    }
}

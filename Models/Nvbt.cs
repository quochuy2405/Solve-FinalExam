using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DETHI.Models
{
    public partial class Nvbt
    {
        public string MaNhanVien { get; set; }
        public string MaThietBi { get; set; }
        public string MaCanHo { get; set; }
        public int LanThu { get; set; }
        public DateTime? NgayBaoTri { get; set; }

        public virtual Canho MaCanHoNavigation { get; set; }
        public virtual Nhanvien MaNhanVienNavigation { get; set; }
        public virtual Thietbi MaThietBiNavigation { get; set; }
    }
}

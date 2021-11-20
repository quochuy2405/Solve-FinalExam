using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DETHI.Models
{
    public partial class Thietbi
    {
        public Thietbi()
        {
            Nvbt = new HashSet<Nvbt>();
        }

        public string MaThietBi { get; set; }
        public string TenThietBi { get; set; }

        public virtual ICollection<Nvbt> Nvbt { get; set; }
    }
}

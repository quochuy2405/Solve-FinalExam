using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace DETHI.Models
{
    public partial class Canho
    {
        public Canho()
        {
            Nvbt = new HashSet<Nvbt>();
        }

        public string MaCanHo { get; set; }
        public string ChuCanHo { get; set; }

        public virtual ICollection<Nvbt> Nvbt { get; set; }
    }
}

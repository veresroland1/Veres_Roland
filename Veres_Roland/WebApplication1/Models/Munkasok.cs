using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Munkasok
    {
        public int MunkasID { get; set; }
        public string MunkasNeve { get; set; }
        public string MunkasSzakkepzettseg { get; set; }
        public int MunkasOraber { get; set; }
    }
}
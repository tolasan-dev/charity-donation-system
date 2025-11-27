using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charity_system
{
    public static  class CurrentUser
    {
        public static int UserID { get; set; }
        public static int RoleID { get; set; }
        public static int? DonorID { get; set; }
    }
}

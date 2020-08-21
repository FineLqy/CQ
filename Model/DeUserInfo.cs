using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
  public  class DeUserInfo
    {
        public DeUserInfo()
        {
            UserName = "";
            UserPwd = "";
            OrderNumber = "";
        }

        public int ID { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
        public string OrderNumber { get; set; }
    }
}

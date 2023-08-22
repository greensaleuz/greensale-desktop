using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenSale.Desktop.Security
{
   public class IdentitySingelton
    {
        private static IdentitySingelton _identitySingelton;
        public long UserId { get; set; } 
        public IdentitySingelton()
        {

        }

        public static IdentitySingelton GetInstance()
        {
            if(_identitySingelton == null )
            {
                _identitySingelton= new IdentitySingelton();
            }

            return _identitySingelton;
        }
    }
}

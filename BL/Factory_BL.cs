using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Factory_BL
    {
        static BL_imp bl=null;
        public static IBL GetBL()
        {
            if(bl==null)
             bl=new BL_imp();

            return bl;
        }
    }
}

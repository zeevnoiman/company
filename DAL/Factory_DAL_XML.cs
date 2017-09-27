using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Factory_DAL_XML
    {
        static DAL_XML_imp dal = null;
        // static DAL_imp dal = null;
        public static IDAL GetDAL()
        {
            if (dal == null)
                dal = new DAL_XML_imp();
            //dal = new DAL_imp();
            return dal;

        }
    }
}

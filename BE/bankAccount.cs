using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public struct BankAccount
    {
        public int bankNumber { get; set; }
        public string bankName { get; set; }
        public int branchNumber { get; set; }
        public string branchAddress { get; set; }
        public string branchCity { get; set; }
        public int accountNumber { get; set; }

        public override string ToString()
        {
            string toReturn = this.bankName + " " + this.branchAddress + " " + this.branchCity;
            return toReturn;
        }
    }
    
}

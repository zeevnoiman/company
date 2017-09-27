using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Contract 
    {

        public int contractNumber { get; set; }
        public int employerId { get; set; }
        public int employeeId { get; set; }
        public bool wasInterviewed { get; set; }
        public bool hasBeenSigned { get; set; }
        public double brutoSalary { get; set; }
        public double netoSalary { get; set; } 
        public DateTime startWork { get; set; }
        public DateTime endWork { get; set; }
        public int workHours { get; set; }
        public double proft { get { return (brutoSalary - netoSalary) * workHours; }  }


        public Contract( int _cNumber, int _employerID, int _employeeID, bool _inteview, bool _signed, double _bruto, double _neto, string sDate,
                       string eDate, int _hours)
        {
            contractNumber = _cNumber;
            employerId = _employerID;
            employeeId = _employeeID;
            wasInterviewed = _inteview;
            hasBeenSigned = _signed;
            brutoSalary = _bruto;
            netoSalary = _neto;           
            startWork = DateTime.Parse(sDate);
            endWork = DateTime.Parse(eDate);
            workHours = _hours;

        }

        public override string ToString()
        {
            string toReturn = "Contract number: " + contractNumber + " Employer id: " + employerId + " Employee id: " + employerId + " Was the employer interviewed? " + wasInterviewed +
               " Has the contract been signed? " + hasBeenSigned + " Bruto salary: " + brutoSalary + " Neto salary: " + netoSalary + " Beginning of employment: " + startWork.ToShortDateString() + " End of employment: " + endWork.ToShortDateString() + " Work hours:" + workHours + "\n";

            return toReturn;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public enum Field { dataStructures, computerCommunications, informationSecurity, serverProgramming, mobileProgramming, userInterfaceDesigning }

    public class Specialization 
    {
        public Specialization( string _specializationName, double _minSalaryPerHour, double _maxSalaryPerHour, Field _specField, int _specializationNumber)
        {
            specializationNumber = _specializationNumber;
            specializationName = _specializationName;
            minSalaryPerHour = _minSalaryPerHour;
            maxSalaryPerHour = _maxSalaryPerHour;
            specField = _specField;
        }

        public int specializationNumber { get; set; }
        public string specializationName { get; set; }
        public double minSalaryPerHour { get; set; }
        public double maxSalaryPerHour { get; set; }
        public Field specField { get; set; }


        public override string ToString()
        {
            string ToReturn = "Specialization number: " + specializationNumber.ToString() +
                              " Specialization field: " + specField.ToString() +
                              " Specialization name: " + specializationName +
                              " Minimmun per hour: " + minSalaryPerHour.ToString() +
                              " Maximmum per hour: " + maxSalaryPerHour.ToString();
            return ToReturn;
        }

      
    }
}

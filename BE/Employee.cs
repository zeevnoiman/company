using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{



    public enum Education { certification, firstDegree, secondDegree, thirdDegree, student }
    public class Employee 
    {


        public DateTime dateOfBirth { get; set; }
        public BankAccount bankAccount { get; set; }
        public int id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public int tel { get; set; }
        public string address { get; set; }
        public Education education { get; set; }
        public bool isAfterArmy { get; set; }
        public int specNumber { get; set; }
        public int age { get { return (int)((DateTime.Now -dateOfBirth).TotalDays / 365.242199); } }
        public bool criminalRecord { get; set; }

        public  Employee(string _name, string _surname, int _ID, int _Tel, string _address,
                      Education _education, bool _afterArmy, bool _criminalRecord, int _specNumber,
                      string bDate, int _bankNumber, string _bankName,
                      int _branchNumber, string _branchAdrees, string _branchCity, int _accountNumber)
        {
            name = _name;
            surname = _surname;
            id = _ID;
            tel = _Tel;
            address = _address;
            education = _education;
            isAfterArmy = _afterArmy;
            specNumber = _specNumber;
            dateOfBirth = DateTime.Parse(bDate);
            criminalRecord = _criminalRecord;
            bankAccount = new BankAccount
            {
                bankNumber = _bankNumber,
                bankName = _bankName,
                branchNumber = _branchNumber,
                branchAddress = _branchAdrees,
                branchCity = _branchCity
            };
        }


        public override string ToString()
        {
            string toReturn;
            string afterArmy = (isAfterArmy) ? "Yes" : "No";

            toReturn = "Name: " + name + " Surname: " + surname + " ID: " + id + "Date of birth: " + dateOfBirth.ToShortDateString() + " Telephone number: " + tel + " Adress: " + address
                + "Served in the military: " + afterArmy + " Has a criminal record: "+criminalRecord+" Education: " + education.ToString() + " Specialization number: " + specNumber;

            return toReturn;
        }

      
    }


}

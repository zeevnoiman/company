using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Employer 
    {
        public DateTime foundationDate { get; set; } //ok
        public int id { get; set; } //ok
        public bool isCompany { get; set; } //ok
        public string name { get; set; } //ok
        public string surname { get; set; } //ok
        public string companyName { get; set; } //ok
        public int tel { get; set; } //ok
        public string address { get; set; } //ok
        public Field field { get; set; } //ok
        public int seniority { get { return (int)((DateTime.Now - foundationDate).TotalDays / 365.242199); } }
        

        public Employer(string _name, string _surname, string _companyName, int _ID, int _Tel, string _address,string fDate, bool _isCompany, Field _field)
        {
            foundationDate = DateTime.Parse(fDate);
            id = _ID;          
            name = _name;
            surname = _surname;
            companyName = _companyName;
            tel = _Tel;
            address = _address;
            field = _field;
            isCompany = _isCompany;
            
        }

        public override string ToString()
        {
            string toReturn;
            string _ID = isCompany ? " ID: " + id : " Company ID: " + id + " Company Name: ";

            toReturn = "Name: " + name + " Surname: " + surname + _ID + companyName + " Tel: " + tel + " Address: " + address +
           " Area of work: " + field + " Years of experience: "+seniority+
            " Foundation Date: " + foundationDate.ToShortDateString();

            return toReturn;
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BL
{
    public interface IBL
    {
        //Specializations functions
        int AddSpecialization(Specialization newSpecialization);
        void DelSpecialization(Specialization oldSpecialization);
        void UpdateSpecialization(Specialization newSpecialization);

        int AddSpecialization(string _specializationName, double _minSalaryPerHour, double _maxSalaryPerHour, Field _specField, int _specializationNumber);
        void UpdateSpecialization(string _specializationName, double _minSalaryPerHour, double _maxSalaryPerHour, Field _specField, int _specializationNumber);
        void DelSpecialization(int specNumber);

        //----------------------------------------------------------------------------------
        //Employees function 
        void AddEmployee(string _name, string _lastName, int _ID, int _Tel, string _address,
                         Education _education, bool _afterArmy, bool _criminalRecord, int _specNumber,
                         string bDate, int _bankNumber, string _bankName,
                         int _branchNumber, string _branchAdrees, string _branchCity, int _accountNumber);

        void UpdateEmployee(string _name, string _surname, int _ID, int _Tel, string _address,
                       Education _education, bool _afterArmy, bool _criminalRecord, int _specNumber,
                       string bDate, int _bankNumber, string _bankName,
                       int _branchNumber, string _branchAdrees, string _branchCity, int _accountNumber);
        void DelEmployee(int oldEmployeeID);
        void AddEmployee(Employee newEmployee);
        void DelEmployee(Employee oldEmployee);
        void UpdateEmployee(Employee newEmployee);

        //----------------------------------------------------------------------------------
        //Employers function 
        void AddEmployer(string _name, string _surname, string _companyName, int _ID, int _Tel, string _address,
            string fDate, bool _isCompany, Field _field);
        void UpdateEmployer(string _name, string _surname, string _companyName, int _ID, int _Tel, string _address,
           string fdate, bool _isCompany, Field _field);
        void AddEmployer(Employer newEmployer);
        void DelEmployer(Employer oldEmployer);
        void UpdateEmployer(Employer newEmployer);

        //----------------------------------------------------------------------------------
        //Contracts function 
        int AddContract(int _cNumber, int _employerID, int _employeeID, bool _inteview, bool _signed, double _bruto,  string sYear,
                       string eDate, int _hours);
        void UpdateContract(int _cNumber, int _employerID, int _employeeID, bool _inteview, bool _signed, double _bruto, string sYear,
                       string eDate, int _hours);
        void DeleteContract(int contractNumber);

        int AddContract(Contract newContract);
        void DelContract(Contract oldContract);
        void UpdateContract(Contract newContract);
        int NumberOfContracts(Func<Contract, bool> condition = null);
        double SumOfProfits();

        //----------------------------------------------------------------------------------
        //Generics functions
        IEnumerable<Specialization> ReturnSpecializations(Func<Specialization, bool> condition = null);
        IEnumerable<Employee> ReturnEmployees(Func<Employee, bool> condition = null);
        IEnumerable<Employer> ReturnEmployers(Func<Employer, bool> condition = null);
        IEnumerable<Contract> ReturnContracts(Func<Contract, bool> condition = null);
        int ReturnSumOfSalariesGreatherThen(Func <Contract,bool> condition);
        int HowManyWereInterviewed();
        //----------------------------------------------------------------------------------
        //Individuals
        Employee GetEmployee(int employeeID);
        Employer GetEmployer(int employerID);
        Contract GetContract(int contractID);
        DateTime GetEarliestStart();
        Specialization GetSpecialization(int specializationID);

        IEnumerable<Employee> ReturnUnemployedEmployees();

        string GetEmployeeName(int employeeID);
        string GetEmployeeLastName(int employeeID);
        //----------------------------------------------------------------------------------
        //Groups
        IEnumerable<IGrouping<int,Contract>> ContractsBySpecialization(bool sort = false);
        IEnumerable<IGrouping<string, Contract>> ContractsByAddress(bool sort = false);
        //IEnumerable<IGrouping<TimeSpan, double>> ProfitByTimespan(); //we couldnt do this

        //----------------------------------------------------------------------------------
        //Bank Account 

        List<BankAccount> ReturnAllBranches(Func<BankAccount,bool> condition=null);
    }
}

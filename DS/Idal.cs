
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace DAL
{

    
    public interface IDAL  //I renamed it.
    {
        //specializations functions
        int AddSpecialization(Specialization newSpecialization);
        void DelSpecialization(Specialization oldSpecialization);
        void UpdateSpecialization(Specialization newSpecialization);
       
        //-----------------------
        //employees function 
        void AddEmployee(Employee newEmployee);
        void DelEmployee(Employee oldEmployee);
        void UpdateEmployee(Employee newEmployee);
        //-----------------
        //employers function 
        void AddEmployer(Employer newEmployer);
        void DelEmployer(Employer oldEmployer);
        void UpdateEmployer(Employer newEmployer);
        //-----------------
        //contracts function 
        int AddContract(Contract newContract);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oldContract"></param>
        void DelContract(Contract oldContract);
        void UpdateContract(Contract newContract);
        //-----------------
        //generics functions
        IEnumerable<Specialization> ReturnSpecializations(Func<Specialization, bool> condition = null);
        IEnumerable<Employee> ReturnEmployees(Func<Employee, bool> condition = null);
        IEnumerable<Employer> ReturnEmployers(Func<Employer, bool> condition = null);
        IEnumerable<Contract> ReturnContracts(Func<Contract, bool> condition = null);
        int ReturnSumOfSalariesGreatherThen( Func<Contract, int> salary, Func<Contract, bool> condition);
        int HowManyWereInterviewed();

        //individuals
        Employee GetEmployee(int employeeID);
        Employer GetEmployer(int employerID);
        Contract GetContract(int contractID);
       Specialization GetSpecialization(int specializationID);

        //------------------------------------
        List<BankAccount> returnAllBranches(Func<BankAccount,bool> condition=null);

           

    }

}

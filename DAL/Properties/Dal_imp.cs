using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DS;

namespace DAL
{

     class DAL_imp : IDAL       
    {
        private static int contractSerial = 1;
        private static int specializationSerial = 1;

        public DAL_imp()
        {
            DataSource DS = new DataSource();
        }
        //specializations functions
        /// <summary>
        /// add new specialization, give a serial number if the user did not do it, and return this serial number
        /// </summary>
        /// <param name="newSpec"></param>
        /// <returns> int </returns>
        public int AddSpecialization(Specialization newSpec)
        {
            if (newSpec.specializationNumber == 0)
            {
                newSpec.specializationNumber = specializationSerial++;
            }
     
            DS.DataSource.allSpecializations.Add(newSpec);

            return newSpec.specializationNumber;

        }
        /// <summary>
        /// delete specialization, verify if the specialization exists, if not, throw exception
        /// </summary>
        /// <param name="oldSpec"></param>
        public void DelSpecialization(Specialization oldSpec)
        {
            Specialization spec = DS.DataSource.allSpecializations.FirstOrDefault(s => s.specializationNumber == oldSpec.specializationNumber);
            if (spec == null)
                throw new Exception("Specialization doesn't exist.");

            DS.DataSource.allSpecializations.Remove(oldSpec);
        }
        /// <summary>
        /// update specialization, verify if it is exists, if not throw exception
        /// </summary>
        /// <param name="newSpec"></param>
        public void UpdateSpecialization(Specialization newSpec)
        {
            Specialization spec = DS.DataSource.allSpecializations.FirstOrDefault(s => s.specializationNumber == newSpec.specializationNumber);
            if (spec == null)
                throw new Exception("No specialization with the given details exists");

            DS.DataSource.allSpecializations.Remove(spec);
            DS.DataSource.allSpecializations.Add(newSpec);
        }
        //-----------------------
        //employees function 
        /// <summary>
        /// add new employe, verify if he already exists, if he does, throw exception
        /// </summary>
        /// <param name="newEmployee"></param>
        public void AddEmployee(Employee newEmployee)
        {
            Employee emp = DS.DataSource.allEmployees.FirstOrDefault(e => e.id == newEmployee.id);
            if (emp != null)
                throw new Exception("Employee already exists.");

            DS.DataSource.allEmployees.Add(newEmployee);
        }
        /// <summary>
        /// delete employee, verify if he exists, if not, throw exception
        /// </summary>
        /// <param name="oldEmployee"></param>
        public void DelEmployee(Employee oldEmployee)
        {
            Employee emp = DS.DataSource.allEmployees.FirstOrDefault(e => e.id == oldEmployee.id);
            if (emp == null)
                throw new Exception("Employee doesn't exist.");

            DS.DataSource.allEmployees.Remove(oldEmployee);
        }
        /// <summary>
        /// update employee, verify if he exists, if not, throw exception
        /// </summary>
        /// <param name="newEmployee"></param>
        public void UpdateEmployee(Employee newEmployee)
        {
            Employee emp = DS.DataSource.allEmployees.FirstOrDefault(e => e.id == newEmployee.id);
            if (emp == null)
                throw new Exception("No employee with the given details exists");

            DS.DataSource.allEmployees.Remove(emp);
            DS.DataSource.allEmployees.Add(newEmployee);
        }
        //-----------------
        //employers function 
        /// <summary>
        /// add employer, verify if he exists, if he does, throw exception
        /// </summary>
        /// <param name="newEmployer"></param>
        public void AddEmployer(Employer newEmployer)
        {
            Employer emp = DS.DataSource.allEmployers.FirstOrDefault(e => e.id == newEmployer.id);
            if (emp != null)
                throw new Exception("Employer already exists.");

            DS.DataSource.allEmployers.Add(newEmployer);
        }
        /// <summary>
        /// delete employer, verify if he exists, if not, throw exception
        /// </summary>
        /// <param name="oldEmployer"></param>
        public void DelEmployer(Employer oldEmployer)
        {
            Employer emp = DS.DataSource.allEmployers.FirstOrDefault(e => e.id == oldEmployer.id);
            if (emp == null)
                throw new Exception("Employer doesn't exist.");

            DS.DataSource.allEmployers.Remove(oldEmployer);
        }
        /// <summary>
        /// update employer, verify if he exists, if not, throw exception
        /// </summary>
        /// <param name="newEmployer"></param>
        public void UpdateEmployer(Employer newEmployer)
        {
            Employer emp = DS.DataSource.allEmployers.FirstOrDefault(e => e.id == newEmployer.id);
            if (emp == null)
                throw new Exception("No employer with the given details exists");

            DS.DataSource.allEmployers.Remove(emp);
            DS.DataSource.allEmployers.Add(newEmployer);
        }
        //-----------------
        //contracts function
        /// <summary>
        /// add new contract, give a serial number if the user did not do it, and return this serial number
        /// </summary>
        /// <param name="newContract"></param>
        /// <returns></returns>
        public int AddContract(Contract newContract)
        {
            if (newContract.contractNumber == 0)
            {
                newContract.contractNumber = contractSerial++;
            }         

            DS.DataSource.allContracts.Add(newContract);

            return newContract.contractNumber;
        }
        /// <summary>
        ///  delete contract, verify if it exists, if not, throw exception
        /// </summary>
        /// <param name="oldContract"></param>
        public void DelContract(Contract oldContract)
        {
            Contract contract = DS.DataSource.allContracts.FirstOrDefault(c => c.contractNumber == oldContract.contractNumber);
            if (contract == null)
                throw new Exception("Contract doesn't exist.");

            DS.DataSource.allContracts.Remove(oldContract);
        }
        /// <summary>
        ///  update contract, verify if he exists, if not, throw exception
        /// </summary>
        /// <param name="newContract"></param>
        public void UpdateContract(Contract newContract)
        {
            Contract contract = DS.DataSource.allContracts.FirstOrDefault(c => c.contractNumber == newContract.contractNumber);
            if (contract == null)
                throw new Exception("No contract with the given details exists");

            DS.DataSource.allContracts.Remove(contract);
            DS.DataSource.allContracts.Add(newContract);
        }
        //-----------------
        /// <summary>
        ///generic functions, return all data source, whith options of predicate.  
        /// </summary>
        public IEnumerable<Specialization> ReturnSpecializations(Func<Specialization, bool> condition = null)
        {
            if (condition == null)
                return DS.DataSource.allSpecializations.AsEnumerable();

            return DS.DataSource.allSpecializations.Where(condition);
        }

        public IEnumerable<Employee> ReturnEmployees(Func<Employee, bool> condition = null)
        {
            if (condition == null)
                return DS.DataSource.allEmployees.AsEnumerable();

            return DS.DataSource.allEmployees.Where(condition);
        }

        public IEnumerable<Employer> ReturnEmployers(Func<Employer, bool> condition = null)
        {
            if (condition == null)
                return DS.DataSource.allEmployers.AsEnumerable();

            return DS.DataSource.allEmployers.Where(condition);
        }

        public IEnumerable<Contract> ReturnContracts(Func<Contract, bool> condition = null)
        {
            if (condition == null)
                return DS.DataSource.allContracts.AsEnumerable();

            return DS.DataSource.allContracts.Where(condition);
        }
        /// <summary>
        /// return sum of the salaries greater then a value choosen by the user
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int ReturnSumOfSalariesGreatherThen(Func<Contract, int> salary, Func<Contract, bool> condition = null)
        {
            if (condition == null)
                return DS.DataSource.allContracts.Select(salary).Sum();

            return DS.DataSource.allContracts.Where(condition).Select(salary).Sum();
        }
        /// <summary>
        /// return the numbers of employees that was interviewed in our company
        /// </summary>
        /// <returns></returns>
        public int HowManyWereInterviewed()
        {
            int num = 0;
            DS.DataSource.allContracts.Where(contract => contract.wasInterviewed).Select(contract => num++);
            return num;
        }
        //------------------------------------
        public List<BankAccount> returnAllBranches(Func<BankAccount,bool> condition=null)
        {
            BE.BankAccount bank1 = new BankAccount();
            BE.BankAccount bank2 = new BankAccount();
            BE.BankAccount bank3 = new BankAccount();
            BE.BankAccount bank4 = new BankAccount();
            BE.BankAccount bank5 = new BankAccount();
        
            bank1.branchCity = "ירושלים";
            bank1.accountNumber = -1;
            bank1.bankName = "לאומי";
            bank1.bankNumber = 10;
            bank1.branchAddress = "צביה ויצחק 800 ";
            bank1.branchNumber = 784;

            bank1.branchCity = "בית שמש";
            bank1.accountNumber = -1;
            bank1.bankName = "לאומי";
            bank1.bankNumber = 10;
            bank1.branchAddress = "יגאל אלון 6 ";
            bank1.branchNumber = 916;

            bank1.branchCity = "טירת כרמל";
            bank1.accountNumber = -1;
            bank1.bankName = "בנק ירושלים";
            bank1.bankNumber = 54;
            bank1.branchAddress = "ז'בוטינסקי 48";
            bank1.branchNumber = 52;

            bank1.branchCity = "מודיעין-מכבים-רעות";
            bank1.accountNumber = -1;
            bank1.bankName = "בנק ירושלים";
            bank1.bankNumber = 54;
            bank1.branchAddress = "שדרות התעשיות 121 ישפרו סנטר";
            bank1.branchNumber = 36;

            bank1.branchCity = "קריית אתא";
            bank1.accountNumber = -1;
            bank1.bankName = "בנק מזרחי טפחות";
            bank1.bankNumber = 20;
            bank1.branchAddress = "זבולון 4";
            bank1.branchNumber = 448;

            List<BankAccount> branchesList = new List<BankAccount>();
            branchesList.Add(bank1);
            branchesList.Add(bank2);
            branchesList.Add(bank3);
            branchesList.Add(bank4);
            branchesList.Add(bank5);

            return branchesList;

        }

        // Individuals
    
        public Employee GetEmployee(int employeeID)
        {
            return DS.DataSource.allEmployees.FirstOrDefault(e => e.id == employeeID);
        }

        public Employer GetEmployer(int employerID)
        {
            return DS.DataSource.allEmployers.FirstOrDefault(e => e.id == employerID);
        }

        public Contract GetContract(int contractID)
        {
            return DS.DataSource.allContracts.FirstOrDefault(c => c.contractNumber == contractID);
        }

        public Specialization GetSpecialization(int specializationID)
        {
            return DS.DataSource.allSpecializations.FirstOrDefault(s => s.specializationNumber == specializationID);
        }
    }

  
}

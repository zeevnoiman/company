using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;


namespace BL
{
    class BL_imp : IBL
    {

        DAL.IDAL dal;
        public BL_imp()
        {
            dal = DAL.Factory_DAL_XML.GetDAL();
        }
        /// <summary>
        /// calculate the neto salary, through a formula that take in count the numbeer of contracts of the employee and employer
        /// </summary>
        /// <param name="_employeeId"></param>
        /// <param name="_employerId"></param>
        /// <param name="_brutoSalary"></param>
        /// <returns></returns>
        public double NetoCalculator(int _employeeId, int _employerId, double _brutoSalary)
        {

            int employeeContracts = this.NumberOfContracts(c => c.employeeId == _employeeId);
            int employerContracts = this.NumberOfContracts(c => c.employerId == _employerId);

            double employeeTax = _brutoSalary * 0.03 * Math.Pow(0.75, employeeContracts); // Normal employee tax is 3%. For each existing contract the tax goes down by 25%.
            double employerTax = _brutoSalary * 0.02 * Math.Pow(0.75, employerContracts); // Normal employer tax is 2%. For each existing contract the tax goes down by 25%.

            return _brutoSalary - (employeeTax + employerTax);


        }
        //----------------------------------------------//
        //auxiliar methods
        //they only receive all the parameters and create an object, after that they call a function to add, del or update
        //employee
        public void AddEmployee(string _name, string _surname, int _ID, int _Tel, string _address,
                        Education _education, bool _afterArmy, bool _criminalRecord, int _specNumber,
                        string bDate, int _bankNumber, string _bankName,
                        int _branchNumber, string _branchAdrees, string _branchCity, int _accountNumber)
        {
            var employee = new Employee(_name, _surname, _ID, _Tel, _address, _education, _afterArmy, _criminalRecord, _specNumber,
                bDate, _bankNumber, _bankName, _branchNumber, _branchAdrees, _branchCity, _accountNumber);

            this.AddEmployee(employee);
        }

        public void UpdateEmployee(string _name, string _surname, int _ID, int _Tel, string _address,
                        Education _education, bool _afterArmy, bool _criminalRecord, int _specNumber,
                        string bDate, int _bankNumber, string _bankName,
                        int _branchNumber, string _branchAdrees, string _branchCity, int _accountNumber)
        {
            var employee = new Employee(_name, _surname, _ID, _Tel, _address, _education, _afterArmy, _criminalRecord, _specNumber,
               bDate, _bankNumber, _bankName, _branchNumber, _branchAdrees, _branchCity, _accountNumber);

            this.UpdateEmployee(employee);

        }
        public void DelEmployee(int id)
        {
            DelEmployee(dal.GetEmployee(id));
        }

        //employer
        public void AddEmployer(string _name, string _surname, string _companyName, int _ID, int _Tel, string _address,
             string fdate, bool _isCompany, Field _field)
        {
            var employer = new Employer(_name, _surname, _companyName, _ID, _Tel, _address,
             fdate, _isCompany, _field);

            this.AddEmployer(employer);
        }
        public void UpdateEmployer(string _name, string _surname, string _companyName, int _ID, int _Tel, string _address,
             string fdate, bool _isCompany, Field _field)
        {
            var employer = new Employer(_name, _surname, _companyName, _ID, _Tel, _address,
            fdate, _isCompany, _field);

            this.UpdateEmployer(employer);
        }
        public void DelEmployer(int id)
        {
            DelEmployer(dal.GetEmployer(id));
        }

        //specialization
        public int AddSpecialization(string _specializationName, double _minSalaryPerHour, double _maxSalaryPerHour, Field _specField, int _specializationNumber)
        {
            Specialization spec = new Specialization(_specializationName, _minSalaryPerHour,
                _maxSalaryPerHour, _specField, _specializationNumber);
            return AddSpecialization(spec);
        }
        public void UpdateSpecialization(string _specializationName, double _minSalaryPerHour, double _maxSalaryPerHour, Field _specField, int _specializationNumber)
        {
            Specialization spec = new Specialization(_specializationName, _minSalaryPerHour,
                _maxSalaryPerHour, _specField, _specializationNumber);
            UpdateSpecialization(spec);
        }

        public void DelSpecialization(int specId)
        {
            DelSpecialization(dal.GetSpecialization(specId));
        }

        //contracts
        public int AddContract(int _cNumber, int _employerID, int _employeeID, bool _inteview, bool _signed, double _bruto, string sDate, string eDate, int _hours)
        {
            double _neto = this.NetoCalculator(_employeeID, _employerID, _bruto); //calculate the Neto wage.
            if (dal.GetEmployee(_employeeID).isAfterArmy)
                _neto = 1.05 * _neto;
            var contract = new Contract(_cNumber, _employerID, _employeeID, _inteview, _signed, _bruto, _neto, sDate, eDate, _hours);

            return AddContract(contract);
        }
        public void UpdateContract(int _cNumber, int _employerID, int _employeeID, bool _inteview, bool _signed, double _bruto, string sDate, string eDate, int _hours)

        {
            double _neto = this.NetoCalculator(_employeeID, _employerID, _bruto); //calculate the Neto wage.

            var contract = new Contract(_cNumber, _employerID, _employeeID, _inteview, _signed, _bruto, _neto, sDate, eDate, _hours);

            UpdateContract(contract);
        }
        public void DeleteContract(int contractNumber)
        {
            var contract = dal.GetContract(contractNumber);

            DelContract(contract);
        }

        //end of the auxiliar methods
        //---------------------------------------------//

        // Employee methods
        /// <summary>
        /// verifications that throw exceptions:
        /// 1)if the employee is under age 18
        /// 2)if the employee has criminal record
        /// 3)if the employee is a student
        /// 4)if the specialization does not exist
        /// 
        /// </summary>
        /// <param name="newEmployee"></param>
        public void AddEmployee(Employee newEmployee)
        {
            if (newEmployee.id < 0)
                throw new Exception("Employee ID cannot be a negative number.");

            if (newEmployee.age < 18)
                throw new Exception("Employee is underage.");

            if (newEmployee.criminalRecord)
                throw new Exception("Employee has a criminal record.");

            if (newEmployee.education == Education.student)
                throw new Exception("We can not add students");

            if (!ReturnSpecializations(s => newEmployee.specNumber == s.specializationNumber).Any())
                throw new Exception("A specialization with this number doesn't exist.");

            if (!dal.returnAllBranches(bAcc => bAcc.bankNumber == newEmployee.bankAccount.bankNumber).Any())
                throw new Exception("Bank doesn`t exist");

            if (!dal.returnAllBranches(bAcc => bAcc.branchNumber == newEmployee.bankAccount.branchNumber).Any())
                throw new Exception("Banks branch doesn`t exist");

            dal.AddEmployee(newEmployee);

        }
        /// <summary>
        /// update employee, he is already in our company, so there is no reason the verify if he can be accepted 
        /// </summary>
        /// <param name="newEmployee"></param>
        public void UpdateEmployee(Employee newEmployee)
        {
            dal.UpdateEmployee(newEmployee);
        }
        /// <summary>
        /// verificate if the employee has actived contracts, if it is true, it we can not delete him
        /// </summary>
        /// <param name="oldEmployee"></param>
        public void DelEmployee(Employee oldEmployee)
        {
            IEnumerable<Contract> verification = from contract in dal.ReturnContracts()
                                                 where contract.employeeId == oldEmployee.id && contract.hasBeenSigned
                                                 select contract;

            if (verification.Any(contract => contract.endWork < DateTime.Now))
                throw new Exception("We can not delete employee because he has actived contracts");

            dal.DelEmployee(oldEmployee);
        }

        // Employer methods
        /// <summary>
        /// verify if the fundation of the employer was in more than a half of year
        /// </summary>
        /// <param name="newEmployer"></param>
        public void AddEmployer(Employer newEmployer)
        {
            if (newEmployer.id < 0)
                throw new Exception("Employer ID cannot be a negative number.");

            dal.AddEmployer(newEmployer);
        }

        /// <summary>
        /// verify if the employer has active contracts, if it is true, we can not delete him
        /// </summary>
        /// <param name="oldEmployer"></param>
        public void DelEmployer(Employer oldEmployer)
        {
            IEnumerable<Contract> verification = from contract in dal.ReturnContracts()
                                                 where contract.employerId == oldEmployer.id && contract.hasBeenSigned
                                                 select contract;

            if (verification.Any(contract => contract.endWork < DateTime.Now))
                throw new Exception("we can not delete employer because he has active contracts");

            dal.DelEmployer(oldEmployer);
        }
        /// <summary>
        /// we dont neen to verify this employer, because he was already in our company
        /// </summary>
        /// <param name="newEmployer"></param>
        public void UpdateEmployer(Employer newEmployer)
        {
            dal.UpdateEmployer(newEmployer);
        }

        //specialization methods
        /// <summary>
        /// dont need to verify the specializations
        /// </summary>
        public void DelSpecialization(Specialization oldSpecialization)
        {
            dal.DelSpecialization(oldSpecialization);
        }

        public int AddSpecialization(Specialization newSpecialization)
        {
            if (newSpecialization.maxSalaryPerHour < newSpecialization.minSalaryPerHour)
                throw new Exception("Minimum wage cannot be lower than the maximum wage.");
            return dal.AddSpecialization(newSpecialization);
        }


        public void UpdateSpecialization(Specialization newSpecialization)
        {
            dal.UpdateSpecialization(newSpecialization);
        }


        // Contract methods 
        /// <summary>
        /// add a new contract, under the conditions:
        /// 1)verify if the employer exists
        /// 2)verify if the employee exists
        /// 3)verify if the employee work in the same field of the employer
        /// 4)verify if the employer already works to anothe company
        /// 5)verify if the company already has one year of existence
        /// 6)verify id the minimmun salary is compatible with the employee
        /// 7)verify id the maximmun salary is compatible with the employee
        /// </summary>
        /// <param name="newContract"></param>
        public int AddContract(Contract newContract)
        {
            var employee = this.GetEmployee(newContract.employeeId);
            var employer = this.GetEmployer(newContract.employerId);

            if (newContract.employeeId < 0)
                throw new Exception("Employee ID cannot be a negative number.");

            if (newContract.employerId < 0)
                throw new Exception("Employer ID cannot be a negative number.");

            if (employee == null)
                throw new Exception("Employee in the contract doesn't exist.");

            if (employer == null)
                throw new Exception("Employer in the contract doesn't exist.");

            if (employer.field != this.GetSpecialization(employee.specNumber).specField)
                throw new Exception("This Employee cannot work in this employer's field.");

            if (newContract.endWork < newContract.startWork)
                throw new Exception("Date of start of employment cannot be later than date of end of employment.");

            if (dal.ReturnContracts(c => c.employeeId == employee.id).Any(c=>DateTime.Now<c.endWork)) //if the employee has other contracts that don`t ended yet, he can`t assign this contract
                throw new Exception("Employee is already employed by another company.");

            if (dal.ReturnEmployers(e => e.id == employer.id && e.seniority >= 1) == null)
                throw new Exception("Employer doesn't have a seniority of at least one year.");

            if (newContract.workHours <= 0)
                throw new Exception("Daily hours cannot be equal to or less than zero");

            if (newContract.workHours > 12)
                throw new Exception("Cannot work more than 12 hours a day.");

            if (newContract.brutoSalary <= 0)
                throw new Exception("Bruto wage cannot be less or equal to zero.");

            if (newContract.workHours <= 0)
                throw new Exception("Number of daily hours cannot be less or equal to zero");

            var specialization = this.GetSpecialization(employee.specNumber);

            if (newContract.netoSalary < specialization.minSalaryPerHour)
                throw new Exception("Neto salary per hour is too low for this employee's specialization.");

            if (newContract.netoSalary > specialization.maxSalaryPerHour)
                throw new Exception("Neto salary per hour is too high for this employee's specialization.");





            return dal.AddContract(newContract);


        }
        /// <summary>
        /// delete contracs, verify if:
        /// 1)the employer is descartable, if he is very valuable, we prefer save the contract
        /// 2)if the contract is still in force
        /// </summary>
        /// <param name="oldContract"></param>
        public void DelContract(Contract oldContract)
        {
            if (oldContract.hasBeenSigned && oldContract.endWork < DateTime.Now)
                throw new Exception("Cannot delete a signed and active contract.");
            dal.DelContract(oldContract);
        }
        /// <summary>
        /// dont need to verify contract that is already in our company
        /// </summary>
        /// <param name="newContract"></param>
        public void UpdateContract(Contract newContract)
        {
            var employee = this.GetEmployee(newContract.employeeId);
            var employer = this.GetEmployer(newContract.employerId);
            var specialization = this.GetSpecialization(employee.specNumber);

            if (GetContract(newContract.contractNumber).hasBeenSigned)
                throw new Exception("Cannot update a signed contract.");

            else if (GetContract(newContract.contractNumber).endWork < DateTime.Now)
                throw new Exception("Cannot update an expired contract.");



            else if (newContract.employeeId < 0)
                throw new Exception("Employee ID cannot be a negative number.");

            else if (newContract.employerId < 0)
                throw new Exception("Employer ID cannot be a negative number.");

            else if (employee == null)
                throw new Exception("Employee in the contract doesn't exist.");

            else if (employer == null)
                throw new Exception("Employer in the contract doesn't exist.");

            else if (employer.field != this.GetSpecialization(employee.specNumber).specField)
                throw new Exception("This Employee cannot work in this employer's field.");

            else if (newContract.endWork < newContract.startWork)
                throw new Exception("Date of start of employment cannot be later than date of end of employment.");

            else if (dal.ReturnContracts(c => c.employeeId == employee.id).Any(c => DateTime.Now < c.endWork)) //if the employee has other contracts that don`t ended yet, he can`t assign this contract
                throw new Exception("Employee is already employed by another company.");

            else if (dal.ReturnEmployers(e => e.id == employer.id && e.seniority >= 1) == null)
                throw new Exception("Employer doesn't have a seniority of at least one year.");

            else if (newContract.workHours <= 0)
                throw new Exception("Daily hours cannot be equal to or less than zero");

            else if (newContract.workHours > 12)
                throw new Exception("Cannot work more than 12 hours a day.");

            else if (newContract.brutoSalary <= 0)
                throw new Exception("Bruto wage cannot be less or equal to zero.");

            else if (newContract.workHours <= 0)
                throw new Exception("Number of daily hours cannot be less or equal to zero");



            else if (newContract.netoSalary < specialization.minSalaryPerHour)
                throw new Exception("Neto salary per hour is too low for this employee's specialization.");

            else if (newContract.netoSalary > specialization.maxSalaryPerHour)
                throw new Exception("Neto salary per hour is too high for this employee's specialization.");

            else
            {
                var oldContract = GetContract(newContract.contractNumber);
                DelContract(oldContract);
                dal.AddContract(newContract);
            }   
        }
        /// <summary>
        /// return the number of contracts of our company
        /// return the number of contracts under a condition
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int NumberOfContracts(Func<Contract, bool> condition = null)
        {
            if (condition == null)
                return dal.ReturnContracts().Count();

            return dal.ReturnContracts(condition).Count();
        }
        /// <summary>
        /// return all the profits all our company
        /// </summary>
        /// <returns></returns>
        public double SumOfProfits()
        {
            return dal.ReturnContracts().Select(c => (c.brutoSalary - c.netoSalary)).Sum();
        }

        // Generics

        public IEnumerable<Contract> ReturnContracts(Func<Contract, bool> condition = null)
        {
            return dal.ReturnContracts(condition);
        }

        public IEnumerable<Employee> ReturnEmployees(Func<Employee, bool> condition = null)
        {
            return dal.ReturnEmployees(condition);
        }

        public IEnumerable<Employer> ReturnEmployers(Func<Employer, bool> condition = null)
        {
            return dal.ReturnEmployers(condition); ;
        }

        public IEnumerable<Specialization> ReturnSpecializations(Func<Specialization, bool> condition = null)
        {
            return dal.ReturnSpecializations(condition); ;
        }
        /// <summary>
        ///return sum of salaries if the salaries keep the condition,
        ///ex.: sum of all salaries greater then 10000
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public int ReturnSumOfSalariesGreatherThen(Func<Contract, bool> condition)
        {
            return dal.ReturnSumOfSalariesGreatherThen(contract => (int)contract.brutoSalary, condition);
        }
        /// <summary>
        /// return how many employees was interviewed 
        /// </summary>
        /// <returns></returns>
        public int HowManyWereInterviewed()
        {
            return dal.HowManyWereInterviewed();
        }/// <summary>
         /// return all branches of the banks
         /// return all the branches of the banks under a condition
         /// </summary>
         /// <param name="condition"></param>
         /// <returns></returns>
        public List<BankAccount> ReturnAllBranches(Func<BankAccount, bool> condition = null)
        {
            return dal.returnAllBranches(condition);
        }


        //Groups


        public IEnumerable<IGrouping<int, Contract>> ContractsBySpecialization(bool sort = false)
        {
            if (sort)
            {
                return from c in dal.ReturnContracts()
                       orderby c.employerId
                       group c by this.GetEmployee(c.employeeId).specNumber;
            }

            else
            {
                return from c in dal.ReturnContracts()
                       group c by this.GetEmployee(c.employeeId).specNumber;
            }
        }

        public IEnumerable<IGrouping<string, Contract>> ContractsByAddress(bool sort = false)
        {
            if (sort)
            {
                return from c in dal.ReturnContracts()
                       orderby c.employerId
                       group c by this.GetEmployee(c.employeeId).address;
            }

            else
            {
                return from c in dal.ReturnContracts()
                       group c by this.GetEmployee(c.employeeId).address;
            }
        }



        public IEnumerable<IGrouping<TimeSpan, double>> ProfitByTimespan()
        {
            var contracts = ReturnContracts();
            var earliest = this.GetEarliestStart();
            var latest = this.GetLastestEnd();

            //DateTime begginingOfMonth = earliest;// the grouping of profits will be by month //shtuiot
            //DateTime endOfTheMonth = begginingOfMonth.AddDays(30);

            TimeSpan time = new TimeSpan(30, 0, 0, 0); //30 days of timeSpan

            var result = from c in contracts
                         let profit = ((c.brutoSalary - c.netoSalary) * c.workHours) * 30 //profit of a month
                         where c.startWork >= earliest && c.endWork <= latest
                         group profit by time; //grouping profits by 30 days

            return result;

            //List<IEnumerable<IGrouping<TimeSpan, double>>> toReturn = new List<IEnumerable<IGrouping<TimeSpan, double>>>();

            //toReturn.Add(result);

            //while (endOfTheMonth <= latest)
            //    {
            //        begginingOfMonth = endOfTheMonth;
            //        endOfTheMonth = begginingOfMonth.AddDays(30);
            //        time = endOfTheMonth.Subtract(begginingOfMonth);

            //        toReturn.Add(result);
            //}

            //return toReturn;
        }



        //Individuals


        public Employee GetEmployee(int employeeID)
        {
            return dal.GetEmployee(employeeID);
        }

        public Employer GetEmployer(int employerID)
        {
            return dal.GetEmployer(employerID);

        }

        public Contract GetContract(int contractID)
        {
            return dal.GetContract(contractID);
        }

        public Specialization GetSpecialization(int specializationID)
        {
            return dal.GetSpecialization(specializationID);
        }
        /// <summary>
        /// return the duration of a contract in days
        /// </summary>
        /// <param name="_contract"></param>
        /// <returns></returns>
        public int contractDuration(Contract _contract)
        {
            int days = _contract.endWork.Subtract(_contract.startWork).Days;
            return days;
        }
        /// <summary>
        /// return the date of the earliest start of a contract
        /// </summary>
        /// <returns></returns>
        public DateTime GetEarliestStart()
        {
            var contracts = ReturnContracts();
            var earliest = contracts.First().startWork;
            foreach (var c in contracts)
            {
                if (c.startWork < earliest)
                    earliest = c.startWork;
            }

            return earliest;
        }
        /// <summary>
        /// return the date of the last end of contract
        /// </summary>
        /// <returns></returns>
        public DateTime GetLastestEnd()
        {
            var contracts = ReturnContracts();
            var latest = contracts.First().endWork;
            foreach (var c in contracts)
            {
                if (c.endWork > latest)
                    latest = c.startWork;
            }

            return latest;
        }

        public string GetEmployeeName(int employeeID)
        {
            return ReturnEmployees(e => e.id == employeeID).FirstOrDefault().name;
        }

        public string GetEmployeeLastName(int employeeID)
        {
            return ReturnEmployees(e => e.id == employeeID).FirstOrDefault().surname;
        }

        public IEnumerable<Employee> ReturnUnemployedEmployees()

        {
            var employees = ReturnEmployees().ToList();           
            var contracts = ReturnContracts().Where(c=>DateTime.Now<c.endWork);

            foreach(var e in employees)
            {
                foreach(var c in contracts)
                {
                    if (c.employeeId == e.id)                                     
                            employees.Remove(e);                                          
                }
            }
         
            return employees.AsEnumerable();
        }

    }
}

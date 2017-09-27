using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using BE;

namespace DAL
{
    class DAL_XML_imp : IDAL
    {
        XElement specializationsRoot;
        XElement contractsRoot;
        XElement employeesRoot;
        XElement employersRoot;
        XElement banksRoot;

        string specializationsPath = "specializations.xml";
        string contractsPath = "contracts.xml";
        string employeesPath = "employees.xml";
        string employersPath = "employers.xml";
        string banksPath = "atm.xml";

        public DAL_XML_imp()
        {
            if (!File.Exists(specializationsPath))
                CreateSpec();

            if (!File.Exists(contractsPath))
                CreateContracts();

            if (!File.Exists(employeesPath))
                CreateEmployees();

            if (!File.Exists(employersPath))
                CreateEmployers();

            if (!File.Exists(banksPath))
                CreateBanks();

            LoadData();

        }


        private void LoadData()
        {
            try
            {
                specializationsRoot = XElement.Load(specializationsPath);
                contractsRoot = XElement.Load(contractsPath);
                employeesRoot = XElement.Load(employeesPath);
                employersRoot = XElement.Load(employersPath);
                banksRoot = XElement.Load(banksPath);
            }

            catch
            {
                throw new Exception("Error loading files.");
            }
        }

        private void CreateSpec()
        {
            specializationsRoot = new XElement("Specializations", new XAttribute("Serial_number", "1"));
            specializationsRoot.Save(specializationsPath);
        }

        private void CreateEmployees()
        {
            employeesRoot = new XElement("Employees");
            employeesRoot.Save(employeesPath);
        }
        private void CreateEmployers()
        {
            employersRoot = new XElement("Employers");
            employersRoot.Save(employersPath);
        }
        private void CreateContracts()
        {
            contractsRoot = new XElement("Contracts", new XAttribute("Serial_number", "1"));
            contractsRoot.Save(contractsPath);
        }

        private void CreateBanks()
        {
            try
            {
                banksRoot = XElement.Load("http://www.boi.org.il/he/BankingSupervision/BanksAndBranchLocations/Lists/BoiBankBranchesDocs/atm.xml");
                banksRoot.Save(banksPath);
            }
            catch
            {
                banksRoot = XElement.Load("http://www.jct.ac.il/~coshri/atm.xml");
                banksRoot.Save(banksPath);
            }
        }


        //Specialization methods


        public int AddSpecialization(Specialization newSpecialization)
        {

            if (newSpecialization.specializationNumber == 0)
            {
              
                int specNumber=Int32.Parse(specializationsRoot.Attribute("Serial_number").Value);
                newSpecialization.specializationNumber = specNumber;

                specializationsRoot.Add(new XElement("Specialization",
                      new XAttribute("Specialization_number",newSpecialization.specializationNumber.ToString()),
                      new XElement("Specialization_name", newSpecialization.specializationName),
                      new XElement("Minimum_wage", newSpecialization.minSalaryPerHour.ToString()),
                      new XElement("Maximum_wage", newSpecialization.maxSalaryPerHour.ToString()),
                      new XElement("Field", newSpecialization.specField.ToString())
                            )
                        );
                specNumber++;
                specializationsRoot.Attribute("Serial_number").Value = specNumber.ToString();

                
            }
            else
            {
                specializationsRoot.Add(new XElement("Specialization",
                   new XAttribute("Specialization_number", newSpecialization.specializationNumber.ToString()),
                   new XElement("Specialization_name", newSpecialization.specializationName),
                   new XElement("Minimum_wage", newSpecialization.minSalaryPerHour.ToString()),
                   new XElement("Maximum_wage", newSpecialization.maxSalaryPerHour.ToString()),
                   new XElement("Field", newSpecialization.specField.ToString())
                         )
                     );

            }

            specializationsRoot.Save(specializationsPath);
  
            return newSpecialization.specializationNumber;
        }

        public void DelSpecialization(Specialization oldSpecialization)
        {

            if (GetSpecialization(oldSpecialization.specializationNumber) == null)
                throw new Exception("No specialization with the given details exists");

            try
            {
                var element = (from s in specializationsRoot.Elements()
                               where Convert.ToInt32(s.Attribute("Specialization_number").Value) == oldSpecialization.specializationNumber
                               select s).FirstOrDefault();

                element.Remove();
                specializationsRoot.Save(specializationsPath);

            }
            catch
            {
                throw new Exception("Error deleting from file: " + specializationsRoot);
            }



        }

        public void UpdateSpecialization(Specialization newSpecialization)
        {
            var temp = GetSpecialization(newSpecialization.specializationNumber);
            if (temp == null)
                throw new Exception("No specialization with the given details exists");

            DelSpecialization(temp);
            AddSpecialization(newSpecialization);
            specializationsRoot.Save(specializationsPath);
        }


        public IEnumerable<Specialization> ReturnSpecializations(Func<Specialization, bool> condition = null)
        {

            var result = from s in specializationsRoot.Elements()
                         select new Specialization(
                             s.Element("Specialization_name").Value,
                             Convert.ToDouble(s.Element("Minimum_wage").Value),
                             Convert.ToDouble(s.Element("Maximum_wage").Value),
                             (Field)Enum.Parse(typeof(Field), s.Element("Field").Value),
                             Convert.ToInt32(s.Attribute("Specialization_number").Value)
                             );
            if (condition == null)
            {
                return result;
            }

            else
            {
                return result.Where(condition);
            }



        }


        // Employee methods

        public void AddEmployee(Employee newEmployee)
        {
            if (GetEmployee(newEmployee.id) != null)
                throw new Exception("Employee already exists.");

            employeesRoot.Add(new XElement("Employee",
                  new XAttribute("ID", newEmployee.id.ToString()),
                  new XElement("Name", newEmployee.name),
                  new XElement("Last_name", newEmployee.surname),
                  new XElement("Date_of_birth", newEmployee.dateOfBirth.ToShortDateString()),
                  new XElement("Age", newEmployee.age.ToString()),
                  new XElement("Telephone_number", newEmployee.tel.ToString()),
                  new XElement("Address", newEmployee.address),
                  new XElement("Education", newEmployee.education.ToString()),
                  new XElement("Specialization_number", newEmployee.specNumber.ToString()),
                  new XElement("Served_in_the_military", newEmployee.isAfterArmy ? "Yes" : "No"),
                  new XElement("Has_a_criminal_record", newEmployee.criminalRecord ? "Yes" : "No"),
                  new XElement("Bank_account",
                        new XElement("מספר_חשבון", newEmployee.bankAccount.accountNumber.ToString()),
                        new XElement("קוד_בנק", newEmployee.bankAccount.bankNumber.ToString()),
                        new XElement("שם_בנק", newEmployee.bankAccount.bankName),
                        new XElement("קוד_סניף", newEmployee.bankAccount.branchNumber.ToString()),
                        new XElement("כתובת_ה-ATM", newEmployee.bankAccount.branchAddress),
                        new XElement("ישוב", newEmployee.bankAccount.branchCity))
                         )
                         );
            employeesRoot.Save(employeesPath);
        }

        public void DelEmployee(Employee oldEmployee)
        {
            if (GetEmployee(oldEmployee.id) == null)
                throw new Exception("Employee doesn't exist.");

            try
            {
                var element = (from e in employeesRoot.Elements()
                               where Convert.ToInt32(e.Attribute("ID").Value) == oldEmployee.id
                               select e).FirstOrDefault();
                element.Remove();
                employeesRoot.Save(employeesPath);
            }
            catch
            {
                throw new Exception("Error deleting from file: " + employeesPath);
            }
        }

        public void UpdateEmployee(Employee newEmployee)
        {
            var temp = GetEmployee(newEmployee.id);
            if (temp == null)
                throw new Exception("No employee with the given details exists");

            DelEmployee(temp);
            AddEmployee(newEmployee);
            employeesRoot.Save(employeesPath);
        }

        public IEnumerable<Employee> ReturnEmployees(Func<Employee, bool> condition = null)
        {

            var result = from e in employeesRoot.Elements()
                         select new Employee(
                             e.Element("Name").Value,
                             e.Element("Last_name").Value,
                             Convert.ToInt32(e.Attribute("ID").Value),
                             Convert.ToInt32(e.Element("Telephone_number").Value),
                             e.Element("Address").Value,
                             (Education)Enum.Parse(typeof(Education), e.Element("Education").Value),
                             (e.Element("Served_in_the_military").Value).Equals("Yes"),
                             (e.Element("Has_a_criminal_record").Value).Equals("Yes"),
                             Convert.ToInt32(e.Element("Specialization_number").Value),
                             e.Element("Date_of_birth").Value,
                             Convert.ToInt32(e.Element("Bank_account").Element("קוד_בנק").Value),
                             e.Element("Bank_account").Element("שם_בנק").Value,
                             Convert.ToInt32(e.Element("Bank_account").Element("קוד_סניף").Value),
                             e.Element("Bank_account").Element("כתובת_ה-ATM").Value,
                             e.Element("Bank_account").Element("ישוב").Value,
                             Convert.ToInt32(e.Element("Bank_account").Element("מספר_חשבון").Value)
                             );



            if (condition == null)
            {
                return result;
            }

            else
            {
                return result.Where(condition);
            }

        }


        // Employer methods

        public void AddEmployer(Employer newEmployer)
        {
            if (GetEmployer(newEmployer.id) != null)
                throw new Exception("Employer already exists.");

            employersRoot.Add(new XElement("Employer",
                  new XAttribute("ID", newEmployer.id.ToString()),
                  new XElement("Name", newEmployer.name),
                  new XElement("Last_name", newEmployer.surname),
                  new XElement("Company_name", newEmployer.companyName),
                  new XElement("Foundation_date", newEmployer.foundationDate.ToShortDateString()),
                  new XElement("Telephone_number", newEmployer.tel.ToString()),
                  new XElement("Address", newEmployer.address),
                  new XElement("Field", newEmployer.field.ToString()),
                  new XElement("Is_a_company", newEmployer.isCompany ? "Yes" : "No"),
                  new XElement("Veterancy", newEmployer.seniority.ToString())
                         )
                         );
            employersRoot.Save(employersPath);
        }

        public void DelEmployer(Employer oldEmployer)
        {
            if (GetEmployer(oldEmployer.id) == null)
                throw new Exception("Employer doesn't exist.");

            try
            {
                var element = (from e in employersRoot.Elements()
                               where Convert.ToInt32(e.Attribute("ID").Value) == oldEmployer.id
                               select e).FirstOrDefault();

                element.Remove();
                employersRoot.Save(employersPath);
            }
            catch
            {
                throw new Exception("Error deleting from file: " + employeesPath);
            }
        }

        public void UpdateEmployer(Employer newEmployer)
        {
            var temp = GetEmployer(newEmployer.id);

            if (temp == null)
                throw new Exception("No employer with the given detail exists");

            DelEmployer(temp);
            AddEmployer(newEmployer);
            employersRoot.Save(employersPath);
        }


        public IEnumerable<Employer> ReturnEmployers(Func<Employer, bool> condition = null)
        {
            var result = from e in employersRoot.Elements()
                         select new Employer(
                        e.Element("Name").Value,
                        e.Element("Last_name").Value,
                        e.Element("Company_name").Value,
                        Convert.ToInt32(e.Attribute("ID").Value),
                        Convert.ToInt32(e.Element("Telephone_number").Value),
                        e.Element("Address").Value,
                        e.Element("Foundation_date").Value,
                        (e.Element("Is_a_company")).Equals("Yes"),
                        (Field)Enum.Parse(typeof(Field), e.Element("Field").Value)
                        );


            if (condition == null)
            {
                return result;
            }

            else
            {
                return result.Where(condition);
            }
        }


        // Contract methods 

        public int AddContract(Contract newContract)
        {
            if (newContract.contractNumber == 0)
            {
                int conNumber=Int32.Parse(contractsRoot.Attribute("Serial_number").Value);
                newContract.contractNumber = conNumber;

                contractsRoot.Add(new XElement("Contract",

                             new XAttribute("Contract_number", newContract.contractNumber.ToString()),
                             new XElement("Employer_ID", newContract.employerId.ToString()),
                             new XElement("Employee_ID", newContract.employeeId.ToString()),
                             new XElement("Was_interviewed", newContract.wasInterviewed ? "Yes" : "No"),
                             new XElement("Signed", newContract.hasBeenSigned ? "Yes" : "No"),
                             new XElement("Bruto_salary", newContract.brutoSalary.ToString()),
                             new XElement("Neto_salary", newContract.netoSalary.ToString()),
                             new XElement("Start_work", newContract.startWork.ToShortDateString()),
                             new XElement("End_work", newContract.endWork.ToShortDateString()),
                             new XElement("Work_hours", newContract.workHours.ToString()))
                             );




                conNumber++;
                contractsRoot.Attribute("Serial_number").Value = conNumber.ToString();
                contractsRoot.Save(contractsPath);
            }

            else
            {
                contractsRoot.Add(new XElement("Contract",

                          new XAttribute("Contract_number", newContract.contractNumber.ToString()),
                          new XElement("Employer_ID", newContract.employerId.ToString()),
                          new XElement("Employee_ID", newContract.employeeId.ToString()),
                          new XElement("Was_interviewed", newContract.wasInterviewed ? "Yes" : "No"),
                          new XElement("Signed", newContract.hasBeenSigned ? "Yes" : "No"),
                          new XElement("Bruto_salary", newContract.brutoSalary.ToString()),
                          new XElement("Neto_salary", newContract.netoSalary.ToString()),
                          new XElement("Start_work", newContract.startWork.ToShortDateString()),
                          new XElement("End_work", newContract.endWork.ToShortDateString()),
                          new XElement("Work_hours", newContract.workHours.ToString()))
                          );

            }
            return newContract.contractNumber;
        }

        public void DelContract(Contract oldContract)
        {
            if (GetContract(oldContract.contractNumber) == null)
                throw new Exception("Contract doesn't exist.");

            try
            {
                var element = (from c in contractsRoot.Elements()
                               where Convert.ToInt32(c.Attribute("Contract_number").Value) == oldContract.contractNumber
                               select c).FirstOrDefault();
                element.Remove();
                contractsRoot.Save(contractsPath);
            }
            catch
            {
                throw new Exception("Error deleting from file: " + contractsPath);
            }
        }

        public void UpdateContract(Contract newContract)
        {
            var temp = GetContract(newContract.contractNumber);

            if (temp == null)
                throw new Exception("Contract with the given details doesn't exist");

            DelContract(temp);
            AddContract(newContract);
            contractsRoot.Save(contractsPath);
        }


        public IEnumerable<Contract> ReturnContracts(Func<Contract, bool> condition = null)
        {

            var result = from c in contractsRoot.Elements()
                         select new Contract(
                             Convert.ToInt32(c.Attribute("Contract_number").Value),
                             Convert.ToInt32(c.Element("Employee_ID").Value),
                             Convert.ToInt32(c.Element("Employer_ID").Value),
                             (c.Element("Was_interviewed").Value).Equals("Yes"),
                             (c.Element("Signed").Value).Equals("Yes"),
                             Convert.ToDouble(c.Element("Bruto_salary").Value),
                             Convert.ToDouble(c.Element("Neto_salary").Value),
                             c.Element("Start_work").Value,
                             c.Element("End_work").Value,
                             Convert.ToInt32(c.Element("Work_hours").Value)
                             );
            if (condition == null)
            {
                return result;
            }

            else
            {
                return result.Where(condition);
            }
        }


        //Banks

        public List<BankAccount> returnAllBranches(Func<BankAccount, bool> condition = null)
        {

            var result = (from b in banksRoot.Elements()
                          select new BankAccount()
                          {
                              bankNumber = Convert.ToInt32(b.Element("קוד_בנק").Value),
                              bankName = b.Element("שם_בנק").Value,
                              branchNumber = Convert.ToInt32(b.Element("קוד_סניף").Value),
                              branchAddress = b.Element("כתובת_ה-ATM").Value,
                              branchCity = b.Element("ישוב").Value,
                              accountNumber = -1
                          });

            var distinctBranches = result.Distinct();
            return distinctBranches.ToList();
        }



        //Individuals

        public Employee GetEmployee(int employeeID)
        {
            var employee = (from e in employeesRoot.Elements()
                            where Convert.ToInt32(e.Attribute("ID").Value) == employeeID
                            select new Employee(
                          e.Element("Name").Value,
                          e.Element("Last_name").Value,
                          Convert.ToInt32(e.Attribute("ID").Value),
                          Convert.ToInt32(e.Element("Telephone_number").Value),
                          e.Element("Address").Value,
                          (Education)Enum.Parse(typeof(Education), e.Element("Education").Value),
                          (e.Element("Served_in_the_military").Value).Equals("Yes"),
                          (e.Element("Has_a_criminal_record").Value).Equals("Yes"),
                          Convert.ToInt32(e.Element("Specialization_number").Value),
                          e.Element("Date_of_birth").Value,
                          Convert.ToInt32(e.Element("Bank_account").Element("קוד_בנק").Value),
                          e.Element("Bank_account").Element("שם_בנק").Value,
                          Convert.ToInt32(e.Element("Bank_account").Element("קוד_סניף").Value),
                          e.Element("Bank_account").Element("כתובת_ה-ATM").Value,
                          e.Element("Bank_account").Element("ישוב").Value,
                          Convert.ToInt32(e.Element("Bank_account").Element("מספר_חשבון").Value)
                          )).FirstOrDefault();

            return employee;

        }

        public Employer GetEmployer(int employerID)
        {
            var employer = (from e in employersRoot.Elements()
                            where e.Attribute("ID").Value.Equals(employerID.ToString())
                            select new Employer(
                           e.Element("Name").Value,
                           e.Element("Last_name").Value,
                           e.Element("Company_name").Value,
                           Convert.ToInt32(e.Attribute("ID").Value),
                           Convert.ToInt32(e.Element("Telephone_number").Value),
                           e.Element("Address").Value,
                           e.Element("Foundation_date").Value,
                           (e.Element("Is_a_company")).Equals("Yes"),
                           (Field)Enum.Parse(typeof(Field), e.Element("Field").Value)
                           )).FirstOrDefault();

            return employer;
        }

        public Contract GetContract(int contractID)
        {
            var contract = (from c in contractsRoot.Elements()
                            where c.Attribute("Contract_number").Value.Equals(contractID.ToString())
                            select new Contract(
                                Convert.ToInt32(c.Attribute("Contract_number").Value),
                                Convert.ToInt32(c.Element("Employer_ID").Value),
                                Convert.ToInt32(c.Element("Employee_ID").Value),
                                (c.Element("Was_interviewed").Value).Equals("Yes"),
                                (c.Element("Signed").Value).Equals("Yes"),
                                Convert.ToDouble(c.Element("Bruto_salary").Value),
                                Convert.ToDouble(c.Element("Neto_salary").Value),
                                c.Element("Start_work").Value,
                                c.Element("End_work").Value,
                                Convert.ToInt32(c.Element("Work_hours").Value)
                                )).FirstOrDefault();

            return contract;
        }

        public Specialization GetSpecialization(int specializationID)
        {
            var spec = (from s in specializationsRoot.Elements()
                        where Convert.ToInt32(s.Attribute("Specialization_number").Value) == specializationID
                        select new Specialization(
                            s.Element("Specialization_name").Value,
                            Convert.ToDouble(s.Element("Minimum_wage").Value),
                            Convert.ToDouble(s.Element("Maximum_wage").Value),
                            (Field)Enum.Parse(typeof(Field), s.Element("Field").Value),
                            Convert.ToInt32(s.Attribute("Specialization_number").Value)
                            )).FirstOrDefault();
            return spec;
        }

        public int ReturnSumOfSalariesGreatherThen(Func<Contract, int> salary, Func<Contract, bool> condition)
        {
            if (condition == null)
                return ReturnContracts().Select(salary).Sum();

            return ReturnContracts(condition).Select(salary).Sum();
        }

        public int HowManyWereInterviewed()
        {
            int num = 0;
            ReturnContracts(contract => contract.wasInterviewed).Select(contract => num++);
            return num;
        }
    }
}

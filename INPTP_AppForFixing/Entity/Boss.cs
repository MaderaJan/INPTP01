﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTP_AppForFixing
{
    public class Boss : Employee
    {
        private const int MONTHS_OF_YEAR = 12;
        private HashSet<Employee> employees;
        private Department department;
        public double PerEmplSalaryBonus { get; set; }


        /// <summary>
        /// Constructor for Boss class.
        /// </summary>
        /// <param name="department">Department under boss control.</param>
        public Boss(Department department)
        {
            employees = new HashSet<Employee>();
            this.department = department;
        }

        public void SetSalaryBonus(double salaryBonus)
        {
            perEmplSalaryBonus = salaryBonus;
        }

        public void InsertEmpl(Employee empl)
        {
            employees.Add(empl);
        }

        /// <summary>
        /// Method on remove employee from boss control.
        /// </summary>
        /// <param name="empl">Employee which is remove from boss control.</param>
        public void PurgeEmpl(Employee empl)
        {
            employees.Remove(empl);
        }


        /// <summary>
        /// Method which return if employess is under boss control.
        /// </summary>
        /// <param name="empl"></param>
        /// <returns>Return true if employee is find. Else return false.  </returns>
        public bool HasEmployee(Employee empl)
        {
            return employees.Contains(empl);
        }


        /// <summary>
        /// Method which return all employees.
        /// </summary>
        /// <returns>Return all employees in HashSet.</returns>
        public ISet<Employee> GetEmployees()
        {
            return new HashSet<Employee>(employees);
        }


        /// <summary>
        /// Property for get count of employees.
        /// </summary>
        /// <returns>Return count of employees.</returns>
        public int EmployeeCount
        {
            get { return employees.Count; }
        }
            
        /// <summary>
        /// Method which calculate year salary and subemployee bonus (include boss salary).
        /// </summary>
        /// <returns>Return value of year department salary.</returns>
        public override double CalcYearlySalaryCZK()
        {
            return (base.CalcYearlySalaryCZK() + (EmployeeCount * PerEmplSalaryBonus * MONTHS_OF_YEAR));
        }

        /// <summary>
        /// Method calculate yearly income of all employees (with VAT).
        /// </summary>
        /// <returns>Return calculate yearly income after tax.</returns>
        public override double CalcYearlyIncome()
        {
            return MonthlySalaryCZK * MONTHS_OF_YEAR * (1 - Boss.TaxRate) + (MONTHS_OF_YEAR * (EmployeeCount * PerEmplSalaryBonus * (1 - Boss.TaxRate)));
        }
    }
}

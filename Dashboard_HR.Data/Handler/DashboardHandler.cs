using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardHR.Models.Models;
using Dashboard_HR.Repository;
using Dashboard_HR.Repository.Repository;

namespace Dashboard_HR.Data.Handler
{
    public class DashboardHandler : DashboardHr
    {
        private List<Department> _aDepartments;
        private List<ConpanyUnit> _conpanyUnits;
        private List<Division> _divisions;
        private List<Section> _sections;
        private List<SubSection> _ssections;
        private List<Employee> _employees;
        private DashboardHr _aDashboardHr;

        public List<Division> GetHrDivisions()
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrDivisionFromDb();
            return ListGenerateDivision(data);
        }
        public List<ConpanyUnit> GetHrUnits()
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrUnitsFromDb();
            return ListGenerateUnit(data);
        }
        public List<Department> GetHrDepartments(string companyCode)
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrDepartmentsFromDb(companyCode);
            return ListGenerate(data);
        }
        public List<Section> GetHrSections(string companyCode)
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrSectionsFromDb(companyCode);
            return ListGenerateSection(data);
        }
        public List<SubSection> GetHrSubSections(string companyCode)
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrSubSectionsFromDb(companyCode);
            return ListGenerateSubSection(data);
        }
        
        public List<Employee> GetHrUnallocatedEmpList(string companyCode)
        {
            _aDashboardHr = new DashboardHr();
            var data = _aDashboardHr.GetHrUnallocatedEmpListFromDb(companyCode);
            return UnallocatedEmpListGenerate(data);
        }
        public List<Employee> GetHrAllocatedEmpList(CompanyCode companyObj) 
        {
            _aDashboardHr = new DashboardHr(); 
            var data = _aDashboardHr.GetHrAllocatedEmpListFromDb(companyObj.Company,companyObj.Dept, companyObj.Section, companyObj.SubSection); 
            return AllocatedEmpListGenerate(data);
        }
        private List<Employee> UnallocatedEmpListGenerate(DataTable employee)
        {
            _employees = new List<Employee>();
            foreach (DataRow aRow in employee.Rows)
            {
                var aEmployee = new Employee
                {
                    EmployeeCode = aRow["EmployeeCode"].ToString(),
                    EmployeeName = aRow["EmployeeName"].ToString(),
                    EmployeeStatus = aRow["EmployeeStatus"].ToString(),
                    Designation = aRow["Designation"].ToString(),
                    Department = aRow["Department"].ToString(),
                    Total = Convert.ToDouble(aRow["Total"].ToString())
                };
                _employees.Add(aEmployee);
            }
            return _employees;
        }
        private List<Employee> AllocatedEmpListGenerate(DataTable employee)
        {
            _employees = new List<Employee>();
            foreach (DataRow aRow in employee.Rows)
            {
                //AE.CompanyName, AE.BudgetCode, AE.CompanyShortName, AE.EmployeeCode, E.EmployeeName, E.Designation,
                //AE.SubSection, 'Line one' AS Line 
                var aEmployee = new Employee
                {
                    EmployeeCode = aRow["EmployeeCode"].ToString(),
                    EmployeeName = aRow["EmployeeName"].ToString(),
                    Designation = aRow["Designation"].ToString(),
                    BudgetCode = aRow["BudgetCode"].ToString(),
                    SubSection = aRow["SubSection"].ToString(),
                    Line=aRow["Line"].ToString(),
                    Total = Convert.ToDouble(aRow["Total"].ToString())
                };
                _employees.Add(aEmployee);
            }
            return _employees;
        } 

        private List<Division> ListGenerateDivision(DataTable aDivision)
        {
            try
            {
                _divisions = new List<Division>();
                foreach (DataRow aRow in aDivision.Rows)
                {
                    var division = new Division
                    {
                        DivisionId = aRow[0].ToString(),
                        DivisionName = aRow[1].ToString(),
                        DivisionTotal = (int)aRow[2],
                        Unallocated = (int)aRow[3],
                        CompanyName = aRow[4].ToString(),
                        CompanyCode = aRow[5].ToString()
                    };
                    _divisions.Add(division);
                }

            }
            catch (Exception ex)
            {
                return _divisions;
            }
            return _divisions;
        }
        private List<ConpanyUnit> ListGenerateUnit(DataTable aCompanyUnit)
        {
           // UnitCD, DT.UnitName, COUNT(*) UnitTotal, (SELECT COUNT(*) Unallocated
            try
            {
                _conpanyUnits = new List<ConpanyUnit>();
                foreach (DataRow aRow in aCompanyUnit.Rows)
                {
                    var conpanyUnit = new ConpanyUnit
                    {
                        UnitId = (string)aRow["UnitCD"],
                        UnitName = (string)aRow["UnitName"],
                        UnitTotal = (int)aRow["UnitTotal"],
                        Unallocated = (int)aRow["Unallocated"],
                        //CompanyName = (string)aRow[4],
                        //CompanyCode = (string)aRow[5],
                    };
                    _conpanyUnits.Add(conpanyUnit);
                }
            }
            catch (Exception ex)
            {
                return _conpanyUnits;
            }
            return _conpanyUnits;
        }
        private List<Department> ListGenerate(DataTable aDataTable)
        {
            try
            {
                _aDepartments = new List<Department>();
                foreach (DataRow aRow in aDataTable.Rows)
                {
                    var aDepartment = new Department
                    {
                        DeptId = (int)aRow["DeptCD"],
                        DeptName = aRow["Department"].ToString(),
                        DeptTotal = (int)aRow["DepartmentTotal"]
                    };
                    _aDepartments.Add(aDepartment);
                }
            }
            catch (Exception ex)
            {
                return _aDepartments;
            }
            return _aDepartments;
        }
        private List<Section> ListGenerateSection(DataTable aDataTable)
        {
            try
            {
                _sections = new List<Section>();
                foreach (DataRow aRow in aDataTable.Rows)
                {
                    var aSection = new Section
                    {
                        SectionName = aRow["Section"].ToString(),
                        SectionTotal = Convert.ToInt32(aRow["SectionTotal"].ToString()),
                        SectionId = (int)aRow["SecCD"],
                        DeptId = (int)aRow["DeptCD"]
                    };
                    _sections.Add(aSection);
                }
            }
            catch (Exception)
            {
                return _sections;
            }
            return _sections;
        }
        public List<SubSection> ListGenerateSubSection(DataTable aDataTable)
        {
            try
            {
                _ssections = new List<SubSection>();
                foreach (DataRow aRow in aDataTable.Rows)
                {
                    var aSSection = new SubSection
                    {
                        SSection = aRow["SubSection"].ToString(),
                        SSectionTotal = (int)aRow["SSectionTotal"],
                        SSectionId = (int)aRow["SSecCD"],
                        SectionId = (int)aRow["SecCD"],
                        DeptId = (int) aRow["DeptCD"]
                    };
                    _ssections.Add(aSSection);
                }
            }
            catch (Exception)
            {
                return _ssections;
            }
            return _ssections;
        }
        
    }
}

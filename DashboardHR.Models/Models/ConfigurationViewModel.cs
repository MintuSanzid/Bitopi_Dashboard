namespace DashboardHR.Models.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Budget { get; set; }
        public string Actual { get; set; }
        public string Shartage { get; set; }
        public string Exceed { get; set; }
        public string Unallocated { get; set; } 

    }
    public class CompanyObj 
    {
        public string CompanyId { get; set; }
        public string UnitId { get; set; }
        public int DivisionId { get; set; }
        public int DepartmentId { get; set; }
        public int SectionId { get; set; } 
        public int SubSectionId { get; set; }  
    }

    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeStatus { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }

        public string BudgetCode { get; set; }
        public string SubSection { get; set; }
        public string Line { get; set; } 

        public double Total { get; set; }
        //  public Company ACompany { get; set; }
    }
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public int DeptTotal { get; set; }
    }
    public class ConpanyUnit
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string UnitId { get; set; }
        public string UnitName { get; set; }
        public int UnitTotal { get; set; }
        public int Unallocated { get; set; }
    }
    public class Division
    {
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string DivisionId { get; set; }
        public string DivisionName { get; set; }
        public int DivisionTotal { get; set; }
        public int Unallocated { get; set; }
    }
    public class Section
    {
        public string SectionName { get; set; }
        public int SectionTotal { get; set; }
        public int DeptId { get; set; }
        public int SectionId { get; set; }
    }
    public class SubSection
    {
        public string SSection { get; set; }
        public int SSectionTotal { get; set; }
        public int SSectionId { get; set; }
        public int SectionId { get; set; }
        public int DeptId { get; set; } 
    }
    public class Line
    {
        public EmpType AEmpType { get; set; }
    }
    public class EmpType
    {
        public DesignationGp ADesignationGp { get; set; }
    }
    public class DesignationGp
    {

    }
    public class ConfigurationViewModel
    {
        //public SettingsGlobalEntity SettingsGlobalEntity { get; set; }
        //public SoftwareDomainEntity SoftwareDomainEntity { get; set; }
        //public HardwareDomainEntity HardwareDomainEntity { get; set; }
        //public FirmwareDomainEntity FirmwareDomainEntity { get; set; }
        //public SoftwarePriorityEntity SoftwarePriorityEntity { get; set; }
        //public HardwarePriorityEntity HardwarePriorityEntity { get; set; }
        //public FirmwarePriorityEntity FirmwarePriorityEntity { get; set; }
        //public ThumbnailEntity ThumbnailEntity { get; set; }
    }

}

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace Dashboard_HR.Repository.Repository
{
    public class DashboardHr
    {
        public DataTable ADataTable;
        private const string Con = "Server=192.168.10.5;database=HR; Trusted_Connection=False; Connection Timeout=3600; Pooling=false; uid=sa;pwd=sqlbis@^7*";

        public DataTable GetHrCompanyFromDb()
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[Dashboard_Get_HR_Companies]", conn);
                    cmd.Parameters.Add(new SqlParameter("@UserId", "BGL"));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public DataTable GetHrAllDivisionFromDb()
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_Divisions_Test]", conn);
                    cmd.Parameters.Add(new SqlParameter("@UserId", "BGL"));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
       
        public DataTable GetHrUnitsFromDb()
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_Units]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", "BGL"));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        
        public DataTable GetHrDepartmentsFromDb(string companyCode, string unitCode)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_Department]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", companyCode));
                    cmd.Parameters.Add(new SqlParameter("@UnitCode", unitCode));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetHrSectionsFromDb(string companyCode, string unitCode) 
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_Sections_By_Department]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", companyCode));
                    cmd.Parameters.Add(new SqlParameter("@UnitCode", unitCode));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetHrSubSectionsFromDb(string companyCode, string unitCode)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_SubSections_By_Section]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", companyCode));
                    cmd.Parameters.Add(new SqlParameter("@UnitCode", unitCode));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }
        public DataTable GetHrUnallocatedEmpListFromDb(string companyCode)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_UnAllocatedEmployeeDetails]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", companyCode));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }

        public DataTable GetHrAllocatedEmpListFromDb(string companyId, string unitId ,int departmentid, int sectionId, int subSectionId)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[HR].[dbo].[Dashboard_Get_HR_AllocatedEmployeeDetails]", conn);
                    cmd.Parameters.Add(new SqlParameter("@CompanyCode", companyId));
                    cmd.Parameters.Add(new SqlParameter("@UnitId", unitId));
                    cmd.Parameters.Add(new SqlParameter("@Departmentid", departmentid));
                    cmd.Parameters.Add(new SqlParameter("@SectionId", sectionId));
                    cmd.Parameters.Add(new SqlParameter("@SubSectionId", subSectionId));
                    cmd.CommandType = CommandType.StoredProcedure;
                    da.SelectCommand = cmd;
                    da.Fill(ADataTable);
                    return ADataTable;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    cmd.Dispose();
                    conn.Close();
                }
            }
        }


      
    }
}

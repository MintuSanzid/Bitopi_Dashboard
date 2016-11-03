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
        private const string Con = "server=192.168.10.5;database=HR; Trusted_Connection=False; Connection Timeout=3600; Pooling=false; uid=sa;pwd=sqlbis@^7*";

        public DataTable GetHrDivisionFromDb()
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_Division]", conn);
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
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_UNIT_TEST]", conn);
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
        public DataTable GetHrDepartmentsFromDb(string companyCode)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_Department]", conn);
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
        public DataTable GetHrSectionsFromDb(string companyCode) 
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_Sections_By_Department]", conn);
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
        public DataTable GetHrSubSectionsFromDb(string companyCode)
        {
            using (var conn = new SqlConnection(Con))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                ADataTable = new DataTable();
                try
                {
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_SubSections_By_Section]", conn);
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
                    cmd = new SqlCommand("[dbo].[Dashboard_Get_HR_AllEmployeeDetails]", conn);
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
    }
}

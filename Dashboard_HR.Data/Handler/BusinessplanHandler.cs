using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashboardHR.Models.Models;
using Dashboard_HR.Repository.Repository;

namespace Dashboard_HR.Data.Handler
{
    public class BusinessplanHandler
    {
        private readonly DashboardBp _aDashboardBp;
        private Businessplan _aBusinessplans;
        private List<BusinessplanData> _aBusinessplanData;
        public BusinessplanHandler()
        {
            _aDashboardBp = new DashboardBp();
        }

        public Businessplan GetBusinessplanData()
        {
            var data = _aDashboardBp.GetBusinessplanDataFromDb();
            return ListGenerateBusinessplanData(data);
        }
        private Businessplan ListGenerateBusinessplanData(DataSet aDataSet)
        {
            try
            {
                var aBuyers = new List<Buyer>();
                GetBuyerList(aDataSet, aBuyers);

                var aMerchants = new List<Merchant>();
                GetMerchantsList(aDataSet, aMerchants);

                var aCompanys = new List<Company>();
                GetCompanysList(aDataSet, aCompanys);

                _aBusinessplans = new Businessplan
                {
                    Buyers = aBuyers,
                    Merchants = aMerchants,
                    Companies = aCompanys
                };
            }
            catch (Exception ex)
            {
                return _aBusinessplans;
            }
            return _aBusinessplans;
        }

        private void GetCompanysList(DataSet aDataSet, List<Company> aCompanys)
        {
            aCompanys.AddRange(from DataRow aRow in aDataSet.Tables[2].Rows
                               select new Company
                               {
                                   CompanyCode = aRow["CompanyCode"].ToString(),
                                   CompanyName = aRow["CompanyName"].ToString()
                               });
        }

        private static void GetMerchantsList(DataSet aDataSet, List<Merchant> aMerchants)
        {
            aMerchants.AddRange(from DataRow aRow in aDataSet.Tables[1].Rows
                                select new Merchant
                                {
                                    MerchantCode = aRow["MerchantCode"].ToString(),
                                    MerchantName = aRow["MerchantName"].ToString()
                                });
        }

        private static void GetBuyerList(DataSet aDataSet, List<Buyer> aBuyers)
        {
            aBuyers.AddRange(from DataRow aRow in aDataSet.Tables[0].Rows
                             select new Buyer
                             {
                                 BuyerCode = aRow["BuyerCode"].ToString(),
                                 BuyerName = aRow["BuyerName"].ToString(),
                             });
        }

        public List<BusinessplanData> GetDashboardFindByCompanyData()
        {
            try
            {
                var data = _aDashboardBp.GetDashboardFindByCompanyFromDb();
                return ListGenerateGetDashboardFindByCompanyData(data);
            }
            catch (Exception ex)
            {
                return _aBusinessplanData;
            }
        }

        private List<BusinessplanData> ListGenerateGetDashboardFindByCompanyData(DataSet aDataSet)
        {
            _aBusinessplanData = new List<BusinessplanData>();
            foreach (DataRow aRow in aDataSet.Tables[0].Rows)
            {
                var aBusinessplanData = new BusinessplanData();
                aBusinessplanData.BusinessName = "Capacity";
                aBusinessplanData.Month0 = "9000";
                aBusinessplanData.Month1 = "9000";
                aBusinessplanData.Month2 = "9000";
                aBusinessplanData.Month3 = "9000";
                aBusinessplanData.Month4 = "9000";
                aBusinessplanData.Month5 = "9000";
                aBusinessplanData.Month6 = "9000";
                aBusinessplanData.Month7 = "9000";
                aBusinessplanData.Month8 = "9000";
                aBusinessplanData.Month9 = "9000";
                aBusinessplanData.Month10 = "9000";
                aBusinessplanData.Month11 = "9000";
                _aBusinessplanData.Add(aBusinessplanData);
            }
            return _aBusinessplanData;
        }
    }
}

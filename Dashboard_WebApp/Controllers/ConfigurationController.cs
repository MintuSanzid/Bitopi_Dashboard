using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using DashboardHR.Models.Models;
using Dashboard_HR.Data.Handler;

namespace Dashboard_WebApp.Controllers
{
    [Authorize]
    public class ConfigurationController : Controller
    {
        private readonly DashboardHandler _aDashboardHandler;

        public ConfigurationController()
        {
            _aDashboardHandler = new DashboardHandler();
        }
        
        // GET: Configuration/DashboardHRF
        public ActionResult DashboardHRF()
        {
            return View();
        }
        // GET: Configuration/DashboardUnitJsonData
        public JsonResult DashboardDivisionJsonData()
        {
            List<Division> data = _aDashboardHandler.GetHrDivisions();
            return Json(data, JsonRequestBehavior.AllowGet);
        }


        // GET: Configuration/DashboardUnitJsonData
        public JsonResult DashboardUnitJsonData()
        {
            List<ConpanyUnit> data = _aDashboardHandler.GetHrUnits();
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        // GET: Configuration/DashboardHRFJson
        public JsonResult DashboardHRFJson(string companyCode)
        {
            List<Department> data = _aDashboardHandler.GetHrDepartments(companyCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DashboardHRFSectionJson(string companyCode) 
        {
            List<Section> data = _aDashboardHandler.GetHrSections(companyCode);
            return Json(data, JsonRequestBehavior.AllowGet); 
        }
        public JsonResult DashboardHRFSubSectionJson(string companyCode)
        {
            List<SubSection> data = _aDashboardHandler.GetHrSubSections(companyCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DashboardUnallocatedEmpList(string companyCode) 
        {
            var data = _aDashboardHandler.GetHrUnallocatedEmpList(companyCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DashboardAllocatedEmpList(CompanyCode companyCode)
        {
            var data = _aDashboardHandler.GetHrAllocatedEmpList(companyCode);
            return Json(data, JsonRequestBehavior.AllowGet);
        }







        // GET: Configuration/DashboardHRFC
        [ActionName("DashboardHRFC")]
        [Authorize]
        public ActionResult DashboardHRFC()
        {
            return View("DashboardHRFC");
        }

        // POST: Configuration/DashboardHRFC
        [ActionName("DashboardHRFC")]
        [HttpPost]
        [Authorize]
        public ActionResult DashboardHRFC(ConfigurationViewModel collection)
        {
            //var aDataHandler = new ConfigurationSettingsDataHandler();
            try
            {
                //    if (TempData["ConfigurationViewModel"] != null)
                //    {
                //        var oldCollection = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                //        aDataHandler.DashboardHrp(collection, oldCollection);
                //    }
                //    else
                //    {
                //        var configurationViewModel = aDataHandler.GetSettings();
                //        TempData["ConfigurationViewModel"] = configurationViewModel;
                //        DashboardHrp(collection);
                //    }
                return View("DashboardHRFC");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return ViewBag as ActionResult;
            }
        }


        // GET: Configuration/DashboardHraw
        [ActionName("DashboardHraw")]
        [Authorize]
        public ActionResult DashboardHraw()
        {
            return View("DashboardHraw");
        }

        // POST: Configuration/DashboardHraw
        [ActionName("DashboardHraw")]
        [HttpPost]
        [Authorize]
        public ActionResult DashboardHraw(ConfigurationViewModel collection)
        {
            //var aDataHandler = new ConfigurationSettingsDataHandler();
            try
            {
                //    if (TempData["ConfigurationViewModel"] != null)
                //    {
                //        var oldCollection = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                //        aDataHandler.DashboardHrp(collection, oldCollection);
                //    }
                //    else
                //    {
                //        var configurationViewModel = aDataHandler.GetSettings();
                //        TempData["ConfigurationViewModel"] = configurationViewModel;
                //        DashboardHrp(collection);
                //    }
                return View("DashboardHraw");
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return ViewBag as ActionResult;
            }
        }


        // GET: Configuration/HomeJsonResult
        [ActionName("HomeJsonResult")]
        [Authorize]
        public JsonResult HomeJsonResult()
        {
            if (TempData["ConfigurationViewModel"] != null)
            {
                var configurationViewModel = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                TempData["ConfigurationViewModel"] = configurationViewModel;
                return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //var aDataHandler = new ConfigurationSettingsDataHandler();
                //var configurationViewModel = aDataHandler.GetSettings();
                //TempData["ConfigurationViewModel"] = configurationViewModel;
                //return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        // GET: Configuration/DashboardHrp
        [ActionName("DashboardHrp")]
        [Authorize]
        public ActionResult DashboardHrp()
        {
            return View();
        }

        // POST: Configuration/DashboardHrp
        [ActionName("DashboardHrp")]
        [HttpPost]
        [Authorize]
        public ActionResult DashboardHrp(ConfigurationViewModel collection)
        {
            //var aDataHandler = new ConfigurationSettingsDataHandler();
            try
            {
                //    if (TempData["ConfigurationViewModel"] != null)
                //    {
                //        var oldCollection = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                //        aDataHandler.DashboardHrp(collection, oldCollection);
                //    }
                //    else
                //    {
                //        var configurationViewModel = aDataHandler.GetSettings();
                //        TempData["ConfigurationViewModel"] = configurationViewModel;
                //        DashboardHrp(collection);
                //    }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return ViewBag as ActionResult;
            }
        }

        // GET: Configuration/DashboardHrpJsonResult
        [ActionName("DashboardHrpJsonResult")]
        [Authorize]
        public JsonResult DashboardHrpJsonResult()
        {
            if (TempData["ConfigurationViewModel"] != null)
            {
                var configurationViewModel = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                TempData["ConfigurationViewModel"] = configurationViewModel;
                return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //var aDataHandler = new ConfigurationSettingsDataHandler();
                //var configurationViewModel = aDataHandler.GetSettings();
                //TempData["ConfigurationViewModel"] = configurationViewModel;
                //return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
                return null;
            }
        }


        /// <summary>
        ///  dashboard 
        /// </summary>
        /// <returns></returns>
        // GET: Configuration/Dashboard
        [ActionName("Dashboard")]
        [Authorize]
        public ActionResult Dashboard()
        {
            return View("Dashboard");
        }

        // POST: Configuration/Dashboard
        [ActionName("Dashboard")]
        [HttpPost]
        [Authorize]
        public ActionResult Dashboard(ConfigurationViewModel collection)
        {
            //var aDataHandler = new ConfigurationSettingsDataHandler();
            try
            {
                //    if (TempData["ConfigurationViewModel"] != null)
                //    {
                //        var oldCollection = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                //        aDataHandler.DashboardHrp(collection, oldCollection);
                //    }
                //    else
                //    {
                //        var configurationViewModel = aDataHandler.GetSettings();
                //        TempData["ConfigurationViewModel"] = configurationViewModel;
                //        DashboardHrp(collection);
                //    }
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                return ViewBag as ActionResult;
            }
        }

        // GET: Configuration/DashboardHrpJsonResult
        [ActionName("DashboardHrpJsonResult")]
        [Authorize]
        public JsonResult DashboardJsonResult()
        {
            if (TempData["ConfigurationViewModel"] != null)
            {
                var configurationViewModel = TempData["ConfigurationViewModel"] as ConfigurationViewModel;
                TempData["ConfigurationViewModel"] = configurationViewModel;
                return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                //var aDataHandler = new ConfigurationSettingsDataHandler();
                //var configurationViewModel = aDataHandler.GetSettings();
                //TempData["ConfigurationViewModel"] = configurationViewModel;
                //return Json(configurationViewModel, JsonRequestBehavior.AllowGet);
                return null;
            }
        }

        // GET: Configuration/DashboardHR
        public ActionResult DashboardHr()
        {
            List<Section> aSection = new List<Section>();
            return View("DashboardHR", aSection);
        }

        // GET: Configuration/DisplaySection
        [ActionName("DisplaySection")]
        [Authorize]
        public ActionResult DisplaySection()
        {
            return PartialView("_PartialCompanies/_Sections");
        }
        // GET: Configuration/DisplaySubSection 
        [ActionName("DisplaySubSection")]
        [Authorize]
        public ActionResult DisplaySubSection()
        {
            return PartialView("_PartialCompanies/_SubSections");
        }

        // GET: Configuration/DisplayLine
        [ActionName("DisplayLine")]
        [Authorize]
        public ActionResult DisplayLine()
        {
            return PartialView("_PartialCompanies/_Lines");
        }

        // GET: Configuration/DisplayEmpType 
        [ActionName("DisplayEmpType")]
        [Authorize]
        public ActionResult DisplayEmpType()
        {
            return PartialView("_PartialCompanies/_Emptypes");
        }

        // GET: Configuration/DisplayDesignationGp 
        [ActionName("DisplayDesignationGp")]
        [Authorize]
        public ActionResult DisplayDesignationGp()
        {
            return PartialView("_PartialCompanies/_DesignationGps");
        }

        // GET: Configuration/DisplayDesignation
        [ActionName("DisplayDesignation")]
        [Authorize]
        public ActionResult DisplayDesignation()
        {
            return PartialView("_PartialCompanies/_Designations");
        }

        // GET: Configuration/DisplayEmpNames
        [ActionName("DisplayEmpNames")]
        [Authorize]
        public ActionResult DisplayEmpNames()
        {
            return PartialView("_PartialCompanies/_EmpNames");
        }
    }
}

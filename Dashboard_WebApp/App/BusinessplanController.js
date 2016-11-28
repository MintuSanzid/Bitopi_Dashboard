
var app = angular.module("app", ["ngDialog"]);

app.controller("BusinessplanController", function ($scope, $rootScope, $http, $filter, $window, ngDialog) {

    function openngDiologValidationUnit() {
        $http.get("/Businessplan/DashboardJsonData").then(function (businessplan) {
            if (businessplan.status === 200) {
                $scope.Buyers = businessplan.data.Buyers;
                $scope.Merchants = businessplan.data.Merchants;
                $scope.Companies = businessplan.data.Companies;
            }
        });
    }
    openngDiologValidationUnit();

    function loadMonths() {
        var monthnames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        var date = new Date();
        var currentMnth = date.getMonth();
        $scope.PlanStartMonth = currentMnth;

        var currentYear = date.getFullYear().toString().substr(2, 2);
        $scope.SetMonths = [];
        for (var i = 0; i < 12; i++) {
            if (currentMnth === 12) {
                currentMnth = 0;
                currentYear++;
            }
            $scope.SetMonths.push(monthnames[currentMnth] + "-" + currentYear);
            currentMnth++;
        }
    };
    loadMonths();


    ////// Get Data From DB //////

    $scope.ShowBusinessPlan = function () {
        var info = {};
        info.BuyerCode = $scope.BuyerCode;
        info.MerchantCode = $scope.MerchantCode;
        info.CompanyCode = $scope.CompanyCode;
        var config = { params: info, headers: { 'Accept': "application/json" } };
        $http.get("/Businessplan/DashboardFindByCompanyJsonData", config).then(function (businessplanData) {
            if (businessplanData.data.length > 0 && businessplanData.status === 200) {
                $scope.Bsinessplans = businessplanData.data;
            };
        });
    }
});

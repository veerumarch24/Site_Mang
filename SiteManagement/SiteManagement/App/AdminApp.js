
var app = angular.module('AdminApp', ['ngRoute', 'angularUtils.directives.dirPagination', 'ui.bootstrap', 'ngSanitize', 'Alertify', 'infinite-scroll']);
app.config(function ($routeProvider, $locationProvider, $httpProvider) {

    $routeProvider
        .when('/', { templateUrl: 'Index.html' })
        .when('/Index', { templateUrl: 'Index.html' })
         // User Manager
        .when('/Create-Employee', { templateUrl: 'Employee.html' })
        .when('/View-Employee', { templateUrl: 'EmployeeRpt.html' })
        .when('/Change-Password', { templateUrl: 'ChangePassword.html' })
        .when('/Reset-Password', { templateUrl: 'ResetPassword.html' })

        .when('/Expense-Type', { templateUrl: 'ExpenseType.html' })
        .when('/Expense-Report', { templateUrl: 'ExpenseTypeRpt.html' })
        .when('/Project', { templateUrl: 'Project.html' })
        .when('/Project-Report', { templateUrl: 'ProjectRpt.html' })
        .when('/Item-Unit', { templateUrl: 'Unit.html' })
        .when('/Unit-Report', { templateUrl: 'UnitReport.html' })
        .when('/Items', { templateUrl: 'Items.html' })
        .when('/Items-Report', { templateUrl: 'ItemsReport.html' })
        .when('/Bankers', { templateUrl: 'Bankers.html' })
        .when('/Customers', { templateUrl: 'Customers.html' })
        .when('/Vendors', { templateUrl: 'Vendors.html' })
        .when('/Railways', { templateUrl: 'Railways.html' })
        .when('/BankersRpt', { templateUrl: 'BankersRpt.html' })
        .when('/CustomersRpt', { templateUrl: 'CustomersRpt.html' })
        .when('/VendorsRpt', { templateUrl: 'VendorsRpt.html' })
        .when('/RailwaysRpt', { templateUrl: 'RailwaysRpt.html' })


        .when('/Daily-Expenses', { templateUrl: 'DailyExpenses.html' })
        .when('/Daily-Purchases', { templateUrl: 'DailyPurchases.html' })
        .when('/Labour-Payments', { templateUrl: 'LabourPayments.html' })
        .when('/Request-Money', { templateUrl: 'RequestMoney.html' })
        .when('/Project-Progress', { templateUrl: 'ProjectProgress.html' })
        .when('/Purchase-Order', { templateUrl: 'PurchaseOrder.html' })
        .when('/ImportItems', { templateUrl: 'ImportItems.html' })
        .when('/ItemsVsVendor', { templateUrl: 'ItemsVsVendor.html' })
        .when('/DeliveryChallan', { templateUrl: 'DeliveryChallan.html' })

        .when('/Daily-Expense-Rpt', { templateUrl: 'DailyExpensesRpt.html' })
        .when('/Daily-Purchase-Rpt', { templateUrl: 'DailyPurchaseRpt.html' })
        .when('/Labour-Payments-Rpt', { templateUrl: 'LabourPaymentsRpt.html' })
        .when('/Request-Money-Rpt', { templateUrl: 'RequestMoneyRpt.html' })
        .when('/Project-Progress-Rpt', { templateUrl: 'ProjectProgressRpt.html' })
        .when('/Project-Progress-Image', { templateUrl: 'ProjectProgressByImageRpt.html' })
        .when('/Purchase-Order-Rpt', { templateUrl: 'PurchaseOrderRpt.html' })
        .when('/ImportItemsRpt', { templateUrl: 'ImportItemsRpt.html' })
        .when('/DeliveryChallanRpt', { templateUrl: 'DeliveryChallanRpt.html' })
        .when('/POPDF', { templateUrl: 'POPDF.html' })


        .when('/0', { templateUrl: 'LogOut.html' })
         .otherwise({
             redirectTo: function () {
                 window.location = "../Login.html";
             }
         });
    $httpProvider.interceptors.push('errorHttpInterceptor');
});

app.directive('checkProductImage', function ($http) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            attrs.$observe('ngSrc', function (ngSrc) {
                $http.get(ngSrc).success(function () {
                }).error(function () {
                    element.attr('src', '../fileupload/ProductImages/noimage.jpg'); // set default image
                });
            });
        }
    };
});

app.directive('fileModel', ['$parse', function ($parse) {
    return {
        restrict: 'A',
        link: function (scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            element.bind('change', function () {
                scope.$apply(function () {
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    };
}]);

app.service('fileUpload', ['$http', function ($http) {
    this.uploadFileToUrl = function (file, uploadUrl) {


        var fd = new FormData();
        fd.append('file', file);
        $http.post(uploadUrl, fd, {
            transformRequest: angular.identity,
            headers: { 'Content-Type': undefined }
        })
        .success(function (d) {
            $scope.FileName = d;
        })
        .error(function () {
            alert('Error')
        });
    }
}]);
app.directive('percentageFormat', function () {
    return {
        require: '?ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            if (!ngModelCtrl) {
                return;
            }
            ngModelCtrl.$parsers.push(function (val) {
                if (angular.isUndefined(val)) {
                    var val = '';
                }
                var value;
                var clean = val.replace(/[^0-9\.]/g, '');
                if (parseFloat(clean) > 100) {
                    clean = clean.slice(0, clean.length - 1);
                }
                else {
                    var decimalCheck = clean.split('.');
                    if (!angular.isUndefined(decimalCheck[1])) {
                        decimalCheck[1] = decimalCheck[1].slice(0, 2);
                        clean = decimalCheck[0] + '.' + decimalCheck[1];
                    }
                }
                if (val !== clean) {
                    ngModelCtrl.$setViewValue(clean);
                    ngModelCtrl.$render();
                }
                return clean;
            });
            element.bind('keypress', function (event) {
                if (event.keyCode === 32) {
                    event.preventDefault();
                }
            });
        }
    };
});
app.directive("disableRightClick", function () {
    return {
        restict: 'A',
        link: function (scope, el) {
            el.bind("contextmenu", function (e) {
                e.preventDefault();
                //alertify.alert("Right Click Not Allowed.");
            });
        }
    };
});
app.service('dataService', function () {
    var property = 0;
    StateId = property;
});
app.directive('validFile', function () {
    return {
        require: 'ngModel',
        link: function (scope, el, attrs, ngModel) {
            //change event is fired when file is selected
            el.bind('change', function () {
                scope.$apply(function () {
                    ngModel.$setViewValue(el.val());
                    ngModel.$render();
                });
            });
        }
    }
});
app.directive('starRatingView', function () {
    return {
        restrict: 'A',
        template: '<ul class="rating">'
                 + '	<li ng-repeat="star in stars" ng-class="star">'
                 + '\u2605'
                 + '</li>'
                 + '</ul>',
        scope: {
            ratingValue: '=',
            max: '=',
            onRatingSelected: '&'
        },
        link: function (scope, elem, attrs) {
            var updateStars = function () {
                scope.stars = [];
                for (var i = 0; i < scope.max; i++) {
                    scope.stars.push({
                        filled: i < scope.ratingValue
                    });
                }
            };

            scope.$watch('ratingValue',
                function (oldVal, newVal) {
                    if (newVal) {
                        updateStars();
                    }
                }
            );
        }
    };
});
app.directive('ngFiles', ['$parse', function ($parse) {
    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
    }
    return {
        link: fn_link
    };
}]);

app.run(function ($rootScope, $timeout, $document, $http, $templateCache) {

    // Timeout timer value 1 sec = 1000
    //var TimeOutTimerValue = 4000; // 4 sec
    var TimeOutTimerValue = 1000 * 60 * 15; // 15 min

    // Start a timeout
    var TimeOut_Thread = $timeout(function () { LogoutByTimer(); }, TimeOutTimerValue);
    var bodyElement = angular.element($document);

    /// Keyboard Events
    bodyElement.bind('keydown', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('keyup', function (e) { TimeOut_Resetter(e); });

    /// Mouse Events    
    bodyElement.bind('click', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('mousemove', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('DOMMouseScroll', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('mousewheel', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('mousedown', function (e) { TimeOut_Resetter(e); });

    /// Touch Events
    bodyElement.bind('touchstart', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('touchmove', function (e) { TimeOut_Resetter(e); });

    /// Common Events
    bodyElement.bind('scroll', function (e) { TimeOut_Resetter(e); });
    bodyElement.bind('focus', function (e) { TimeOut_Resetter(e); });

    function LogoutByTimer() {
        if (isUndefinedOrNull(sessionStorage.getItem("Uid")) !== '') {

            $rootScope.logoutparams = {};
            $rootScope.logoutparams.action = 'Up';
            $rootScope.logoutparams.loginid = sessionStorage.getItem("Uid");
            $rootScope.logoutparams.usertype = 'Admin';
            $rootScope.logoutparams.sesid = sessionStorage.getItem("Sesid");

            var req = {
                method: 'POST',
                url: "../api/Login/SessionsInOut",
                data: { Info: EncriptInfo(JSON.stringify($rootScope.logoutparams)) }
            };
            $http(req)
               .success(function (Response) {
                   sessionStorage.removeItem("Uid");
                   sessionStorage.setItem("Admin", null);
                   sessionStorage.setItem("Sesid", null);

                   window.location = "../Login.html";
               });
        }
        else {
            sessionStorage.removeItem("Uid");
            sessionStorage.setItem("Admin", null);
            sessionStorage.setItem("Sesid", null);

            window.location = "../Login.html";
        }
    }

    function TimeOut_Resetter(e) {
        /// Stop the pending timeout
        $timeout.cancel(TimeOut_Thread);

        /// Reset the timeout
        TimeOut_Thread = $timeout(function () { LogoutByTimer(); }, TimeOutTimerValue);
    }


    // Login ID Checking Start  

    var bodyElement1 = angular.element($document);
    /// Keyboard Events
    bodyElement1.bind('keydown', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('keyup', function (e) { TimeOut_Resetter1(e) });

    /// Mouse Events    
    bodyElement1.bind('click', function (e) { TimeOut_Resetter1(e) });
    //bodyElement1.bind('mousemove', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('DOMMouseScroll', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('mousewheel', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('mousedown', function (e) { TimeOut_Resetter1(e) });

    /// Touch Events
    bodyElement1.bind('touchstart', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('touchmove', function (e) { TimeOut_Resetter1(e) });

    /// Common Events
    bodyElement1.bind('scroll', function (e) { TimeOut_Resetter1(e) });
    bodyElement1.bind('focus', function (e) { TimeOut_Resetter1(e) });

    function LogoutByTimer1() {
        if (isUndefinedOrNull(sessionStorage.getItem("Uid")) == '') {
            window.location = "../Login.html";
        }
    }
    function TimeOut_Resetter1(e) {
        TimeOut_Thread1 = $timeout(function () { LogoutByTimer1() }, 0);
    }

    // Login ID Checking End    
});
app.filter('unique', function () {
    return function (collection, keyname) {
        var output = [],
            keys = [];
        angular.forEach(collection, function (item) {
            var key = item[keyname];
            if (keys.indexOf(key) === -1) {
                keys.push(key);
                output.push(item);
            }
        });
        return output;
    };
});
app.factory('$exceptionHandler', function ($injector) {
    return function (exception, cause) {

        var $http = $injector.get("$http");
        var formatted = '';
        var properties = '';
        formatted += 'Broser: "' + get_browser_info() + '" ; \n';
        formatted += 'Location: "' + window.location.href + '" ; \n';
        formatted += 'Exception: "' + exception.toString() + '"\n';
        formatted += 'Caused by: ' + cause + '\n';
        properties += (exception.message) ? 'Message: ' + exception.message + '\n' : ''
        properties += (exception.fileName) ? 'File Name: ' + exception.fileName + '\n' : ''
        properties += (exception.lineNumber) ? 'Line Number: ' + exception.lineNumber + '\n' : ''
        properties += (exception.stack) ? 'Stack Trace: ' + exception.stack + '\n' : ''
        // alert(exception.message);
        if (properties) {
            formatted += properties;
        }

        if (formatted.toLowerCase().indexOf('/api/') == -1) return;

        var reqsenderrormsg = {
            method: 'POST',
            url: "../api/Login/SendErrorMessage",
            params: { subject: 'healthywayz', error: formatted }
        };
        $http(reqsenderrormsg)
           .success(function () {
           });

    }
});
app.factory('errorHttpInterceptor', function ($exceptionHandler, $q) {
    return {
        responseError: function responseError(rejection) {
            $exceptionHandler("An HTTP request error has occurred.\nHTTP config: " + JSON.stringify(rejection.config) + ".\nStatus: " + rejection.status);
            return $q.reject(rejection);
        }
    };
});


app.controller('LinksController', function ($scope, $http, $timeout, $route, $location) {

    $scope.ResponsiveMenuActive = false;
    $scope.SetResponsiveMenuActive = function () {
        $scope.ResponsiveMenuActive = $scope.ResponsiveMenuActive == false ? true : false;
    };
    $scope.Admin = sessionStorage.getItem("Admin");

    $scope.loader = true;

    $scope.GetLinks = function () {
        $scope.params = {};
        $scope.params.action = 'Admin';
        $scope.params.Id = sessionStorage.getItem("Uid");

        var reqlinks = {
            method: 'POST',
            url: "../api/Site/MainLinks",
            data: { Info: EncriptInfo(JSON.stringify($scope.params)) }
        };
        $http(reqlinks)
           .success(function (linksdata) {
               $scope.AdminLinks = linksdata;
               $scope.loader = false;
           });
    };
    $scope.GetLinks();
    //$rootScope.$on('ReloadLonks', function () {       
    //        $scope.GetLinks();        
    //});

    $scope.LinkClick = function (parent) {
        if ($scope.Parent !== parent)
            $scope.Parent = parent;
        else
            $scope.Parent = 0;
    };
    $scope.PageRedirection = function (childid, disppage) {
        $scope.ResponsiveMenuActive = false;
        $scope.ChildId = childid;
        window.location.href = '#/' + disppage;
        $timeout(function () { $route.reload(), $('.modal-backdrop').remove(); }, 0);
    };
    $scope.menudis = false;
});

app.controller('LogoutCtrl', function ($scope, $http) {
    if (isUndefinedOrNull(sessionStorage.getItem("Uid")) != '') {
        $scope.GetLoginparams = {};
        $scope.GetLoginparams.uid = sessionStorage.getItem("Uid");
        $scope.GetLoginparams.usertype = 'Admin';

        var req = {
            method: 'POST',
            url: "../api/Site/LastLogin",
            data: { Info: EncriptInfo(JSON.stringify($scope.GetLoginparams)) }
        };
        $http(req)
           .success(function (Response) {

               $scope.username = Response[0].username;
               $scope.Name = Response[0].Name;
               $scope.Designation = Response[0].Designation;
           });
    }
    else {
        window.location = "../Login.html";
    }
    $scope.LogOut = function () {
        $scope.logoutsparams = {};
        $scope.logoutsparams.action = 'Up';
        $scope.logoutsparams.loginid = sessionStorage.getItem("Uid");
        $scope.logoutsparams.usertype = 'Admin';
        $scope.logoutsparams.sesid = sessionStorage.getItem("Sesid");
        var req = {
            method: 'POST',
            url: "../api/Login/SessionsInOut",
            data: { Info: EncriptInfo(JSON.stringify($scope.logoutsparams)) }
        };
        $http(req)
           .success(function (Response) {
               sessionStorage.removeItem("Uid");

               sessionStorage.removeItem("Sesid");

               window.location = "../Login.html";
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
});

//Profile Tools

//User Manager
app.controller('CreateUserCtrl', function ($scope, $http, dataService) {
    $scope.ShowUserProfile = "Create Employee";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.HidePwd = true;
    $scope.truefalse = false;
    $scope.distxtname = false;
    $scope.chkInCharge = 0;
    $scope.chkAdmin = 0;
    $scope.txtusername = '';
    $scope.txtpassword = '';
    $scope.txtcnfpassword = '';
    $scope.Status = [{ Value: 0, Text: 'InActive' }, { Value: 1, Text: 'Active' }];
    $scope.Stat = 1;
    if (isUndefinedOrNull(dataService.UserId) != '') {

        $scope.ShowUserProfile = "Edit Employee  / " + dataService.UserId;
        $scope.distxtname = true;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        $scope.HidePwd = false;
        $scope.truefalse = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/GetUsers",
            params: { Uid: dataService.UserId, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.HidePwd = false;
                   $scope.txtCreatedBy = Response[0]["CreatedBy"]
                   $scope.txtname = Response[0]["Name"]
                   $scope.txtmobile = Response[0]["PhoneNo"]
                   $scope.Address = Response[0]["Address"]
                   $scope.Email = Response[0]["EmailID"]
                   $scope.PF = Response[0]["PF"]
                   $scope.ESI = Response[0]["ESI"]
                   $scope.Aadhar = Response[0]["Aadhar"]
                   if (Response[0]["InCharge"] == 1) {
                       $scope.chkInCharge = 1;
                   }

                   if (Response[0]["IsAdmin"] == 1) {
                       $scope.chkAdmin = 1;
                   }

                   $scope.txtusername = Response[0]["UserName"]
                   $scope.txtpassword = "a12345699";
                   $scope.txtcnfpassword = "a12345699";
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
               });
    }
    $scope.CreateUserPro = function () {
        if ($scope.txtpassword != $scope.txtcnfpassword) {
            alertify.alert("Password and Confirm Password Should Be Same");
            return false;
        }

        var reqCreateUserPro = {
            method: 'POST',
            url: "../api/Site/CreateOrUpdateUser",
            params: {
                Uid: 0,
                Action: "IN",
                Name: $scope.txtname,
                Mobile: $scope.txtmobile,
                PF: $scope.PF,
                ESI: $scope.ESI,
                Aadhar: $scope.Aadhar,
                Email: $scope.Email,
                Address: $scope.Address,
                IsInCharge: $scope.chkInCharge,
                IsAdmin: $scope.chkAdmin,
                UserName: $scope.txtusername,
                Password: $scope.txtpassword,
                CreatedBy: sessionStorage.getItem("Uid"),
                Flag: 1,
                LastUpdatedBy: 0,
                DeletedBy: 0,
                sesid: sessionStorage.getItem("Sesid")
            }
        };
        $http(reqCreateUserPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Username Should Be Unique");
               }
               else {
                   alertify.alert("User Created");

                   $scope.txtCreatedBy = '';
                   $scope.txtname = '';
                   $scope.txtmobile = '';
                   $scope.Address = '';
                   $scope.Email = '';
                   $scope.PF = '';
                   $scope.ESI = '';
                   $scope.Aadhar = '';
                   $scope.chkInCharge = 0;
                   $scope.chkAdmin = 0;
                   window.location.href = "#/View-Employee";
                   var reqUsers = {
                       method: 'GET',
                       url: "../api/Site/GetUsers",
                       params: { Uid: 0, Action: 'GetUsers', DeletedBy: 0 }
                   };
                   $http(reqUsers)
                      .success(function (data) {
                          $scope.Users = data;
                      });
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    //  for update
    $scope.UpdateUserPro = function () {
        if ($scope.txtpassword != $scope.txtcnfpassword) {
            alertify.alert("Password and Confirm Password Should Be Same");
            return false;
        }
        var reqUpdateUserPro = {
            method: 'POST',
            url: "../api/Site/CreateOrUpdateUser",
            params: {
                Uid: dataService.UserId,
                Action: "Up",
                Name: $scope.txtname,
                Designation: $scope.Designation,
                DoorNo: $scope.txtdoorno,
                Email: $scope.txtemail,
                Mobile: $scope.txtmobile,
                UserName: $scope.txtusername,
                Password: $scope.txtpassword,
                CreatedBy: $scope.txtCreatedBy,
                Flag: $scope.Stat,
                LastUpdatedBy: sessionStorage.getItem("Uid"),
                DeletedBy: 0,
                sesid: sessionStorage.getItem("Sesid")
            }
        };
        $http(reqUpdateUserPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   alertify.alert("User Updated Successfully");
                   window.location.href = "#/User-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/View-Employee";
    }
});
app.controller('UserReportCtrl', function ($scope, $http, dataService) {
    dataService.UserId = "";
    $scope.Status = 'Active';
    $scope.UserHdr = "Employee Report";
    $scope.loader = true;
    var reqUsers = {
        method: 'GET',
        url: "../api/Site/GetUsers",
        params: { Uid: 0, Action: 'GetUsers', DeletedBy: 0 }
    };
    $http(reqUsers)
       .success(function (data) {
           $scope.Users = data.filter(function (element) { return element.Flag == $scope.Status; });
           $scope.loader = false;
           //  alert(data);
       });


    $scope.ItemsperPage = 10;


    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }
    $scope.EditUser = function (Sid) {
        dataService.UserId = Sid;
        window.location.href = "#/Create-Employee";
    }
    $scope.LinksPremission = function (username) {
        $scope.username = username;

        $scope.MainLinksparams = {};
        $scope.MainLinksparams.uid = $scope.username.toString();
        $scope.MainLinksparams.usertype = 'Admin';
        $scope.MainLinksparams.action = 'Main';

        var reqLinksPremission = {
            method: 'POST',
            url: "../api/Site/LinksPremission",
            data: { Info: EncriptInfo(JSON.stringify($scope.MainLinksparams)) }
        };
        $http(reqLinksPremission)
           .success(function (data) {
               $scope.mainLinks = data;
               $scope.Linkpermview = true;
           });

        $scope.SubLinksparams = {};
        $scope.SubLinksparams.uid = $scope.username.toString();
        $scope.SubLinksparams.usertype = 'Admin';
        $scope.SubLinksparams.action = 'Sub';

        var reqLinksPremission = {
            method: 'POST',
            url: "../api/Site/LinksPremission",
            data: { Info: EncriptInfo(JSON.stringify($scope.SubLinksparams)) }
        };
        $http(reqLinksPremission)
           .success(function (data) {
               $scope.SubLinks = data;
           });

    };
    $scope.UpdateCheckBoxVal = function (index, event) {
        var checkbox = event.target;
        $scope.SubLinks[index]["flag"] = checkbox.checked ? '1' : '0';
    };
    $scope.UpdateLinkPermisions = function () {

        var Lids = ''
        angular.forEach($scope.SubLinks, function (item) {
            if (item.flag == 1 && parseInt(item.Parent) > 0) {
                Lids = Lids + item.Lid + ',';
            };
        });

        $scope.UpLnkPremissionparams = {};
        $scope.UpLnkPremissionparams.uid = $scope.username.toString();
        $scope.UpLnkPremissionparams.usertype = 'Admin';
        $scope.UpLnkPremissionparams.lids = Lids.toString();
        $scope.UpLnkPremissionparams.Updatedby = sessionStorage.getItem('Uid');
        $scope.UpLnkPremissionparams.sessid = '';

        var reqLinksPremission = {
            method: 'POST',
            url: "../api/Site/UpdateLinksPremission",
            data: { Info: EncriptInfo(JSON.stringify($scope.UpLnkPremissionparams)) }
        };

        $http(reqLinksPremission)
           .success(function (data) {
               alertify.alert('Links Permission Updated Successfully');
               $scope.Links = '';
               $scope.Linkpermview = false;
           })
        .error(function (Error) {
            alertify.alert(Error.Message);
        });
    };
    $scope.GtoToUserReport = function () {
        $scope.Linkpermview = false;
        $scope.username = 0;
        $scope.Links = '';
    };

    $scope.exportToExcel = function () {

        $scope.TempInwardRpt = [];
        var sno = 1;
        angular.forEach($scope.Users, function (item) {
            $scope.TempInwardRpt.push({
                Sno: sno,//item.$id,
                UserName: item.UserName,
                Name: item.Name,
                Mobile: item.Mobile,
                Flag: item.Flag
            });
            sno = sno + 1;
        });
        if ($scope.TempInwardRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempInwardRpt, $scope.UserHdr);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "User-Report-" + GetCurrDate() + ".xls");
        };
    };
    $scope.StatusChanged = function () {
        var reqUsers = {
            method: 'GET',
            url: "../api/Site/GetUsers",
            params: { Uid: 0, Action: 'GetUsers', DeletedBy: 0 }
        };
        $http(reqUsers)
           .success(function (data) {
               $scope.Users = data.filter(function (element) { return element.Flag == $scope.Status; });
               $scope.loader = false;

           });

    };

    $scope.UserAdd = function () {
        window.location.href = "#/Create-Employee";
    }
});
app.controller('ChangePasswordCtrl', function ($scope, $http) {
    $scope.Username = sessionStorage.getItem('Admin');
    $scope.checkConfirmPwd = function () {
        if ($scope.txtcnfpassword != '') {
            if ($scope.txtnewpassword != $scope.txtcnfpassword) {
                $scope.ConfirmPassword = true;
            }
            else {
                $scope.ConfirmPassword = false;
            };
        };
    };
    $scope.ChangePassword = function () {
        var reqChangePwd = {
            method: 'POST',
            url: "../api/Site/ChangePassword",
            params: { action: 'ChgAdminPwd', Idno: '', Name: '', Mobile: '', regid: sessionStorage.getItem("Uid"), thru: sessionStorage.getItem("Uid"), opwd: $scope.txtexistingpwd, npwd: $scope.txtnewpassword, sessid: sessionStorage.getItem('Sesid') }
        };
        $http(reqChangePwd)
          .success(function (Response) {
              alertify.alert(Response[0].result);
              $scope.txtexistingpwd = '';
              $scope.txtnewpassword = '';
              $scope.txtcnfpassword = '';
              $scope.Form_ChangePassword.$setPristine();
          })
          .error(function (Message) {
              alertify.alert(Message.Message);
          });
    };
});
app.controller('ResetPasswordCtrl', function ($scope, $http) {

    $scope.loader = false;
    document.getElementById("btnresetlpwd").disabled = false;

    $('#myModal').modal('show');
    $scope.popupclose = function () {
        $('#myModal').modal('hide');
    }
    $scope.CheckUserID = function () {

        document.getElementById("btncheckuserid").disabled = true;
        $scope.ResetParams = {};
        $scope.ResetParams.action = 'Profile';
        $scope.ResetParams.idno = $scope.txtidno;
        var reqCheckUserID = {
            method: 'Post',
            url: "../api/Site/CheckUserID",
            data: { Info: EncriptInfo(JSON.stringify($scope.ResetParams)) }
        };
        $http(reqCheckUserID)
           .success(function (Response) {

               $scope.regid = Response[0].regid;
               if ($scope.regid != "0") {
                   $('#myModal').modal('hide');

                   var reqEdit = {
                       method: 'GET',
                       url: "../api/Site/GetUsers",
                       params: { Uid: $scope.regid, Action: 'Edit', DeletedBy: 0 }
                   };
                   $http(reqEdit)
                          .success(function (Response) {
                              $scope.txtname = Response[0]["Name"]
                              $scope.Designation = Response[0]["Designation"]
                              $scope.txtmobile = Response[0]["Mobile"]
                              $scope.txtusername = Response[0]["UserName"]
                          });

                   document.getElementById("btncheckuserid").disabled = false;
                   document.getElementById("btnresetlpwd").disabled = false;
                   document.getElementById("btnresettpwd").disabled = false;
               }
               else {
                   document.getElementById("btncheckuserid").disabled = false;
                   alertify.alert(Response[0].result)
               };
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.LoadUsers = function () {
        $scope.Designations = '';
        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Users';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Users = data;
               }
               else {
                   $scope.Users = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadUsers();

    $scope.ChangePassword = function (action) {
        var reqChangePwd = {
            method: 'POST',
            url: "../api/Site/ChangePassword",
            params: { action: action, Idno: '', Name: '', Mobile: $scope.txtmobile, regid: $scope.regid, thru: sessionStorage.getItem("Uid"), opwd: '', npwd: '', sessid: sessionStorage.getItem('Sesid') }
        };
        $http(reqChangePwd)
          .success(function (Response) {
              $scope.resetpwdresult = Response[0];
              $scope.loader = false;
              document.getElementById("btnresetlpwd").disabled = false;

              if ($scope.resetpwdresult.result == "Login Password Reset Successfully") {
                  alertify.alert($scope.resetpwdresult.result);
              }
          })
          .error(function (Message) {
              alertify.alert(Message.Message);
          });
    };

});

///////////////////////////// Unit ////////////////////////////////////
app.controller('CreateUnitCtrl', function ($scope, $http, dataService) {
    $scope.ShowUnit = "Create Unit";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.HidePwd = true;
    $scope.UnitNamedis = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;

    if (isUndefinedOrNull(dataService.UnitId) != '') {

        $scope.ShowUserProfile = "Edit Unit  / " + dataService.UnitId;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        $scope.HidePwd = false;
        $scope.UnitNamedis = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/GetUnits",
            params: { Unitid: dataService.UnitId, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.txtUnitName = Response[0]["UnitName"]
                   $scope.txtUnitDescr = Response[0]["UnitDescr"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 0 : 1
               });
    }
    $scope.CreateUnitPro = function () {
        var reqCreateUnitPro = {
            method: 'POST',
            url: "../api/Site/CreateOrUpdateUnit",
            params: {
                Unitid: 0,
                Action: "IN",
                UnitName: $scope.txtUnitName,
                UnitDescr: $scope.txtUnitDescr ? $scope.txtUnitDescr : '',
                CreatedBy: 1,
                Flag: 0,
                LastUpdatedBy: 0,
                DeletedBy: 0,
                sesid: sessionStorage.getItem("Sesid")
            }
        };
        $http(reqCreateUnitPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Unit Name Should Be Unique");
               }
               else {
                   alertify.alert("Unit Created");
                   $scope.txtUnitName = ""; $scope.txtUnitDescr = "";

                   window.location.href = "#/Unit-Report";
                   var reqUsers = {
                       method: 'GET',
                       url: "../api/Site/GetUnits",
                       params: { Unitid: 0, Action: 'GetUnits', DeletedBy: 0 }
                   };
                   $http(reqUsers)
                      .success(function (data) {
                          $scope.Users = data;
                      });
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    //  for update
    $scope.UpdateUnitPro = function () {

        var reqUpdateUnitPro = {
            method: 'POST',
            url: "../api/Site/CreateOrUpdateUnit",
            params: {
                Unitid: dataService.UnitId,
                Action: "Up",
                UnitName: $scope.txtUnitName,
                UnitDescr: $scope.txtUnitDescr ? $scope.txtUnitDescr : '',
                CreatedBy: 1,
                Flag: $scope.Stat,
                LastUpdatedBy: sessionStorage.getItem("Uid"),
                DeletedBy: 0,
                sesid: sessionStorage.getItem("Sesid")
            }
        };
        $http(reqUpdateUnitPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   alertify.alert("Unit Updated Successfully");
                   window.location.href = "#/Unit-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Unit-Report";
    }
});

app.controller('UnitReportCtrl', function ($scope, $http, dataService) {
    dataService.UnitId = "";
    $scope.UnitHdr = "Unit Report";
    $scope.loader = true;
    var reqUsers = {
        method: 'GET',
        url: "../api/Site/GetUnits",
        params: { UnitId: 0, Action: 'GetUnits', DeletedBy: 0 }
    };
    $http(reqUsers)
       .success(function (data) {
           $scope.Units = data;
           $scope.loader = false;
           // alert(data);
       });


    $scope.ItemsperPage = 10;
    $scope.DeleteUnit = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/GetUnits",
            params: { UnitId: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Unit Deleted");
                   $("#myModal").modal('hide');
                   var reqUsers = {
                       method: 'GET',
                       url: "../api/Site/GetUsers",
                       params: { Uid: 0, Action: 'GetUnits', DeletedBy: 0 }
                   };
                   $http(reqUsers)
                      .success(function (data) {
                          $scope.Users = data;
                      });
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }
    $scope.EditUnit = function (Sid) {
        dataService.UnitId = Sid;
        window.location.href = "#/Unit-Master";
    }

    $scope.exportToExcel = function () {

        $scope.TempInwardRpt = [];
        var sno = 1;
        angular.forEach($scope.Units, function (item) {
            $scope.TempInwardRpt.push({
                Sno: sno,//item.$id,
                UnitName: item.UnitName,
                UnitDescr: item.UnitDescr,
                Status: item.Flag
            });
            sno = sno + 1;
        });
        if ($scope.TempInwardRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempInwardRpt, $scope.UnitHdr);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Unit-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.UnitAdd = function () {
        window.location.href = "#/Unit-Master";
    }
});

///////////////////////////// Unit ////////////////////////////////////


///////////////////////////// Item ////////////////////////////////////
app.controller('CreateItemCtrl', function ($scope, $http, dataService) {
    $scope.ShowItem = "Create Item";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.HidePwd = true;
    $scope.truefalse = false;
    $scope.showhideItemType = false;
    $scope.Disable_Item_Type = false;
    $scope.LoadItemTypes = function () {
        $scope.Item_Type = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'ItemTypesADD';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.ItemTypes = data;
               }
               else {
                   $scope.Item_Type = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadItemTypes();


    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;

    $scope.CheckNewLable = function () {
        if ($scope.Item_Type == 'New Group') {
            $scope.showhideItemType = true;
            $scope.ItemTypeNew = '';
            $scope.Disable_Item_Type = true;
        }
        else {
            $scope.showhideItemType = false;
            $scope.ItemTypeNew = $scope.Item_Type;
            $scope.Disable_Item_Type = false;
        }
    };

    $scope.LoadUnits = function () {
        $scope.Unit = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'GetUnits';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Units = data;
               }
               else {
                   $scope.Units = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadUnits();


    $scope.CreateItem = function () {

        if ($scope.Item_Type == 'New Group') {
            $scope.ItemTypeName = $scope.ItemTypeNew;
        }
        else {
            $scope.ItemTypeName = $scope.Item_Type;
        }
        $scope.GETParams = {};
        $scope.GETParams.ID = '0';
        $scope.GETParams.Item_Type = $scope.ItemTypeName;
        $scope.GETParams.Item_Descr = $scope.ItemName;
        $scope.GETParams.ItemName = $scope.ItemName;
        $scope.GETParams.Unit = $scope.Unit
        $scope.GETParams.BranchID = sessionStorage.getItem("BranchID");
        $scope.GETParams.IsActive = '1';
        $scope.GETParams.CreatedDate = '01-01-2017';
        $scope.GETParams.CreatedBy = sessionStorage.getItem("Uid");
        $scope.GETParams.Type = 'ADD';

        var reqCreate = {
            method: 'POST',
            url: "../api/Site/Insert_Item",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETParams)) }
        };
        $http(reqCreate)
           .success(function (Response) {

               if (Response == 'EXITS') {
                   alertify.alert("Item Name Should Be Unique");
               }
               else {
                   alertify.alert("Item Created");
                   $scope.ProjectName = ""; $scope.Descr = "";
                   $scope.StartDate = ""; $scope.Project_Type = ""; $scope.Est_Cost = ""; $scope.ProjectCode = "";

                   window.location.href = "#/Items-Report";
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    //  for update
    $scope.UpdateItem = function () {


        if ($scope.Item_Type == 'New Lable') {
            $scope.ItemTypeName = $scope.ItemTypeNew;
        }
        else {
            $scope.ItemTypeName = $scope.Item_Type;
        }

        $scope.GETParams = {};
        $scope.GETParams.ID = dataService.ID;
        $scope.GETParams.Item_Type = $scope.ItemTypeName;
        $scope.GETParams.Item_Descr = $scope.ItemName;
        $scope.GETParams.ItemName = $scope.ItemName;
        $scope.GETParams.Unit = $scope.Unit
        $scope.GETParams.BranchID = sessionStorage.getItem("BranchID");
        $scope.GETParams.IsActive = $scope.Stat.toString();
        $scope.GETParams.CreatedDate = '01-01-2017';
        $scope.GETParams.CreatedBy = sessionStorage.getItem("Uid");
        $scope.GETParams.Type = 'EDIT';

        var reqUpdate = {
            method: 'POST',
            url: "../api/Site/Insert_Item",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETParams)) }
        };
        $http(reqUpdate)
           .success(function (Response) {
               if (Response == dataService.ID) {
                   alertify.alert("Item Updated Successfully");
                   window.location.href = "#/Items-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Items-Report";
    }
});

app.controller('ItemReportCtrl', function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Hdr = "Items Report";
    $scope.loader = true;
    var reqUsers = {
        method: 'GET',
        url: "../api/Site/GetItems",
        params: { BranchId: "0", ID: '0', Action: 'ALL' }
    };
    $http(reqUsers)
       .success(function (data) {
           $scope.Items = data;
           $scope.loader = false;
           //  alert(data);
       });


    $scope.ItemsperPage = 10;


    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }
    $scope.EditItem = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Items";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.Items, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Item Group': item.Item_Type,
                'Item Name': item.ItemName,
                'Unit': item.Unit,
                'IsActive': item.IsActive
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Hdr);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Items-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.DeleteItem = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqItems = {
            method: 'GET',
            url: "../api/Site/GetItems",
            params: { BranchId: sessionStorage.getItem("BranchID"), ID: $scope.DeleteRecordId, Action: 'Delete' }
        };
        $http(reqItems)
           .success(function (Response) {

               alertify.alert("Item Deleted");
               $("#myModal").modal('hide');
               $scope.Items = Response;
               $scope.loader = false;

           });
    }
    $scope.ItemAdd = function () {
        window.location.href = "#/Items";
    }
});

///////////////////////////// Ittem ////////////////////////////////////

app.controller('ExpenseCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Expense";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ExpID = '';
        $scope.ExpenseType = '';
        $scope.ExpenseDescr = '';
        $scope.Flag = '0';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.ExpID = dataService.ID;
        $scope.readonly = true;
        $scope.Header = "Edit Expense  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Expense",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ExpID = Response[0]["ExpID"]
                   $scope.ExpenseType = Response[0]["ExpenseType"]
                   $scope.ExpenseDescr = Response[0]["ExpenseDescr"]
                   $scope.Flag = Response[0]["Flag"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Expense",
            params: {
                Action: "IN",
                ExpID: $scope.ExpID,
                ExpenseType: $scope.ExpenseType,
                ExpenseDescr: $scope.ExpenseDescr,
                Flag: $scope.Flag
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Expense Should Be Unique");
               }
               else {
                   alertify.alert("Expense Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {
        alert($scope.ExpID)
        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Expense",
            params: {
                Action: "Up",
                ExpID: $scope.ExpID,
                ExpenseType: $scope.ExpenseType,
                ExpenseDescr: $scope.ExpenseDescr,
                Flag: $scope.Stat
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Expense Updated Successfully");
                   window.location.href = "#/Expense-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Expense-Report";
    }
});

app.controller('Expense_RptCtrl', function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Status = 'Active';
    $scope.Header = "Expense Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Expense",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Expense-Type";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'ExpID': ExpID,
                'ExpenseType': ExpenseType,
                'ExpenseDescr': ExpenseDescr,
                'Flag': Flag
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Expense-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Expense-Type";
    }
});

app.controller('SitesCtrl', function ($scope, $http, $filter, dataService) {

    $scope.Header = "Create Project";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.SiteID = '0';
        $scope.SiteName = '';
        $scope.SiteDescr = '';
        $scope.Flag = '';
        $scope.Incharge = '';
        $scope.StartDate = '';
        $scope.EndDate = '';
        $scope.SiteAddress = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';

    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.SoD = function ($event) {
        $scope.SDOD.opened = true;
    };

    $scope.EoD = function ($event) {
        $scope.EDOD.opened = true;
    };

    $scope.SDOD = {
        opened: false
    };

    $scope.EDOD = {
        opened: false
    };

    $scope.LoadInCharges = function () {
        $scope.incharge = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'InCharges';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.incharges = data;
               }
               else {
                   $scope.incharge = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadInCharges();

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Sites  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Sites",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.SiteName = Response[0]["SiteName"]
                   $scope.SiteDescr = Response[0]["SiteDescr"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 0 : 1
                   $scope.Incharge = Response[0]["Incharge"]
                   $scope.StartDate = Response[0]["StartDate"]
                   $scope.EndDate = Response[0]["EndDate"]
                   $scope.SiteAddress = Response[0]["SiteAddress"]
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {

        var SDop = new Date($scope.StartDate)
        $scope.SDate = $filter('date')(SDop, 'MM-dd-yyyy');

        if ($scope.EndDate != '') {
            var EDop = new Date($scope.EndDate)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Sites",
            params: {
                Action: "IN",
                SiteID: $scope.SiteID,
                SiteName: $scope.SiteName,
                SiteDescr: $scope.SiteDescr ? $scope.SiteDescr : '',
                Flag: $scope.Stat,
                Incharge: $scope.Incharge,
                StartDate: $scope.SDate,
                EndDate: $scope.EDate ? $scope.EDate : '',
                SiteAddress: $scope.SiteAddress ? $scope.SiteAddress : '',
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Project Code Should Be Unique");
               }
               else {
                   alertify.alert("Project Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {


        var SDop = new Date($scope.StartDate)
        if (SDop == "Invalid Date") {
            var partsDOB = $scope.StartDate.split('/');
            $scope.Editday = partsDOB[0];
            $scope.Editmonth = partsDOB[1];
            $scope.Edityear = partsDOB[2];
            var Emonth = $scope.Editmonth;
            var Eday = $scope.Editday;
            var Eyear = $scope.Edityear;
            $scope.SDate = Emonth + '-' + Eday + '-' + Eyear
        }
        else {
            $scope.SDate = $filter('date')(SDop, 'MM-dd-yyyy');
        }



        if ($scope.EndDate != '' && $scope.EndDate != null) {
            var EDop = new Date($scope.EndDate)

            if (EDop == "Invalid Date") {
                var partsDOB = $scope.EndDate.split('/');
                $scope.Editday = partsDOB[0];
                $scope.Editmonth = partsDOB[1];
                $scope.Edityear = partsDOB[2];
                var Emonth = $scope.Editmonth;
                var Eday = $scope.Editday;
                var Eyear = $scope.Edityear;
                $scope.EDate = Emonth + '-' + Eday + '-' + Eyear
            }
            else {
                $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
            }

        }

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Sites",
            params: {
                Action: "Up",
                SiteID: $scope.SiteID,
                SiteName: $scope.SiteName,
                SiteDescr: $scope.SiteDescr ? $scope.SiteDescr : '',
                Flag: $scope.Stat,
                Incharge: $scope.Incharge,
                StartDate: $scope.SDate,
                EndDate: $scope.EDate ? $scope.EDate : '',
                SiteAddress: $scope.SiteAddress ? $scope.SiteAddress : '',
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Project Updated Successfully");
                   window.location.href = "#/Project-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Project-Report";
    }
});

app.controller("Sites_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Status = 'Active';
    $scope.Header = "Project Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Sites",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Project";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'SiteID': SiteID,
                'SiteName': SiteName,
                'SiteDescr': SiteDescr,
                'Flag': Flag,
                'Incharge': Incharge,
                'StartDate': StartDate,
                'EndDate': EndDate,
                'SiteAddress': SiteAddress,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Project-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Sites";
    }
});


app.controller("Daily_Labour_MissCtrl", ['$scope', '$http', '$filter', 'dataService', 'fileUpload', function ($scope, $http, $filter, dataService, fileUpload) {
    $scope.Header = "Daily Expendes";
    $scope.ID = '0'
    $scope.NoofLabours = '0'
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '';
        $scope.ExpenseTypeID = '';
        $scope.SiteID = '';
        $scope.NoofLabours = '';
        $scope.Reason = '';
        $scope.Amount = '';
        $scope.Dated = '';
        $scope.Comments = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.FileName = '';
        $scope.Flag = '';
        $scope.myFile = ''

    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.DoD = function ($event) {
        $scope.ODOD.opened = true;
    };

    $scope.ODOD = {
        opened: false
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    $scope.ChangeExpanseType = function () {
        if ($scope.ExpenseTypeID == 3) {
            $scope.showhideNoofLabours = true
            $scope.NoofLabours = ""
            $scope.reqnooflabours = true
        }
        else {
            $scope.showhideNoofLabours = false
            $scope.NoofLabours = ""
            $scope.reqnooflabours = false
        }
    }
    $scope.LoadExpenseTypes = function () {
        $scope.ExpenseTypeID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'DailyExpenseTypes';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.ExpenseTypes = data;
               }
               else {
                   $scope.ExpenseTypeID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadExpenseTypes();

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Daily_Labour_Miss  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Daily_Labour_Miss",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.ExpenseTypeID = Response[0]["ExpenseTypeID"]
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.NoofLabours = Response[0]["NoofLabours"]
                   $scope.Reason = Response[0]["Reason"]
                   $scope.Amount = Response[0]["Amount"]
                   $scope.Dated = Response[0]["Date"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.FileName = Response[0]["FileName"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0

               });
    }
    else {

    }

    $scope.Insert_Main = function (filename) {
        $scope.FileName = filename
        if ($scope.Dated != '') {
            var EDop = new Date($scope.Dated)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Daily_Labour_Miss",
            params: {
                Action: "IN",
                ID: $scope.ID,
                ExpenseTypeID: $scope.ExpenseTypeID.toString(),
                SiteID: $scope.SiteID.toString(),
                NoofLabours: $scope.NoofLabours ? $scope.NoofLabours : '0',
                Reason: $scope.Reason,
                Amount: $scope.Amount.toString(),
                Date: $scope.EDate,
                Comments: $scope.Comments ? $scope.Comments : '',
                CreatedBy: sessionStorage.getItem("Uid"),
                FileName: $scope.FileName,
                Flag: $scope.Stat
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Daily_Labour_Miss Should Be Unique");
               }
               else {
                   alertify.alert("Daily_Labour_Miss Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Insert_Pro = function () {

        var file = $scope.myFile;
        if (file != 'undefined') {

            var uploadUrl = "../api/UploadFile/UploadDailyExpenses";
            var fd = new FormData();
            fd.append('file', file);
            $http.post(uploadUrl, fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (filename) {
                $scope.Insert_Main(filename);
            })
            .error(function () {
                alert('Error')
            });
        }
        else {
            $scope.Insert_Main('');
        }

    };

    $scope.Update_Pro = function () {

        $scope.FileName = ''
        var EDop = new Date($scope.Dated)

        if (EDop == "Invalid Date") {
            var partsDOB = $scope.Dated.split('/');
            $scope.Editday = partsDOB[0];
            $scope.Editmonth = partsDOB[1];
            $scope.Edityear = partsDOB[2];
            var Emonth = $scope.Editmonth;
            var Eday = $scope.Editday;
            var Eyear = $scope.Edityear;
            $scope.EDate = Emonth + '-' + Eday + '-' + Eyear
        }
        else {

            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Daily_Labour_Miss",
            params: {
                Action: "Up",
                ID: $scope.ID,
                ExpenseTypeID: $scope.ExpenseTypeID,
                SiteID: $scope.SiteID,
                NoofLabours: $scope.NoofLabours ? $scope.NoofLabours : '0',
                Reason: $scope.Reason,
                Amount: $scope.Amount,
                Date: $scope.EDate,
                Comments: $scope.Comments ? $scope.Comments : '',
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                FileName: $scope.FileName,
                Flag: $scope.Stat
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Daily Expanses Updated Successfully");

               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Daily-Expense-Rpt";
    }
}]);

app.controller("Daily_Labour_Miss_RptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Daily Expenses";
    $scope.IsAdmin = sessionStorage.getItem("IsAdmin");

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_Daily_Labour_MissRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();

    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Daily-Expenses";
    }

    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.Date,
                'ExpenseType': item.ExpenseType,
                'SiteName': item.SiteName,
                'NoofLabours': item.NoofLabours,
                'Reason': item.Reason,
                'Amount': item.Amount,
                'Comments': item.Comments
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Daily_Labour_Miss-Report-" + GetCurrDate() + ".xls");
        };
    };
    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_Daily_Labour_Miss",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }

    $scope.ViewFile = function (finename) {
        $scope.ImagePath = '../DailyExpenses/' + finename;
        $('#DisModal').modal('show');
    };

});

//app.controller('DailyPurchaseCtrl', function ($scope, $http, $filter, dataService) {
app.controller("DailyPurchaseCtrl", ['$scope', '$http', '$filter', 'dataService', 'fileUpload', function ($scope, $http, $filter, dataService, fileUpload) {

    $scope.Header = "Daily Purchase";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '0';
        $scope.SiteID = '';
        $scope.ItemID = '';
        $scope.InvoiceNo = '';
        $scope.Amount = '';
        $scope.Dated = '';
        $scope.Comments = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.FileName = '';
        $scope.ItemType = '';
        $scope.myFile = ''
    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.DoD = function ($event) {
        $scope.ODOD.opened = true;
    };

    $scope.ODOD = {
        opened: false
    };


    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    $scope.LoadItemTypes = function () {
        $scope.Type = "";
        $scope.ItemType = '';
        $scope.ItemName = "";

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'ItemTypes';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.ItemTypes = data;
               }
               else {
                   $scope.ItemType = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadItemTypes();
    $scope.GetItemNames = function () {
        $scope.ItemName = "";
        if (isUndefinedOrNull($scope.ItemType) != "") {
            $scope.GETCATEParams = {};
            $scope.GETCATEParams.Action = 'GetItemName';
            $scope.GETCATEParams.Condition = $scope.ItemType;
            $scope.GETCATEParams.ItemID = 0;

            var reqSubCategory = {
                method: 'POST',
                url: "../api/Site/Dropdown",
                data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
            };
            $http(reqSubCategory)
               .success(function (data) {
                   $scope.ItemNames = data
               })
        }
        else {
            $scope.ItemName = "";
        }
    };

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit DailyPurchase  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        $scope.LoadItemTypes();
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_DailyPurchase",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.ItemType = Response[0]["ItemType"]
                   $scope.GetItemNames()
                   $scope.ItemType = Response[0]["ItemType"]
                   $scope.InvoiceNo = Response[0]["InvoiceNo"]
                   $scope.Amount = Response[0]["Amount"]
                   $scope.Dated = Response[0]["Date"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.FileName = Response[0]["FileName"]
                   $scope.ItemID = Response[0]["ItemID"]
               });
    }
    else {

    }

    $scope.Insert_Pro = function () {

        var file = $scope.myFile;
        if (file != 'undefined') {

            var uploadUrl = "../api/UploadFile/UploadDailyPurchase";
            var fd = new FormData();
            fd.append('file', file);
            $http.post(uploadUrl, fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (filename) {
                $scope.Insert_Main(filename);
            })
            .error(function () {
                alert('Error')
            });
        }
        else {
            $scope.Insert_Main('');
        }

    };


    $scope.Insert_Main = function (filename) {

        $scope.FileName = filename
        if ($scope.Dated != '') {
            var EDop = new Date($scope.Dated)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_DailyPurchase",
            params: {
                Action: "IN",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                ItemID: $scope.ItemID,
                InvoiceNo: $scope.InvoiceNo,
                Amount: $scope.Amount,
                Date: $scope.EDate,
                Comments: $scope.Comments,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                FileName: $scope.FileName
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Daily Purchase Should Be Unique");
               }
               else {
                   alertify.alert("Daily Purchase Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var EDop = new Date($scope.Dated)

        if (EDop == "Invalid Date") {
            var partsDOB = $scope.Dated.split('/');
            $scope.Editday = partsDOB[0];
            $scope.Editmonth = partsDOB[1];
            $scope.Edityear = partsDOB[2];
            var Emonth = $scope.Editmonth;
            var Eday = $scope.Editday;
            var Eyear = $scope.Edityear;
            $scope.EDate = Emonth + '-' + Eday + '-' + Eyear
        }
        else {
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        $scope.FileName = ''
        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_DailyPurchase",
            params: {
                Action: "Up",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                ItemID: $scope.ItemID,
                InvoiceNo: $scope.InvoiceNo,
                Amount: $scope.Amount,
                Date: $scope.EDate,
                Comments: $scope.Comments ? $scope.Comments : '',
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                FileName: $scope.FileName
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Daily Purchase Updated Successfully");

               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/DailyPurchase-Report";
    }
}]);

app.controller("DailyPurchase_RptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Daily Purchase";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_DailyPurchaseRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();
    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Daily-Purchases";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.Date,
                'SiteName': item.SiteName,
                'ItemType': item.ItemType,
                'InvoiceNo': item.InvoiceNo,
                'ItemName': item.ItemName,
                'Amount': item.Amount,
                'Comments': item.Comments,
                'FileName': item.FileName,
                'CreatedByName': item.CreatedByName
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Daily_Labour_Miss-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_DailyPurchase",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }

    $scope.ViewFile = function (finename) {
        $scope.ImagePath = '../DailyPurchase/' + finename;
        $('#DisModal').modal('show');
    };
});

app.controller('Labour_PaymentsCtrl', function ($scope, $http, $filter, dataService) {

    $scope.Header = "Labour Payments";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '';
        $scope.SiteID = '';
        $scope.EmpID = '';
        $scope.PaymentFor = '';
        $scope.Amount = '';
        $scope.Comments = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.Dated = ''

    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.DoD = function ($event) {
        $scope.ODOD.opened = true;
    };

    $scope.ODOD = {
        opened: false
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();


    $scope.Loademployees = function () {
        $scope.EmpID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Users';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.employees = data;
               }
               else {
                   $scope.EmpID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.Loademployees();

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Labour Payments  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Labour_Payments",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.EmpID = Response[0]["EmpID"]
                   $scope.PaymentFor = Response[0]["PaymentFor"]
                   $scope.Amount = Response[0]["Amount"]
                   $scope.Dated = Response[0]["Dated"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {


        $scope.FileName = ''
        if ($scope.Dated != '') {
            var EDop = new Date($scope.Dated)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Labour_Payments",
            params: {
                Action: "IN",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                EmpID: $scope.EmpID,
                PaymentFor: $scope.PaymentFor,
                Amount: $scope.Amount,
                Comments: $scope.Comments ? $scope.Comments : '',
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                Dated: $scope.EDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Labour Payments Should Be Unique");
               }
               else {
                   alertify.alert("Labour Payments Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var EDop = new Date($scope.Dated)

        if (EDop == "Invalid Date") {
            var partsDOB = $scope.Dated.split('/');
            $scope.Editday = partsDOB[0];
            $scope.Editmonth = partsDOB[1];
            $scope.Edityear = partsDOB[2];
            var Emonth = $scope.Editmonth;
            var Eday = $scope.Editday;
            var Eyear = $scope.Edityear;
            $scope.EDate = Emonth + '-' + Eday + '-' + Eyear
        }
        else {
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Labour_Payments",
            params: {
                Action: "Up",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                EmpID: $scope.EmpID,
                PaymentFor: $scope.PaymentFor,
                Amount: $scope.Amount,
                Comments: $scope.Comments ? $scope.Comments : '',
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                Dated: $scope.EDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Labour Payments Updated Successfully");

               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Labour_Payments-Report";
    }
});

app.controller("Get_Labour_PaymentsRptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Labour Payemts";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_Labour_PaymentsRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();
    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Labour-Payments";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.Dated,
                'SiteName': item.SiteName,
                'EmpName': item.EmpName,
                'PaymentFor': item.PaymentFor,
                'Amount': item.Amount,
                'Comments': item.Comments,
                'CreatedByName': item.CreatedByName
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "LabourPayments-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_Labour_Payments",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }
});

app.controller('Req_MoneyCtrl', function ($scope, $http, $filter, dataService) {

    $scope.Header = "Request Money";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '';
        $scope.SiteID = '';
        $scope.ExpenseType = '';
        $scope.Amount = '';
        $scope.Comments = '';
        $scope.IsApproved = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.ApprovedBy = '';
        $scope.ApprovedDate = '';

    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.DoD = function ($event) {
        $scope.ODOD.opened = true;
    };

    $scope.ODOD = {
        opened: false
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    $scope.LoadExpenseTypes = function () {
        $scope.ExpenseTypeID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'DailyExpenseTypes';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.ExpenseTypes = data;
               }
               else {
                   $scope.ExpenseTypeID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadExpenseTypes();

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Req_Money  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Req_Money",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.ExpenseType = Response[0]["ExpenseType"]
                   $scope.Amount = Response[0]["Amount"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.IsApproved = Response[0]["IsApproved"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.ApprovedBy = Response[0]["ApprovedBy"]
                   $scope.ApprovedDate = Response[0]["ApprovedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {


        $scope.FileName = ''
        if ($scope.Dated != '') {
            var EDop = new Date($scope.Dated)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Req_Money",
            params: {
                Action: "IN",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                ExpenseType: $scope.ExpenseType,
                Amount: $scope.Amount,
                Comments: $scope.Comments,
                IsApproved: $scope.IsApproved,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                ApprovedBy: $scope.ApprovedBy,
                ApprovedDate: $scope.ApprovedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Req_Money Should Be Unique");
               }
               else {
                   alertify.alert("Req_Money Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Req_Money",
            params: {
                Action: "Up",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                ExpenseType: $scope.ExpenseType,
                Amount: $scope.Amount,
                Comments: $scope.Comments ? $scope.Comments : '',
                IsApproved: $scope.IsApproved,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                ApprovedBy: sessionStorage.getItem("Uid"),
                ApprovedDate: $scope.ApprovedDate ? $scope.ApprovedDate : ''
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Request Money Updated Successfully");

               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Req_Money-Report";
    }
});

app.controller("Get_Req_MoneyRptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Request Money";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_Req_MoneyRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();
    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Request-Money";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.CreatedDate,
                'SiteName': item.SiteName,
                'Expense_Type': item.Expense_Type,
                'Amount': item.Amount,
                'Comments': item.Comments,
                'CreatedByName': item.CreatedByName,
                'ApprovedStatus': item.ApprovedStatus
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "RequestMoney-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_Req_Money",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }


});

//app.controller('Site_ProgressCtrl', function ($scope, $http, $filter, dataService) {
app.controller("Site_ProgressCtrl", ['$scope', '$http', '$filter', 'dataService', 'fileUpload', function ($scope, $http, $filter, dataService, fileUpload) {
    $scope.Header = "Site Progress";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '';
        $scope.SiteID = '';
        $scope.Perm_Labours = '';
        $scope.Cont_Labours = '';
        $scope.Daily_Labours = '';
        $scope.Comments = '';
        $scope.FileName = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.Dated = '';
        $scope.myFile = ''
    }
    $scope.ClearAll();

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.DoD = function ($event) {
        $scope.ODOD.opened = true;
    };

    $scope.ODOD = {
        opened: false
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Site_Progress  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Site_Progress",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.SiteID = Response[0]["SiteID"]
                   $scope.Perm_Labours = Response[0]["Perm_Labours"]
                   $scope.Cont_Labours = Response[0]["Cont_Labours"]
                   $scope.Daily_Labours = Response[0]["Daily_Labours"]
                   $scope.Dated = Response[0]["Dated"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.FileName = Response[0]["FileName"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {

        var file = $scope.myFile;
        if (file != 'undefined') {

            var uploadUrl = "../api/UploadFile/UploadSiteProgress";
            var fd = new FormData();
            fd.append('file', file);
            $http.post(uploadUrl, fd, {
                transformRequest: angular.identity,
                headers: { 'Content-Type': undefined }
            })
            .success(function (filename) {
                $scope.Insert_Main(filename);
            })
            .error(function () {
                alert('Error')
            });
        }
        else {
            $scope.Insert_Main('');
        }

    };
    $scope.Insert_Main = function (filename) {


        $scope.FileName = filename
        if ($scope.Dated != '') {
            var EDop = new Date($scope.Dated)
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }

        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Site_Progress",
            params: {
                Action: "IN",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                Perm_Labours: $scope.Perm_Labours,
                Cont_Labours: $scope.Cont_Labours,
                Daily_Labours: $scope.Daily_Labours,
                Comments: $scope.Comments,
                FileName: $scope.FileName,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                Dated: $scope.EDate,
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Site_Progress Should Be Unique");
               }
               else {
                   alertify.alert("Site_Progress Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var EDop = new Date($scope.Dated)

        if (EDop == "Invalid Date") {
            var partsDOB = $scope.Dated.split('/');
            $scope.Editday = partsDOB[0];
            $scope.Editmonth = partsDOB[1];
            $scope.Edityear = partsDOB[2];
            var Emonth = $scope.Editmonth;
            var Eday = $scope.Editday;
            var Eyear = $scope.Edityear;
            $scope.EDate = Emonth + '-' + Eday + '-' + Eyear
        }
        else {
            $scope.EDate = $filter('date')(EDop, 'MM-dd-yyyy');
        }
        $scope.FileName = ''
        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Site_Progress",
            params: {
                Action: "Up",
                ID: $scope.ID,
                SiteID: $scope.SiteID,
                Perm_Labours: $scope.Perm_Labours,
                Cont_Labours: $scope.Cont_Labours,
                Daily_Labours: $scope.Daily_Labours,
                Comments: $scope.Comments ? $scope.Comments : '',
                FileName: $scope.FileName,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                Dated: $scope.EDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Site Progress Updated Successfully");

               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Site_Progress-Report";
    }
}]);

app.controller("Get_Site_ProgressRptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Site Progress";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_Site_ProgressRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();
    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Site-Progress";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.Dated,
                'SiteName': item.SiteName,
                'Perm_Labours': item.Perm_Labours,
                'Cont_Labours': item.Cont_Labours,
                'Daily_Labours': item.Daily_Labours,
                'Comments': item.Comments,
                'CreatedByName': item.CreatedByName
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "RequestMoney-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_Site_Progress",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }

    $scope.ViewFile = function (finename) {
        $scope.ImagePath = '../SiteProgress/' + finename;
        $('#DisModal').modal('show');
    };
});

app.controller("Get_Site_Progress_ImageRptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Site Progress By Images";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_Site_ProgressRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             var Images = '';
             document.getElementById('divImages').innerHTML = '';
             $scope.ReportList = Response.filter(function (element) { return element.SiteID == $scope.SiteID; });
             angular.forEach($scope.ReportList, function (list) {

                 Images = Images + "<div class='col-md-4'>";
                 Images = Images + "<div class='caption'>";
                 Images = Images + "<p>" + list.Dated + "</p>";
                 Images = Images + "</div>";
                 Images = Images + "<div style='width:250px;height:150px' class='thumbnail'>";
                 Images = Images + "<a href='../SiteProgress/" + list.FileName + "'>";
                 Images = Images + "<img src='../SiteProgress/" + list.FileName + "' alt='Lights' style='width:100px'>";
                 Images = Images + "</a>";
                 Images = Images + "</div>";
                 Images = Images + "</div>";

             });
             var target = document.getElementById('divImages');
             angular.element(target).append(angular.element(Images));

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();


    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }

    $scope.ViewFile = function (finename) {
        $scope.ImagePath = '../SiteProgress/' + finename;
        $('#DisModal').modal('show');
    };
});


app.controller("DashboardCtrl", function ($scope, $http, $filter, dataService) {

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.LoadSites = function () {
        $scope.SiteID = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Sites';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Sites = data;
               }
               else {
                   $scope.SiteID = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadSites();

    $scope.reqSitePogress = function () {

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_SitePogressRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {

             $scope.SitePogress = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqSiteExpenses = function () {

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_SiteExpensesRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.SiteExpenses = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqLabourPayments = function () {

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_LabourPaymentsRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.LabourPayments = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqPendingRequests = function () {

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_PendingRequestsRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.PendingRequests = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqSitePogressDay = function () {

        var maxdate = new Date()
        $scope.fromdate = $filter('date')(maxdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')(maxdate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_SitePogressRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {

             $scope.SitePogressDay = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqSiteExpensesDay = function () {
        var maxdate = new Date()
        $scope.fromdate = $filter('date')(maxdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')(maxdate, 'MM/dd/yyyy');
        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_SiteExpensesRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.SiteExpensesDay = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqLabourPaymentsDay = function () {
        var maxdate = new Date()
        $scope.fromdate = $filter('date')(maxdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')(maxdate, 'MM/dd/yyyy');

        var req_Report = {
            method: 'POST',
            url: "../api/Site/DB_LabourPaymentsRpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid"), SiteID: $scope.SiteID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.LabourPaymentsDay = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };

    $scope.reqDashboard = function () {
        $scope.reqSitePogress();
        $scope.reqSiteExpenses();
        $scope.reqLabourPayments();
        $scope.reqPendingRequests();

        $scope.reqSitePogressDay();
        $scope.reqSiteExpensesDay();
        $scope.reqLabourPaymentsDay();

    };
    $scope.reqDashboard();
});


app.controller('POCtrl', function ($scope, $http, $filter, dataService) {
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.SoD = function ($event) {
        $scope.SDOD.opened = true;
    };

    $scope.EoD = function ($event) {
        $scope.EDOD.opened = true;
    };

    $scope.SDOD = {
        opened: false
    };

    $scope.EDOD = {
        opened: false
    };

    $scope.LoadUnits = function () {
        $scope.Unit = '';

        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'GetUnits';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.Units = data;
               }
               else {
                   $scope.Units = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadUnits();

    $scope.LoadTermTypes = function () {
        $scope.Type = '';
        $scope.GETCATEParams = {};
        $scope.GETCATEParams.Action = 'Terms';
        $scope.GETCATEParams.Condition = '';
        $scope.GETCATEParams.ItemID = 0;

        var reqCat = {
            method: 'POST',
            url: "../api/Site/Dropdown",
            data: { Info: EncriptInfo(JSON.stringify($scope.GETCATEParams)) }
        };
        $http(reqCat)
           .success(function (data) {
               if (data != "") {
                   $scope.TermTypes = data;
               }
               else {
                   $scope.Type = "";
               }
           })
        .error(function (data, status, headers, config) {
        });

    }
    $scope.LoadTermTypes();

    $scope.SelectItemsList = [];
    $scope.AddItems = function () {

        if ($scope.Description != '' && $scope.Unit != '' && $scope.Qty != '' && $scope.Rate != '') {

            if ($scope.Qty > 0) {
                if ($scope.Rate > 0) {
                    $scope.addprdloader = true;
                    var sno = $scope.SelectItemsList.length + 1;
                    if ($scope.SelectItemsList.length >= 1) {
                        var chkItem = ''
                        angular.forEach($scope.SelectItemsList, function (list) {
                            if (list.Description == $scope.Description && list.Unit == $scope.Unit && list.Qty == $scope.Qty && list.Rate == $scope.Rate) {
                                chkItem = 'Added';
                            }
                        });
                        if (chkItem == '') {
                            $scope.SelectItemsList.push({
                                $id: sno,
                                Description: $scope.Description,
                                Unit: $scope.Unit,
                                Qty: $scope.Qty,
                                Rate: $scope.Rate
                            });
                        }
                        else {
                            alertify.alert('Item Already Added.');
                        }


                    }
                    else {
                        $scope.SelectItemsList.push({
                            $id: sno,
                            Description: $scope.Description,
                            Unit: $scope.Unit,
                            Qty: $scope.Qty,
                            Rate: $scope.Rate
                        });

                    }

                    $scope.Addprds = true;
                    $scope.DivProducts = true;

                    
                    $scope.Description = '';
                    $scope.Unit = '';
                    $scope.Qty = '';
                    $scope.Rate = '';
                    $scope.addprdloader = false;
                }
                else {
                    $scope.txtQuantity = '';
                    alertify.alert('Rate should not be zero.');
                }
            }
            else {
                $scope.txtQuantity = '';
                alertify.alert('Quantity should not be zero.');
            }
        }
        else {
            alertify.alert('Select All Mandatoty Fields.');
        }
    };
    $scope.DeleteItem = function (tPO) {
        var index = $scope.SelectItemsList.indexOf(tPO);
        $scope.SelectItemsList.splice(index, 1);
        if ($scope.SelectItemsList.length >= 1) {
            $scope.Addprds = true;
            $scope.DivProducts = true;
        }
        else {
            $scope.Addprds = false;
        }
        alert('Item Deleted')
    };

    $scope.SelectTermsList = [];
    $scope.AddTerms = function () {

        if ($scope.Type != '' && $scope.TermDescription != '') {

            $scope.addprdloader = true;
                    var sno = $scope.SelectTermsList.length + 1;
                    if ($scope.SelectTermsList.length >= 1) {
                        var chkItem = ''
                        angular.forEach($scope.SelectTermsList, function (list) {
                            if (list.Type == $scope.Type && list.TermDescription == $scope.TermDescription) {
                                chkItem = 'Added';
                            }
                        });
                        if (chkItem == '') {
                            $scope.SelectTermsList.push({
                                $id: sno,
                                Type: $scope.Type,
                                TermDescription: $scope.TermDescription
                            });
                        }
                        else {
                            alertify.alert('This Terms & Conditions Already Added.');
                        }


                    }
                    else {
                        $scope.SelectTermsList.push({
                            $id: sno,
                            Type: $scope.Type,
                            TermDescription: $scope.TermDescription
                        });

                    }
                    $scope.Add_Terms = true;
                    $scope.addprdloader = false;
                    $scope.TermDescription = '';
                    $scope.Type = '';
        }
        else {
            alertify.alert('Select All Mandatoty Fields.');
        }
    };
    $scope.DeleteTerms = function (tPO) {
        var index = $scope.SelectTermsList.indexOf(tPO);
        $scope.SelectTermsList.splice(index, 1);
        if ($scope.SelectTermsList.length >= 1) {
            $scope.Add_Terms = true;
        }
        else {
            $scope.Add_Terms = false;
        }
        alert('Terms & Conditions Deleted')
    };


    

    $scope.ClearAll = function () {
        $scope.SelectItemsList = [];
        $scope.SelectTermsList = [];
        $scope.ID = '0';
        $scope.POID = '0';
        $scope.MainRef = '';
        $scope.Dated = '';
        $scope.Name = '';
        $scope.ShopNo = '';
        $scope.Area = '';
        $scope.City = '';
        $scope.State = '';
        $scope.PinCode = '';
        $scope.GSTINNO = '';
        $scope.Subject = '';
        $scope.RefNo = '';
        $scope.Comments = '';
        $scope.ExpectedDeliveryDate = '';
        $scope.MainContact = '';
        $scope.Mobile = '';
        $scope.EmailID = '';
        $scope.CreatedDate = '';
        $scope.CreatedBy = '0';
        $scope.UpdatedBy = '0';
        $scope.UpdatedDate = '';
        $scope.Con_Type = '';
        $scope.Con_Descr = '';
        $scope.Description = '';
        $scope.Unit = '';
        $scope.Qty = '';
        $scope.Rate = '';
        $scope.Comments = '';
        
    }
    $scope.ClearAll();

    $scope.ItemsConfirm = function () {

        $scope.isValidate = 'OK';

        if ($scope.SelectTermsList.length < 1) {
            $scope.isValidate = 'NO';
        }

        if ($scope.SelectTermsList.length < 1) {
            $scope.isValidate = 'NO';
        }

        if ($scope.isValidate == 'OK') {
            $scope.orderloader = true;

            var Dated1 = new Date($scope.Dated)
            $scope.Dated_ = $filter('date')(Dated1, 'MM-dd-yyyy');

            var ExpectedDeliveryDate1 = new Date($scope.ExpectedDeliveryDate)
            $scope.ExpectedDeliveryDate_ = $filter('date')(ExpectedDeliveryDate1, 'MM-dd-yyyy');

            var reqInsertPro = {
                method: 'POST',
                url: "../api/Site/Insert_Update_PO",
                params: {
                    Action: "IN",
                    POID: $scope.POID,
                    MainRef: $scope.MainRef,
                    Dated: $scope.Dated_,
                    Name: $scope.Name,
                    ShopNo: $scope.ShopNo,
                    Area: $scope.Area,
                    City: $scope.City,
                    State: $scope.State,
                    PinCode: $scope.PinCode,
                    GSTINNO: $scope.GSTINNO,
                    Subject: $scope.Subject,
                    RefNo: $scope.RefNo,
                    Comments: $scope.Comments,
                    ExpectedDeliveryDate: $scope.ExpectedDeliveryDate_,
                    MainContact: $scope.MainContact,
                    Mobile: $scope.Mobile,
                    EmailID: $scope.EmailID,
                    CreatedDate: $scope.CreatedDate,
                    CreatedBy: sessionStorage.getItem("Uid"),
                    UpdatedBy: $scope.UpdatedBy,
                    UpdatedDate: $scope.UpdatedDate,
                    Status: $scope.Status,
                    Flag: $scope.Stat
                }
            };
            $http(reqInsertPro)
               .success(function (Response) {
                   if (Response[0]["cnt"] == -1) {
                       alertify.alert("PO Should Be Unique");
                   }
                   else {
                       $scope.POID = Response[0]["cnt"];
                       angular.forEach($scope.SelectItemsList, function (list) {
                           var reqInsertPro = {
                               method: 'POST',
                               url: "../api/Site/Insert_Update_PO_Items",
                               params: {
                                   Action: "IN",
                                   POID: $scope.POID,
                                   Description: list.Description,
                                   Unit: list.Unit,
                                   Qty: list.Qty,
                                   Rate: list.Rate,
                                   Comments: '',
                                   ID: $scope.ID,
                                   Flag: $scope.Stat
                               }
                           };
                           $http(reqInsertPro)
                              .success(function (Response) {
                                  
                              })
                              .error(function (Message) {
                                  alertify.alert(Message.Message);
                              });
                       });

                       angular.forEach($scope.SelectTermsList, function (list) {
                           var reqInsertPro = {
                               method: 'POST',
                               url: "../api/Site/Insert_Update_PO_Term_Conditions",
                               params: {
                                   Action: "IN",
                                   POID : $scope.POID,
                                   Con_Type: list.Type,
                                   Con_Descr: list.TermDescription,
                                   ID : $scope.ID,
                                   Flag : $scope.Stat
                               }
                           };
                           $http(reqInsertPro)
                              .success(function (Response) {
                                      alertify.alert("PO Created");
                                      $scope.ClearAll();      
                              })
                              .error(function (Message) {
                                  alertify.alert(Message.Message);
                              });
                       });
                   }

               })
               .error(function (Message) {
                   alertify.alert(Message.Message);
               });
        }
        else {
            alertify.alert('Select All Mandatoty Fields.');
        }
    };

});

app.controller("PORptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.POID = '';
    $scope.Header = "PO Reports";

    $scope.ItemsperPage = 10;
    $scope.currentPage = 1;

    $scope.minDate = '01/01/2015';
    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    $scope.frommaxDate = $filter('date')(maxdate, 'MM/dd/yyyy');
    var fromdate = new Date()
    var From = fromdate.setMonth(fromdate.getMonth() - 1);

    $scope.fromtoRequired = true;
    $scope.openfromdatests = function ($event) {
        $scope.fromdatests.opened = true;
    };
    $scope.fromdatests = {
        opened: false
    };
    $scope.opentodatests = function ($event) {
        $scope.todatests.opened = true;
    };
    $scope.todatests = {
        opened: false
    };
    $scope.Assignfrommaxdate = function () {
        $scope.frommaxDate = $scope.txtTodate;
    };
    $scope.Assignfrommaxdate1 = function () {
        var mn = new Date($scope.txtFromdate)
        $scope.minDate1 = $filter('date')(mn, 'MM/dd/yyyy');
    };

    $scope.reqReport = function () {


        $scope.RptHeader = "Report - Between " + $filter('date')($scope.txtFromdate, 'dd MMM yyyy') + ' and ' + $filter('date')($scope.txtTodate, 'dd MMM yyyy')

        $scope.fromdate = $filter('date')($scope.txtFromdate, 'MM/dd/yyyy');
        $scope.todate = $filter('date')($scope.txtTodate, 'MM/dd/yyyy');
        
        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_PORpt",
            params: { fromdate: $scope.fromdate ? $scope.fromdate : '', todate: $scope.todate ? $scope.todate : '', EmpID: sessionStorage.getItem("Uid") }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;

         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.reqReport();
    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Labour-Payments";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {

            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'Dated': item.Dated,
                'SiteName': item.SiteName,
                'EmpName': item.EmpName,
                'PaymentFor': item.PaymentFor,
                'Amount': item.Amount,
                'Comments': item.Comments,
                'CreatedByName': item.CreatedByName
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "LabourPayments-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Delete = function (Sid) {
        $scope.DeleteRecordId = Sid;
        $scope.Model = true;
    }

    $scope.SDeleteConf = function () {
        if (!$scope.DeleteRecordId) { return; }
        $scope.DeleteRecordId;
        var reqStates = {
            method: 'GET',
            url: "../api/Site/Get_Labour_Payments",
            params: { ID: $scope.DeleteRecordId, Action: 'Delete', DeletedBy: sessionStorage.getItem("Uid") }
        };
        $http(reqStates)
           .success(function (Response) {
               if (Response[0]["result"] == "Deleted") {
                   alertify.alert("Record Deleted");
                   $("#myModal").modal('hide');
                   $scope.reqReport();
               }
           });
    }

    $scope.Cancel = function () {
        $("#myModal").modal('hide');
    }

    $scope.generate_PDF = function (Sid) {
        dataService.POID = Sid;
        window.location.href = "#/POPDF";
    };
       
});

app.controller('POPDFCtrl', function ($scope, $http, dataService) {

  
    
    
    $scope.reqReport = function (POID) {
        
        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_PORptByID",
            params: { POID: POID }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.ReportList = Response;
             $scope.MainRef = Response["MainRef"];
             $scope.Dated = Response["Dated"];
             $scope.Name = Response["Name"];
             $scope.ShopNo = Response["ShopNo"];
             $scope.Area = Response["Area"];
             $scope.State = Response["State"];
             $scope.GSTINNO = Response["GSTINNO"];
             $scope.Subject = Response["Subject"];
             $scope.RefNo = Response["RefNo"];
             $scope.Comments = Response["Comments"];
             
             $scope.FillPOItems(POID);
             $scope.FillPOConditions(POID);
         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    
    $scope.FillPOItems = function (POID) {
        
        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_PO_Items",
            params: { ID: POID, Action: 'Get', DeletedBy: 0 }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.poItems = Response;
         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.FillPOConditions = function (POID) {
        
        var req_Report = {
            method: 'GET',
            url: "../api/Site/Get_PO_Term_Conditions",
            params: { ID: POID, Action: 'Get', DeletedBy: 0 }
        };
        $http(req_Report)
         .success(function (Response) {
             $scope.poIermCondi = Response;
         })
        .error(function (Message) {
            $scope.loader = false;
            alertify.alert(Message.Message);
        });
    };
    $scope.generatePDF = function () {
        
        kendo.drawing.drawDOM($("#div_print")).then(function (group) {
            kendo.drawing.pdf.saveAs(group, "sadasdas.pdf");
        });
    };
    if (isUndefinedOrNull(dataService.POID) != '') {
        $scope.reqReport(dataService.POID);
    };
    $scope.Back = function () {
        window.location.href = "#/Purchase-Order-Rpt";
    };
});



app.controller("Bankers_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Header = "Bankers Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Bankers",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Bankers";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'IFSCCODE': IFSCCODE,
                'Designation': Designation,
                'BankName': BankName,
                'BranchName': BranchName,
                'Flag': Flag,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Bankers-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Bankers";
    }
});
app.controller('BankersCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Bankers";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.IFSCCODE = '';
        $scope.Designation = '';
        $scope.BankName = '';
        $scope.BranchName = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Bankers  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Bankers",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.IFSCCODE = Response[0]["IFSCCODE"]
                   $scope.Designation = Response[0]["Designation"]
                   $scope.BankName = Response[0]["BankName"]
                   $scope.BranchName = Response[0]["BranchName"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Bankers",
            params: {
                Action: "IN",
                IFSCCODE: $scope.IFSCCODE,
                Designation: $scope.Designation,
                BankName: $scope.BankName,
                BranchName: $scope.BranchName,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Bankers Should Be Unique");
               }
               else {
                   alertify.alert("Bankers Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Bankers",
            params: {
                Action: "Up",
                IFSCCODE: $scope.IFSCCODE,
                Designation: $scope.Designation,
                BankName: $scope.BankName,
                BranchName: $scope.BranchName,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Bankers Updated Successfully");
                   window.location.href = "#/Bankers-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Bankers-Report";
    }
});


app.controller("Customers_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Header = "Customers Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Customers",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Customers";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'CustCode': CustCode,
                'CustDesignation': CustDesignation,
                'Unit': Unit,
                'CustName': CustName,
                'StreetNo': StreetNo,
                'Area': Area,
                'City': City,
                'State': State,
                'PhoneNo': PhoneNo,
                'EmailID': EmailID,
                'Flag': Flag,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate,
                'UpdatedBy': UpdatedBy,
                'UpdatedDate': UpdatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Customers-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Customers";
    }
});
app.controller('CustomersCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Customers";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.CustCode = '';
        $scope.CustDesignation = '';
        $scope.Unit = '';
        $scope.CustName = '';
        $scope.StreetNo = '';
        $scope.Area = '';
        $scope.City = '';
        $scope.State = '';
        $scope.PhoneNo = '';
        $scope.EmailID = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.UpdatedBy = '';
        $scope.UpdatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Customers  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Customers",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.CustCode = Response[0]["CustCode"]
                   $scope.CustDesignation = Response[0]["CustDesignation"]
                   $scope.Unit = Response[0]["Unit"]
                   $scope.CustName = Response[0]["CustName"]
                   $scope.StreetNo = Response[0]["StreetNo"]
                   $scope.Area = Response[0]["Area"]
                   $scope.City = Response[0]["City"]
                   $scope.State = Response[0]["State"]
                   $scope.PhoneNo = Response[0]["PhoneNo"]
                   $scope.EmailID = Response[0]["EmailID"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.UpdatedBy = Response[0]["UpdatedBy"]
                   $scope.UpdatedDate = Response[0]["UpdatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Customers",
            params: {
                Action: "IN",
                CustCode: $scope.CustCode,
                CustDesignation: $scope.CustDesignation,
                Unit: $scope.Unit,
                CustName: $scope.CustName,
                StreetNo: $scope.StreetNo,
                Area: $scope.Area,
                City: $scope.City,
                State: $scope.State,
                PhoneNo: $scope.PhoneNo,
                EmailID: $scope.EmailID,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Customers Should Be Unique");
               }
               else {
                   alertify.alert("Customers Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Customers",
            params: {
                Action: "Up",
                CustCode: $scope.CustCode,
                CustDesignation: $scope.CustDesignation,
                Unit: $scope.Unit,
                CustName: $scope.CustName,
                StreetNo: $scope.StreetNo,
                Area: $scope.Area,
                City: $scope.City,
                State: $scope.State,
                PhoneNo: $scope.PhoneNo,
                EmailID: $scope.EmailID,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Customers Updated Successfully");
                   window.location.href = "#/Customers-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Customers-Report";
    }
});



app.controller("Import_Items_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Header = "Import_Items Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Import_Items",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Import_Items";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'ID': ID,
                'ProjectCode': ProjectCode,
                'ScheduleNo': ScheduleNo,
                'SLNO': SLNO,
                'ItemDesc': ItemDesc,
                'ItemUnit': ItemUnit,
                'Qty': Qty,
                'Rate': Rate,
                'Amount': Amount,
                'Flag': Flag,
                'POStatus': POStatus,
                'DCStatus': DCStatus,
                'VendorCode': VendorCode,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate,
                'UpdatedBy': UpdatedBy,
                'UpdatedDate': UpdatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Import_Items-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Import_Items";
    }
});
app.controller('Import_ItemsCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Import_Items";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ID = '';
        $scope.ProjectCode = '';
        $scope.ScheduleNo = '';
        $scope.SLNO = '';
        $scope.ItemDesc = '';
        $scope.ItemUnit = '';
        $scope.Qty = '';
        $scope.Rate = '';
        $scope.Amount = '';
        $scope.Flag = '';
        $scope.POStatus = '';
        $scope.DCStatus = '';
        $scope.VendorCode = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.UpdatedBy = '';
        $scope.UpdatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Import_Items  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Import_Items",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ID = Response[0]["ID"]
                   $scope.ProjectCode = Response[0]["ProjectCode"]
                   $scope.ScheduleNo = Response[0]["ScheduleNo"]
                   $scope.SLNO = Response[0]["SLNO"]
                   $scope.ItemDesc = Response[0]["ItemDesc"]
                   $scope.ItemUnit = Response[0]["ItemUnit"]
                   $scope.Qty = Response[0]["Qty"]
                   $scope.Rate = Response[0]["Rate"]
                   $scope.Amount = Response[0]["Amount"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.POStatus = Response[0]["POStatus"]
                   $scope.DCStatus = Response[0]["DCStatus"]
                   $scope.VendorCode = Response[0]["VendorCode"]
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.UpdatedBy = Response[0]["UpdatedBy"]
                   $scope.UpdatedDate = Response[0]["UpdatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Import_Items",
            params: {
                Action: "IN",
                ID: $scope.ID,
                ProjectCode: $scope.ProjectCode,
                ScheduleNo: $scope.ScheduleNo,
                SLNO: $scope.SLNO,
                ItemDesc: $scope.ItemDesc,
                ItemUnit: $scope.ItemUnit,
                Qty: $scope.Qty,
                Rate: $scope.Rate,
                Amount: $scope.Amount,
                Flag: $scope.Stat,
                POStatus: $scope.POStatus,
                DCStatus: $scope.DCStatus,
                VendorCode: $scope.VendorCode,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Import_Items Should Be Unique");
               }
               else {
                   alertify.alert("Import_Items Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Import_Items",
            params: {
                Action: "Up",
                ID: $scope.ID,
                ProjectCode: $scope.ProjectCode,
                ScheduleNo: $scope.ScheduleNo,
                SLNO: $scope.SLNO,
                ItemDesc: $scope.ItemDesc,
                ItemUnit: $scope.ItemUnit,
                Qty: $scope.Qty,
                Rate: $scope.Rate,
                Amount: $scope.Amount,
                Flag: $scope.Stat,
                POStatus: $scope.POStatus,
                DCStatus: $scope.DCStatus,
                VendorCode: $scope.VendorCode,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Import_Items Updated Successfully");
                   window.location.href = "#/Import_Items-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Import_Items-Report";
    }
});

app.controller("Project_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Header = "Project Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Project",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Project";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'ProjectCode': ProjectCode,
                'ProjectName': ProjectName,
                'InCharge': InCharge,
                'StartDate': StartDate,
                'EndDate': EndDate,
                'Orderingauthority': Orderingauthority,
                'ExpectedEndDate': ExpectedEndDate,
                'ProjectCost': ProjectCost,
                'Flag': Flag,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate,
                'UpdatedBy': UpdatedBy,
                'UpdatedDate': UpdatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Project-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Project";
    }
});
app.controller('ProjectCtrl', function ($scope, $http, dataService) {

    var maxdate = new Date()
    $scope.maxDate = $filter('date')(maxdate, 'MM/dd/yyyy');

    $scope.SoD = function ($event) {
        $scope.SDOD.opened = true;
    };

    

    $scope.SDOD = {
        opened: false
    };

    $scope.EDOD = {
        opened: false
    };

    $scope.EoD = function ($event) {
        $scope.EDOD.opened = true;
    };

    $scope.EEDOD = {
        opened: false
    };

    $scope.EEoD = function ($event) {
        $scope.EEDOD.opened = true;
    };



    $scope.Header = "Create Project";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.ProjectCode = '';
        $scope.ProjectName = '';
        $scope.InCharge = '';
        $scope.StartDate = '';
        $scope.EndDate = '';
        $scope.Orderingauthority = '';
        $scope.ExpectedEndDate = '';
        $scope.ProjectCost = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.UpdatedBy = '';
        $scope.UpdatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Project  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Project",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.ProjectCode = Response[0]["ProjectCode"]
                   $scope.ProjectName = Response[0]["ProjectName"]
                   $scope.InCharge = Response[0]["InCharge"]
                   $scope.StartDate = Response[0]["StartDate"]
                   $scope.EndDate = Response[0]["EndDate"]
                   $scope.Orderingauthority = Response[0]["Orderingauthority"]
                   $scope.ExpectedEndDate = Response[0]["ExpectedEndDate"]
                   $scope.ProjectCost = Response[0]["ProjectCost"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.UpdatedBy = Response[0]["UpdatedBy"]
                   $scope.UpdatedDate = Response[0]["UpdatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Project",
            params: {
                Action: "IN",
                ProjectCode: $scope.ProjectCode,
                ProjectName: $scope.ProjectName,
                InCharge: $scope.InCharge,
                StartDate: $scope.StartDate,
                EndDate: $scope.EndDate,
                Orderingauthority: $scope.Orderingauthority,
                ExpectedEndDate: $scope.ExpectedEndDate,
                ProjectCost: $scope.ProjectCost,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Project Should Be Unique");
               }
               else {
                   alertify.alert("Project Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Project",
            params: {
                Action: "Up",
                ProjectCode: $scope.ProjectCode,
                ProjectName: $scope.ProjectName,
                InCharge: $scope.InCharge,
                StartDate: $scope.StartDate,
                EndDate: $scope.EndDate,
                Orderingauthority: $scope.Orderingauthority,
                ExpectedEndDate: $scope.ExpectedEndDate,
                ProjectCost: $scope.ProjectCost,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Project Updated Successfully");
                   window.location.href = "#/Project-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Project-Report";
    }
});

app.controller("Railways_RptCtrl", function ($scope, $http, $filter, dataService) {
    dataService.ID = "";
    $scope.Header = "Railways Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Railways",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Railways";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'RailwayCode': RailwayCode,
                'Area': Area,
                'City': City,
                'Comments': Comments,
                'Flag': Flag,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate,
                'UpdatedBy': UpdatedBy,
                'UpdatedDate': UpdatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Railways-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Railways";
    }
});
app.controller('RailwaysCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Railways";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.RailwayCode = '';
        $scope.Area = '';
        $scope.City = '';
        $scope.Comments = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.UpdatedBy = '';
        $scope.UpdatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Railways  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Railways",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.RailwayCode = Response[0]["RailwayCode"]
                   $scope.Area = Response[0]["Area"]
                   $scope.City = Response[0]["City"]
                   $scope.Comments = Response[0]["Comments"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.UpdatedBy = Response[0]["UpdatedBy"]
                   $scope.UpdatedDate = Response[0]["UpdatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Railways",
            params: {
                Action: "IN",
                RailwayCode: $scope.RailwayCode,
                Area: $scope.Area,
                City: $scope.City,
                Comments: $scope.Comments,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Railways Should Be Unique");
               }
               else {
                   alertify.alert("Railways Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Railways",
            params: {
                Action: "Up",
                RailwayCode: $scope.RailwayCode,
                Area: $scope.Area,
                City: $scope.City,
                Comments: $scope.Comments,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Railways Updated Successfully");
                   window.location.href = "#/Railways-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Railways-Report";
    }
});



app.controller("Vendors_RptCtrl", function ($scope, $http, dataService) {
    dataService.ID = "";
    $scope.Header = "Vendors Report";
    $scope.ItemsperPage = 10;
    $scope.loader = true;
    var reqReport = {
        method: 'GET',
        url: "../api/Site/Get_Vendors",
        params: { ID: 0, Action: 'ALL', DeletedBy: 0 }
    };
    $http(reqReport)
       .success(function (data) {
           $scope.ReportList = data;
           $scope.loader = false;
       });


    $scope.Edit = function (Sid) {
        dataService.ID = Sid;
        window.location.href = "#/Vendors";
    }
    $scope.exportToExcel = function () {

        $scope.TempRpt = [];
        var sno = 1;
        angular.forEach($scope.ReportList, function (item) {
            $scope.TempRpt.push({
                'Sno': sno,//item.$id,
                'VendorCode': VendorCode,
                'VendorName': VendorName,
                'ContactPersion': ContactPersion,
                'PhoneNo': PhoneNo,
                'StreetNo': StreetNo,
                'Area': Area,
                'City': City,
                'State': State,
                'Flag': Flag,
                'CreatedBy': CreatedBy,
                'CreatedDate': CreatedDate,
                'UpdatedBy': UpdatedBy,
                'UpdatedDate': UpdatedDate
            });
            sno = sno + 1;
        });
        if ($scope.TempRpt.length > 0) {

            var data = CreateTableView_Excel($scope.TempRpt, $scope.Header);
            var blob = new Blob([data], {
                type: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=utf-8"
            });
            saveAs(blob, "Vendors-Report-" + GetCurrDate() + ".xls");
        };
    };

    $scope.Add = function () {
        window.location.href = "#/Vendors";
    }
});
app.controller('VendorsCtrl', function ($scope, $http, dataService) {

    $scope.Header = "Create Vendors";
    $scope.ShowHideUpdate = false;
    $scope.ShowHideCreate = true;
    $scope.SHDropDown = false;
    $scope.readonly = false;
    $scope.Status = [{ Value: 0, Text: 'Active' }, { Value: 1, Text: 'InActive' }];
    $scope.Stat = 0;
    $scope.ClearAll = function () {
        $scope.VendorCode = '';
        $scope.VendorName = '';
        $scope.ContactPersion = '';
        $scope.PhoneNo = '';
        $scope.StreetNo = '';
        $scope.Area = '';
        $scope.City = '';
        $scope.State = '';
        $scope.Flag = '';
        $scope.CreatedBy = '';
        $scope.CreatedDate = '';
        $scope.UpdatedBy = '';
        $scope.UpdatedDate = '';

    }
    $scope.ClearAll();
    if (isUndefinedOrNull(dataService.ID) != '') {

        $scope.readonly = true;
        $scope.Header = "Edit Vendors  / " + dataService.ID;
        $scope.ShowHideUpdate = true;
        $scope.ShowHideCreate = false;
        $scope.SHDropDown = true;
        var reqEdit = {
            method: 'GET',
            url: "../api/Site/Get_Vendors",
            params: { ID: dataService.ID, Action: 'Edit', DeletedBy: 0 }
        };
        $http(reqEdit)
               .success(function (Response) {
                   $scope.VendorCode = Response[0]["VendorCode"]
                   $scope.VendorName = Response[0]["VendorName"]
                   $scope.ContactPersion = Response[0]["ContactPersion"]
                   $scope.PhoneNo = Response[0]["PhoneNo"]
                   $scope.StreetNo = Response[0]["StreetNo"]
                   $scope.Area = Response[0]["Area"]
                   $scope.City = Response[0]["City"]
                   $scope.State = Response[0]["State"]
                   $scope.Stat = Response[0]["Flag"] == 'Active' ? 1 : 0
                   $scope.CreatedBy = Response[0]["CreatedBy"]
                   $scope.CreatedDate = Response[0]["CreatedDate"]
                   $scope.UpdatedBy = Response[0]["UpdatedBy"]
                   $scope.UpdatedDate = Response[0]["UpdatedDate"]

               });
    }
    else {

    }

    $scope.Insert_Pro = function () {
        var reqInsertPro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Vendors",
            params: {
                Action: "IN",
                VendorCode: $scope.VendorCode,
                VendorName: $scope.VendorName,
                ContactPersion: $scope.ContactPersion,
                PhoneNo: $scope.PhoneNo,
                StreetNo: $scope.StreetNo,
                Area: $scope.Area,
                City: $scope.City,
                State: $scope.State,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqInsertPro)
           .success(function (Response) {
               if (Response[0]["cnt"] == -1) {
                   alertify.alert("Vendors Should Be Unique");
               }
               else {
                   alertify.alert("Vendors Created");
                   $scope.ClearAll();
               }

           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };

    $scope.Update_Pro = function () {

        var reqUpdatePro = {
            method: 'POST',
            url: "../api/Site/Insert_Update_Vendors",
            params: {
                Action: "Up",
                VendorCode: $scope.VendorCode,
                VendorName: $scope.VendorName,
                ContactPersion: $scope.ContactPersion,
                PhoneNo: $scope.PhoneNo,
                StreetNo: $scope.StreetNo,
                Area: $scope.Area,
                City: $scope.City,
                State: $scope.State,
                Flag: $scope.Stat,
                CreatedBy: sessionStorage.getItem("Uid"),
                CreatedDate: $scope.CreatedDate,
                UpdatedBy: $scope.UpdatedBy,
                UpdatedDate: $scope.UpdatedDate
            }
        };
        $http(reqUpdatePro)
           .success(function (Response) {
               if (Response[0]["cnt"] == 1) {
                   $scope.ClearAll();
                   alertify.alert("Vendors Updated Successfully");
                   window.location.href = "#/Vendors-Report";
               }
           })
           .error(function (Message) {
               alertify.alert(Message.Message);
           });
    };
    $scope.ShowReport = function () {
        window.location.href = "#/Vendors-Report";
    }
});

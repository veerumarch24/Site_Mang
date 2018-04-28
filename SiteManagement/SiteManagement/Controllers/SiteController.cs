
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.Linq;
using System.Text;

namespace SiteManagement.Controllers
{
    public class SiteController : FileUploadController
    {
        Admin admin = new Admin();
        Common _objCommon = new Common();
        public class Params
        {
            public string info { get; set; }
        }

        [System.Web.Mvc.HttpPost]
        public List<DropdownIP> Dropdown([FromBody]Params Info)
        {
            return _objCommon.Dropdown(Info.info);
        }

        [System.Web.Mvc.HttpGet]
        public List<Passwords_List> GetPasswords(string action)
        {
            return _objCommon.GetPasswords(action);
        }
        [System.Web.Mvc.HttpPost]
        public string PasswordsEncription(string action, string id, string pwd, string tpwd)
        {
            var newpwd = "";
            var newtpwd = "";
            var nri = new Random();
            var pwd1 = _objCommon.GetRandomString(nri, 2, "123456789");
            var pwd2 = _objCommon.GetRandomString(nri, 6, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            var pwd3 = _objCommon.GetRandomString(nri, 2, "123456789");
            newpwd = pwd1 + pwd2 + pwd3;

            var tpwd1 = _objCommon.GetRandomString(nri, 2, "123456789");
            var tpwd2 = _objCommon.GetRandomString(nri, 6, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
            var tpwd3 = _objCommon.GetRandomString(nri, 2, "123456789");
            newtpwd = tpwd1 + tpwd2 + tpwd3;

            return _objCommon.PasswordsEncription(action, id, newpwd, Util.Encrypt(newpwd), newtpwd, Util.Encrypt(newtpwd));
        }

        [System.Web.Mvc.HttpPost]
        public List<lastlogin> LastLogin([FromBody]Params Info)
        {
            return _objCommon.GetLastLogin(Info.info);
        }

        
        //[System.Web.Mvc.HttpPost]
        //public string Exist([FromBody]Params Info)
        //{
        //    return _objCommon.Exist(Info.info);
        //}
        [AcceptVerbs("POST")]
        [ActionName("GetValue")]
        public string GetValue([FromBody]Params Info)
        {
            return _objCommon.GetValue(Info.info);
        }

        [System.Web.Mvc.HttpGet]
        public string EncriptValues(string value)
        {
            return Util.Encrypt(value);
        }

        [System.Web.Mvc.HttpPost]
        public List<Util.Result> ChangePassword(string action, string Idno, string Name, string Mobile, string regid, string thru, string opwd, string npwd, string sessid)
        {
            var newpwd = "";
            if (action == "ResetMemLogin" || action == "ResetMemTran" || action == "ResetUserLogin" || action == "ResetStoresLogin")
            {
                newpwd = Mobile;
            }
            else
            {
                newpwd = npwd;
            }

            return _objCommon.ChangePassword(action, regid, thru, Util.Encrypt(opwd ?? ""), Util.Encrypt(newpwd));
        }
    

        [System.Web.Mvc.HttpPost]
        public List<GetLinks> MainLinks([FromBody]Params Info)
        {
            return admin.MainLinks(Info.info);
        }


        [System.Web.Mvc.HttpPost]
        public List<UserCreation> CreateOrUpdateUser(Int32 Uid, String Action, string Name, string Mobile, string PF, string ESI,
            string Aadhar, string Email, string Address, string IsInCharge, string IsAdmin, string UserName, string Password, int CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            return admin.CreateOrUpdateUser(Uid, Action, Name, Mobile, PF, ESI,Aadhar, Email,  Address, IsInCharge,IsAdmin, UserName, Password == null ? "" : Util.Encrypt(Password), CreatedBy, Flag, LastUpdatedBy, DeletedBy, sesid);
        }

        [System.Web.Mvc.HttpGet]
        public List<UserDetails> GetUsers(Int32 Uid, string Action, Int32 DeletedBy)
        {
            return admin.GetUsers(Uid, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpPost]
        public List<LinksPremission> LinksPremission([FromBody]Params Info)
        {
            return admin.LinksPremission(Info.info);
        }
        [System.Web.Mvc.HttpPost]
        public List<Util.Result> UpdateLinksPremission([FromBody]Params Info)
        {
            return admin.UpdateLinksPremission(Info.info);
        }

        [System.Web.Mvc.HttpPost]
        public List<Userslogin> UserLoginRpt([FromBody]Params Info)
        {
            return admin.UserLoginRpt(Info.info);
        }

        [System.Web.Mvc.HttpPost]
        public List<CheckUserID> CheckUserID([FromBody]Params Info)
        {
            return admin.CheckUserID(Info.info);
        }

        [System.Web.Mvc.HttpPost]
        public List<Util.Result> UserLogin([FromBody]Params Info)
        {
            return admin.UserLogin(Info.info);
        }


        //[System.Web.Mvc.HttpPost]
        //public List<Util.Result> ChangePassword(string action, string Idno, string Name, string Mobile, string regid, string thru, string opwd, string npwd, string sessid)
        //{
        //    var newpwd = "";
        //    if (action == "ResetMemLogin" || action == "ResetMemTran" || action == "ResetUserLogin" || action == "ResetStoresLogin")
        //    {
        //        var nri = new Random();
        //        var pwd1 = admin.GetRandomString(nri, 2, "1234567890");
        //        var pwd2 = admin.GetRandomString(nri, 6, "ABCDEFGHIJKLMNOPQRSTUVWXYZ");
        //        var pwd3 = admin.GetRandomString(nri, 2, "1234567890");
        //        newpwd = pwd2;
        //    }
        //    else
        //    {
        //        newpwd = npwd;
        //    }
           
        //    return admin.ChangePassword(action, regid, thru, Util.Encrypt(opwd ?? ""), Util.Encrypt(newpwd));
        //}

        public string GetRandomString(Random rnd, int length, string charPool)
        {
            var rs = new StringBuilder();
            while (length-- > 0)
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
            return rs.ToString();
        }


      
        #region "Unit"
        Stores store = new Stores();
        [System.Web.Mvc.HttpPost]
        public List<Unit> CreateOrUpdateUnit(Int32 Unitid, string Action, string UnitName, string UnitDescr, int CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            return admin.CreateOrUpdateUnit(Unitid, Action, UnitName, UnitDescr, CreatedBy, Flag, LastUpdatedBy, DeletedBy, sesid);
        }

        [System.Web.Mvc.HttpGet]
        public List<Unit> GetUnits(Int32 Unitid, string Action, Int32 DeletedBy)
        {
            List<Unit> objunits = new List<Unit>();
            objunits = admin.GetUnits(Unitid, Action, DeletedBy);
            return admin.GetUnits(Unitid, Action, DeletedBy);
        }
        #endregion "Unit"

        #region "Items"
        [System.Web.Mvc.HttpPost]
        public string Insert_Item([FromBody]Params Info)
        {
            return admin.Insert_Item(Info.info);
        }

        [System.Web.Mvc.HttpGet]
        public List<Items> GetItems(string BranchId, string ID, string Action)
        {
            return admin.GetItems(BranchId, ID, Action);
        }

        #endregion "Items"



        #region Expense

        [System.Web.Mvc.HttpPost]
        public List<Expense> Insert_Update_Expense(String action, String ExpID, String ExpenseType, String ExpenseDescr, String Flag)
        {
            Expense objEntity = new Expense();
            objEntity.action = action;
            objEntity.ExpID =Convert.ToInt32(ExpID);
            objEntity.ExpenseType = ExpenseType;
            objEntity.ExpenseDescr = ExpenseDescr;
            objEntity.Flag = Flag;

            return admin.Insert_Update_Expense(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Expense> Get_Expense(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Expense(ID, Action, DeletedBy);
        }

        #endregion Expense


        #region Sites

        [System.Web.Mvc.HttpPost]
        public List<Sites> Insert_Update_Sites(String action, String SiteID, String SiteName, String SiteDescr, String Flag, String Incharge, String StartDate, String EndDate, String SiteAddress, String CreatedBy, String CreatedDate)
        {
            Sites objEntity = new Sites();
            objEntity.action = action;
            objEntity.SiteID =Convert.ToInt32(SiteID);
            objEntity.SiteName = SiteName;
            objEntity.SiteDescr = SiteDescr;
            objEntity.Flag = Flag;
            objEntity.Incharge =Convert.ToInt32(Incharge);
            objEntity.StartDate = StartDate;
            objEntity.EndDate = EndDate;
            objEntity.SiteAddress = SiteAddress;
            objEntity.CreatedBy = Convert.ToInt32 (CreatedBy);
            objEntity.CreatedDate = CreatedDate;

            return admin.Insert_Update_Sites(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Sites> Get_Sites(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Sites(ID, Action, DeletedBy);
        }

        #endregion Sites


        #region Daily_Labour_Miss

        [System.Web.Mvc.HttpPost]
        public List<Daily_Labour_Miss> Insert_Update_Daily_Labour_Miss(String action, String ID, String ExpenseTypeID, String SiteID, String NoofLabours, String Reason, String Amount, String Date, String Comments, String CreatedBy, String FileName, String Flag)
        {
            Daily_Labour_Miss objEntity = new Daily_Labour_Miss();
            objEntity.action = action;
            objEntity.ID =Convert.ToInt32(ID);
            objEntity.ExpenseTypeID = Convert.ToInt32(ExpenseTypeID);
            objEntity.SiteID = Convert.ToInt32(SiteID);
            if (!string.IsNullOrEmpty(NoofLabours))
            {
                objEntity.NoofLabours = Convert.ToInt32(NoofLabours);
            }
            objEntity.Reason = Reason;
            objEntity.Amount =Convert.ToDecimal(Amount);
            objEntity.Date = Date;
            objEntity.Comments = Comments;
            objEntity.CreatedBy = Convert.ToInt32(CreatedBy);
            objEntity.FileName = FileName;
            objEntity.Flag = Flag;

            return admin.Insert_Update_Daily_Labour_Miss(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Daily_Labour_Miss> Get_Daily_Labour_Miss(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Daily_Labour_Miss(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<Daily_Labour_Miss> Get_Daily_Labour_MissRpt(string fromdate, string todate, string EmpID)
        {
            return admin.Get_Daily_Labour_MissRpt(fromdate, todate, EmpID);
        }

        #endregion Daily_Labour_Miss


        #region DailyPurchase

        [System.Web.Mvc.HttpPost]
        public List<DailyPurchase> Insert_Update_DailyPurchase(String action, String ID, String SiteID, String ItemID, String InvoiceNo, String Amount, String Date, String Comments, String Flag, String CreatedBy, String CreatedDate, String FileName)
        {
            DailyPurchase objEntity = new DailyPurchase();
            objEntity.action = action;
            objEntity.ID =Convert.ToInt32(ID);
            objEntity.SiteID = Convert.ToInt32(SiteID);
            objEntity.ItemID = Convert.ToInt32(ItemID);
            objEntity.InvoiceNo = InvoiceNo;
            objEntity.Amount = Convert.ToDecimal(Amount);
            objEntity.Date = Date;
            objEntity.Comments = Comments;
            objEntity.Flag = Flag;
            objEntity.CreatedBy = Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.FileName = FileName;

            return admin.Insert_Update_DailyPurchase(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<DailyPurchase> Get_DailyPurchase(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_DailyPurchase(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<DailyPurchase> Get_DailyPurchaseRpt(string fromdate, string todate, string EmpID)
        {
            return admin.Get_DailyPurchaseRpt(fromdate, todate, EmpID);
        }

        #endregion DailyPurchase


        #region Labour_Payments

        [System.Web.Mvc.HttpPost]
        public List<Labour_Payments> Insert_Update_Labour_Payments(String action, String ID, String SiteID, String EmpID, String PaymentFor, String Amount, String Comments, String Flag, String CreatedBy, String CreatedDate, String Dated)
        {
            Labour_Payments objEntity = new Labour_Payments();
            objEntity.action = action;
            objEntity.ID = Convert.ToInt32(ID);
            objEntity.SiteID =Convert.ToInt32( SiteID);
            objEntity.EmpID =Convert.ToInt32( EmpID);
            objEntity.PaymentFor = PaymentFor;
            objEntity.Amount = Convert.ToDecimal(Amount);
            objEntity.Comments = Comments;
            objEntity.Flag = Flag;
            objEntity.CreatedBy = Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.Dated = Dated;
            return admin.Insert_Update_Labour_Payments(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Labour_Payments> Get_Labour_Payments(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Labour_Payments(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<Labour_Payments> Get_Labour_PaymentsRpt(string fromdate, string todate, string EmpID)
        {
            return admin.Get_Labour_PaymentsRpt(fromdate, todate, EmpID);
        }
        #endregion Labour_Payments


        #region Req_Money

        [System.Web.Mvc.HttpPost]
        public List<Req_Money> Insert_Update_Req_Money(String action, String ID, String SiteID, String ExpenseType, String Amount, String Comments, String IsApproved, String Flag, String CreatedBy, String CreatedDate, String ApprovedBy, String ApprovedDate)
        {
            Req_Money objEntity = new Req_Money();
            objEntity.action = action;
            objEntity.ID = Convert.ToInt32(ID);
            objEntity.SiteID = Convert.ToInt32(SiteID);
            objEntity.ExpenseType = Convert.ToInt32(ExpenseType);
            objEntity.Amount = Convert.ToDecimal(Amount);
            objEntity.Comments = Comments;
            objEntity.IsApproved = Convert.ToInt32(IsApproved);
            objEntity.Flag = Flag;
            objEntity.CreatedBy = Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.ApprovedBy = Convert.ToInt32(ApprovedBy);
            objEntity.ApprovedDate = ApprovedDate;

            return admin.Insert_Update_Req_Money(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Req_Money> Get_Req_Money(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Req_Money(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<Req_Money> Get_Req_MoneyRpt(string fromdate, string todate, string EmpID)
        {
            return admin.Get_Req_MoneyRpt(fromdate, todate, EmpID);
        }
        #endregion Req_Money


        #region Site_Progress

        [System.Web.Mvc.HttpPost]
        public List<Site_Progress> Insert_Update_Site_Progress(String action, String ID, String SiteID, String Perm_Labours, String Cont_Labours, String Daily_Labours, String Comments, String FileName, String Flag, String CreatedBy, String CreatedDate, String Dated)
        {
            Site_Progress objEntity = new Site_Progress();
            objEntity.action = action;
            objEntity.ID = Convert.ToInt32(ID);
            objEntity.SiteID = Convert.ToInt32(SiteID);
            objEntity.Perm_Labours = Convert.ToInt32(Perm_Labours);
            objEntity.Cont_Labours = Convert.ToInt32(Cont_Labours);
            objEntity.Daily_Labours = Convert.ToInt32(Daily_Labours);
            objEntity.Comments = Comments;
            objEntity.FileName = FileName;
            objEntity.Flag = Flag;
            objEntity.CreatedBy = Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.Dated = Dated;
            return admin.Insert_Update_Site_Progress(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Site_Progress> Get_Site_Progress(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Site_Progress(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<Site_Progress> Get_Site_ProgressRpt(string fromdate, string todate,string EmpID)
        {
            return admin.Get_Site_ProgressRpt(fromdate, todate, EmpID);
        }
        #endregion Site_Progress

        #region Dashboard

        [System.Web.Mvc.HttpGet]
        public List<DB_SitePogress> DB_SitePogressRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            return admin.DB_SitePogressRpt(fromdate, todate, EmpID, SiteID);
        }

        [System.Web.Mvc.HttpGet]
        public List<DB_SiteExpenses> DB_SiteExpensesRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            return admin.DB_SiteExpensesRpt(fromdate, todate, EmpID, SiteID);
        }

        [System.Web.Mvc.HttpGet]
        public List<DB_LabourPayments> DB_LabourPaymentsRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            return admin.DB_LabourPaymentsRpt(fromdate, todate, EmpID, SiteID);
        }

        [System.Web.Mvc.HttpGet]
        public List<DB_PendingRequests> DB_PendingRequestsRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            return admin.DB_PendingRequestsRpt(fromdate, todate, EmpID, SiteID);
        }


        #endregion Dashboard


        #region PO

        [System.Web.Mvc.HttpPost]
        public List<PO> Insert_Update_PO(String action, String POID, String MainRef, String Dated, String Name, String ShopNo, String Area, String City, String State, String PinCode, String GSTINNO, String Subject, String RefNo, String Comments, String ExpectedDeliveryDate, String MainContact, String Mobile, String EmailID, String CreatedDate, String CreatedBy, String UpdatedBy, String UpdatedDate, String Status, String Flag)
        {
            PO objEntity = new PO();
            objEntity.action = action;
            objEntity.POID =Convert.ToInt32(POID);
            objEntity.MainRef = MainRef;
            objEntity.Dated = Dated;
            objEntity.Name = Name;
            objEntity.ShopNo = ShopNo;
            objEntity.Area = Area;
            objEntity.City = City;
            objEntity.State = State;
            objEntity.PinCode =Convert.ToInt32(PinCode);
            objEntity.GSTINNO = GSTINNO;
            objEntity.Subject = Subject;
            objEntity.RefNo = RefNo;
            objEntity.Comments = Comments;
            objEntity.ExpectedDeliveryDate = ExpectedDeliveryDate;
            objEntity.MainContact = MainContact;
            objEntity.Mobile = Mobile;
            objEntity.EmailID = EmailID;
            objEntity.CreatedDate = CreatedDate;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;
            objEntity.Status = Status;
            objEntity.Flag = Flag;

            return admin.Insert_Update_PO(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<PO> Get_PO(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_PO(ID, Action, DeletedBy);
        }

        [System.Web.Mvc.HttpGet]
        public List<PO> Get_PORpt(string fromdate, string todate, string EmpID)
        {
            return admin.Get_PORpt(fromdate, todate, EmpID);
        }

        [System.Web.Mvc.HttpGet]
        public PO Get_PORptByID(string POID)
        {
            return admin.Get_PORptByID(POID);
        }

        #endregion PO


        #region PO_Items

        [System.Web.Mvc.HttpPost]
        public List<PO_Items> Insert_Update_PO_Items(String action, String POID, String Description, String Unit, String Qty, String Rate, String Comments, String ID, String Flag)
        {
            PO_Items objEntity = new PO_Items();
            objEntity.action = action;
            objEntity.POID =Convert.ToInt32(POID);
            objEntity.Description = Description;
            objEntity.Unit =Convert.ToString(Unit);
            objEntity.Qty =Convert.ToInt32(Qty);
            objEntity.Rate =Convert.ToInt32(Rate);
            objEntity.Comments = Comments;
            objEntity.ID =Convert.ToInt32(ID);
            objEntity.Flag = Flag;

            return admin.Insert_Update_PO_Items(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<PO_Items> Get_PO_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_PO_Items(ID, Action, DeletedBy);
        }

        #endregion PO_Items


        #region PO_Term_Conditions

        [System.Web.Mvc.HttpPost]
        public List<PO_Term_Conditions> Insert_Update_PO_Term_Conditions(String action, String POID, String Con_Type, String Con_Descr, String ID, String Flag)
        {
            PO_Term_Conditions objEntity = new PO_Term_Conditions();
            objEntity.action = action;
            objEntity.POID =Convert.ToInt32(POID);
            objEntity.Con_Type = Con_Type;
            objEntity.Con_Descr = Con_Descr;
            objEntity.ID =Convert.ToInt32(ID);
            objEntity.Flag = Flag;

            return admin.Insert_Update_PO_Term_Conditions(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<PO_Term_Conditions> Get_PO_Term_Conditions(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_PO_Term_Conditions(ID, Action, DeletedBy);
        }

        #endregion PO_Term_Conditions


        #region Bankers

        [System.Web.Mvc.HttpPost]
        public List<Bankers> Insert_Update_Bankers(String action, String IFSCCODE, String Designation, String BankName, String BranchName, String Flag, String CreatedBy, String CreatedDate)
        {
            Bankers objEntity = new Bankers();
            objEntity.action = action;
            objEntity.IFSCCODE = IFSCCODE;
            objEntity.Designation =Convert.ToInt32(Designation);
            objEntity.BankName = BankName;
            objEntity.BranchName = BranchName;
            objEntity.Flag = Flag;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;

            return admin.Insert_Update_Bankers(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Bankers> Get_Bankers(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Bankers(ID, Action, DeletedBy);
        }

        #endregion Bankers


        #region Customers

        [System.Web.Mvc.HttpPost]
        public List<Customers> Insert_Update_Customers(String action, String CustCode, String CustDesignation, String Unit, String CustName, String StreetNo, String Area, String City, String State, String PhoneNo, String EmailID, String Flag, String CreatedBy, String CreatedDate, String UpdatedBy, String UpdatedDate)
        {
            Customers objEntity = new Customers();
            objEntity.action = action;
            objEntity.CustCode = CustCode;
            objEntity.CustDesignation = CustDesignation;
            objEntity.Unit = Unit;
            objEntity.CustName = CustName;
            objEntity.StreetNo = StreetNo;
            objEntity.Area = Area;
            objEntity.City = City;
            objEntity.State =Convert.ToInt32(State);
            objEntity.PhoneNo = PhoneNo;
            objEntity.EmailID = EmailID;
            objEntity.Flag = Flag;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;

            return admin.Insert_Update_Customers(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Customers> Get_Customers(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Customers(ID, Action, DeletedBy);
        }

        #endregion Customers


        #region Import_Items

        [System.Web.Mvc.HttpPost]
        public List<Import_Items> Insert_Update_Import_Items(String action, String ID, String ProjectCode, String ScheduleNo, String SLNO, String ItemDesc, String ItemUnit, String Qty, String Rate, String Amount, String Flag, String POStatus, String DCStatus, String VendorCode, String CreatedBy, String CreatedDate, String UpdatedBy, String UpdatedDate)
        {
            Import_Items objEntity = new Import_Items();
            objEntity.action = action;
            objEntity.ID =Convert.ToInt32(ID);
            objEntity.ProjectCode = ProjectCode;
            objEntity.ScheduleNo = ScheduleNo;
            objEntity.SLNO = SLNO;
            objEntity.ItemDesc = ItemDesc;
            objEntity.ItemUnit = ItemUnit;
            objEntity.Qty =Convert.ToInt32(Qty);
            objEntity.Rate =Convert.ToInt32(Rate);
            objEntity.Amount =Convert.ToInt32(Amount);
            objEntity.Flag = Flag;
            objEntity.POStatus =Convert.ToInt32(POStatus);
            objEntity.DCStatus =Convert.ToInt32(DCStatus);
            objEntity.VendorCode = VendorCode;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;

            return admin.Insert_Update_Import_Items(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Import_Items> Get_Import_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Import_Items(ID, Action, DeletedBy);
        }

        #endregion Import_Items


        #region Project

        [System.Web.Mvc.HttpPost]
        public List<Project> Insert_Update_Project(String action, String ProjectCode, String ProjectName, String InCharge, String StartDate, String EndDate, String Orderingauthority, String ExpectedEndDate, String ProjectCost, String Flag, String CreatedBy, String CreatedDate, String UpdatedBy, String UpdatedDate)
        {
            Project objEntity = new Project();
            objEntity.action = action;
            objEntity.ProjectCode = ProjectCode;
            objEntity.ProjectName = ProjectName;
            objEntity.InCharge =Convert.ToInt32(InCharge);
            objEntity.StartDate = StartDate;
            objEntity.EndDate = EndDate;
            objEntity.Orderingauthority = Orderingauthority;
            objEntity.ExpectedEndDate = ExpectedEndDate;
            objEntity.ProjectCost =Convert.ToInt32(ProjectCost);
            objEntity.Flag = Flag;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;

            return admin.Insert_Update_Project(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Project> Get_Project(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Project(ID, Action, DeletedBy);
        }

        #endregion Project


        #region Railways

        [System.Web.Mvc.HttpPost]
        public List<Railways> Insert_Update_Railways(String action, String RailwayCode, String Area, String City, String Comments, String Flag, String CreatedBy, String CreatedDate, String UpdatedBy, String UpdatedDate)
        {
            Railways objEntity = new Railways();
            objEntity.action = action;
            objEntity.RailwayCode = RailwayCode;
            objEntity.Area = Area;
            objEntity.City = City;
            objEntity.Comments = Comments;
            objEntity.Flag = Flag;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;

            return admin.Insert_Update_Railways(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Railways> Get_Railways(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Railways(ID, Action, DeletedBy);
        }

        #endregion Railways


        #region Vendors

        [System.Web.Mvc.HttpPost]
        public List<Vendors> Insert_Update_Vendors(String action, String VendorCode, String VendorName, String ContactPersion, String PhoneNo,string EmailID, String StreetNo, String Area, String City, String State, String Flag, String CreatedBy, String CreatedDate, String UpdatedBy, String UpdatedDate)
        {
            Vendors objEntity = new Vendors();
            objEntity.action = action;
            objEntity.VendorCode = VendorCode;
            objEntity.VendorName = VendorName;
            objEntity.ContactPersion = ContactPersion;
            objEntity.PhoneNo = PhoneNo;
            objEntity.EmailID = EmailID;
            objEntity.StreetNo = StreetNo;
            objEntity.Area = Area;
            objEntity.City = City;
            objEntity.State =Convert.ToInt32(State);
            objEntity.Flag = Flag;
            objEntity.CreatedBy =Convert.ToInt32(CreatedBy);
            objEntity.CreatedDate = CreatedDate;
            objEntity.UpdatedBy =Convert.ToInt32(UpdatedBy);
            objEntity.UpdatedDate = UpdatedDate;

            return admin.Insert_Update_Vendors(objEntity);
        }


        [System.Web.Mvc.HttpGet]
        public List<Vendors> Get_Vendors(Int32 ID, string Action, Int32 DeletedBy)
        {
            return admin.Get_Vendors(ID, Action, DeletedBy);
        }

        #endregion Vendors


    }
}

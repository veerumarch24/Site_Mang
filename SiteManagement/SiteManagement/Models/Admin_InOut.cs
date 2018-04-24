using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
namespace SiteManagement
{
    public class Admin_InOut
    {
        

    }
    public class UserLoginIP
    {
        public UserLoginIP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);

            action = (string)jsonObject.action;
            uid = (Int32)jsonObject.uid;
            sesid = (string)jsonObject.sesid;
            myIP = (string)jsonObject.myIP;
            hostName = (string)jsonObject.hostName;
            usertype = (string)jsonObject.usertype;

        }
        public string action { get; set; }
        public Int32 uid { get; set; }
        public string sesid { get; set; }
        public string myIP { get; set; }
        public string hostName { get; set; }
        public string usertype { get; set; }
    }

    public class LinksPremissionIP
    {
        public LinksPremissionIP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);

            uid = (string)jsonObject.uid;
            usertype = (string)jsonObject.usertype;
            action = (string)jsonObject.action;
        }
        public string uid { get; set; }
        public string usertype { get; set; }
        public string action { get; set; }
    }


    public class UPLinksPremissionIP
    {
        public UPLinksPremissionIP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);

            uid = (string)jsonObject.uid;
            usertype = (string)jsonObject.usertype;
            lids = (string)jsonObject.lids;
            Updatedby = (string)jsonObject.Updatedby;
            sessid = (string)jsonObject.sessid;
        }
        public string uid { get; set; }
        public string usertype { get; set; }
        public string lids { get; set; }
        public string Updatedby { get; set; }
        public string sessid { get; set; }
    }

    public class UsersDataIP
    {
        public UsersDataIP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);

            UserType = (string)jsonObject.UserType;
        }
        public string UserType { get; set; }
    }



    public class UsersloginIP
    {
        public UsersloginIP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);

            utype = (string)jsonObject.utype;
            fromdate = (string)jsonObject.fromdate;
            todate = (string)jsonObject.todate;
            uid = (int)jsonObject.uid;
        }
        public string utype { get; set; }
        public string fromdate { get; set; }
        public string todate { get; set; }
        public int uid { get; set; }
    }

    public class UserDetails
    {
        public Int32 CreatedBy { get; set; }
        public Int32 Uid { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }
        public string result { get; set; }
        public string ESI { get; set; }
        public string Aadhar { get; set; }
        public string InCharge { get; set; }
        public string IsAdmin { get; set; }
        public string Address { get; set; }
        public string PF { get; set; }
        public string EmailID { get; set; }
        public string PassWord { get; set; }
        public string Flag { get; set; }
    }
    public class UserCreation
    {
        public Int32 cnt { get; set; }
    }
    public class LinksPremission
    {
        public Int32 Lid { get; set; }
        public Int32 Parent { get; set; }
        public Int32 flag { get; set; }
        public string LinkName { get; set; }
    }
    public class UsersData
    {
        public Int32 uid { get; set; }
        public string Username { get; set; }
    }
    public class Userslogin
    {
        public string ipaddress { get; set; }
        public string username { get; set; }
        public string sesid { get; set; }
        public string sesin { get; set; }
        public string sesout { get; set; }
    }

    public class Unit
    {
        public Int32 Uid { get; set; }
        public Int32 UnitID { get; set; }
        public string UnitName { get; set; }
        public string UnitDescr { get; set; }
        public string Flag { get; set; }
        public string result { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Items_IP
    {
        public Items_IP(string Info)
        {
            var info = Util.DecryptStringAES(Info);
            var jsonObject = Json.Decode(info);
            Item_Type = (string)jsonObject.Item_Type;
            ID = (string)jsonObject.ID;
            Item_Descr = (string)jsonObject.Item_Descr;
            Unit = (string)jsonObject.Unit;
            ItemName = (string)jsonObject.ItemName;
            CreatedDate = (string)jsonObject.CreatedDate;
            CreatedBy = (string)jsonObject.CreatedBy;
            IsActive = (string)jsonObject.IsActive;
            BranchID = (string)jsonObject.BranchID;
            Type = (string)jsonObject.Type;
        }
        public string ID { get; set; }
        public string Item_Type { get; set; }
        public string Item_Descr { get; set; }
        public string Unit { get; set; }
        public string IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
        public string BranchID { get; set; }
    }

    public class Expense_Type
    {
        public Int32 ExpID { get; set; }
        public string ExpenseType { get; set; }
        public string ExpenseDescr { get; set; }
        public string Flag { get; set; }
        public string result { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 cnt { get; set; }
    }

    
    public class Expense
    {
        public string action { get; set; }
        public string result { get; set; }

        public int ExpID { get; set; }

        public string ExpenseType { get; set; }

        public string ExpenseDescr { get; set; }

        public string Flag { get; set; }
        public Int32 cnt { get; set; }
    }



    public class Items
    {

        public string ID { get; set; }
        public string Item_Type { get; set; }
        public string Item_Descr { get; set; }
        public string Unit { get; set; }
        public string IsActive { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ItemName { get; set; }
        public string Type { get; set; }
    }
    
    public class Sites
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public string SiteDescr { get; set; }
        public int Incharge { get; set; }
        public string InchargeName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string SiteAddress { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Daily_Labour_Miss
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public int ExpenseTypeID { get; set; }
        public string ExpenseType { get; set; }
        public int SiteID { get; set; }
        public string  SiteName { get; set; }
        public int? NoofLabours { get; set; }
        public string Reason { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public string FileName { get; set; }
        public Int32 cnt { get; set; }
    }


    public class unit
    {
        public int Unitid { get; set; }

        public string UnitName { get; set; }

        public string UnitDescr { get; set; }

        public int? Flag { get; set; }

        public int? CreatedBy { get; set; }

        public string CreatedOn { get; set; }

        public int? LastUpdatedby { get; set; }

        public string LastUpdatedate { get; set; }

        public int? Deletedby { get; set; }

        public string Deleteddate { get; set; }

    }

    public class DailyPurchase
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int ItemID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string InvoiceNo { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public string FileName { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Labour_Payments
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public string PaymentFor { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public Int32 cnt { get; set; }
        public string Dated { get; set; }
    }

    public class Req_Money
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int ExpenseType { get; set; }
        public string Expense_Type { get; set; }
        public decimal Amount { get; set; }
        public string Comments { get; set; }
        public int IsApproved { get; set; }
        public string ApprovedStatus { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public string ApprovedDate { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Site_Progress
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }
        public int Perm_Labours { get; set; }
        public int Cont_Labours { get; set; }
        public int Daily_Labours { get; set; }
        public string Comments { get; set; }
        public string FileName { get; set; }
        public int? CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedDate { get; set; }
        public Int32 cnt { get; set; }
        public string Dated { get; set; }
    }

    public class DB_SitePogress
    {
        public string SiteName { get; set; }
        public string Permanent { get; set; }
        public string Contract { get; set; }
        public string Daily { get; set; }
    }

    public class DB_SiteExpenses
    {
        public string SiteName { get; set; }
        public string Purchase { get; set; }
        public string Miscellaneous { get; set; }
        public string Labour { get; set; }
    }

    public class DB_LabourPayments
    {
        public string SiteName { get; set; }
        public string EmployeesCnt { get; set; }
        public string PayemtAmount { get; set; }
    }

    public class DB_PendingRequests
    {
        public string SiteName { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedDate { get; set; }
        public string Amount { get; set; }
    }

    public class PO
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int POID { get; set; }
        public string MainRef { get; set; }
        public string Dated { get; set; }
        public string Name { get; set; }
        public string ShopNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int PinCode { get; set; }
        public string GSTINNO { get; set; }
        public string Subject { get; set; }
        public string RefNo { get; set; }
        public string Comments { get; set; }
        public string ExpectedDeliveryDate { get; set; }
        public string MainContact { get; set; }
        public string Mobile { get; set; }
        public string EmailID { get; set; }
        public string CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string Status { get; set; }
        public Int32 cnt { get; set; }
        public string CreatedByName { get; set; }
        public List<PO_Items> poItems { get; set; }
        public List<PO_Term_Conditions> poIermCondi { get; set; }
    }

    public class PO_Items
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int? POID { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public int? Qty { get; set; }
        public decimal? Rate { get; set; }
        public string Comments { get; set; }
        public int ID { get; set; }
        public Int32 cnt { get; set; }
    }

    public class PO_Term_Conditions
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int? POID { get; set; }
        public string Con_Type { get; set; }
        public string Con_Descr { get; set; }
        public int ID { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Bankers
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public string IFSCCODE { get; set; }
        public int Designation { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public Int32 cnt { get; set; }
    }

    public class Customers
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public string CustCode { get; set; }
        public string CustDesignation { get; set; }
        public string Unit { get; set; }
        public string CustName { get; set; }
        public string StreetNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public string PhoneNo { get; set; }
        public string EmailID { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Int32 cnt { get; set; }
    }
    public class Import_Items
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public int ID { get; set; }
        public string ProjectCode { get; set; }
        public string ScheduleNo { get; set; }
        public string SLNO { get; set; }
        public string ItemDesc { get; set; }
        public string ItemUnit { get; set; }
        public int Qty { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
        public int? POStatus { get; set; }
        public int? DCStatus { get; set; }
        public string VendorCode { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Int32 cnt { get; set; }
    }
    public class Project
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int InCharge { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Orderingauthority { get; set; }
        public string ExpectedEndDate { get; set; }
        public decimal ProjectCost { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Int32 cnt { get; set; }
    }
    public class Railways
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public string RailwayCode { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Int32 cnt { get; set; }
    }
    public class Vendors
    {
        public string action { get; set; }
        public string result { get; set; }
        public string Flag { get; set; }
        public string VendorCode { get; set; }
        public string VendorName { get; set; }
        public string ContactPersion { get; set; }
        public string PhoneNo { get; set; }
        public string StreetNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public int State { get; set; }
        public int CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public Int32 cnt { get; set; }
    }

}
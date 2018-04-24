using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SiteManagement
{
    public class AdminObjectFactory
    {
        internal static UserCreation CreateUserItemFactory(SqlDataReader reader)
        {
            UserCreation Items = new UserCreation();
            Items.cnt = (Int32)reader["cnt"];
            return Items;
        }
        internal static LinksPremission LinksPremissionItemFactory(SqlDataReader reader)
        {
            LinksPremission Items = new LinksPremission();

            Items.Lid = (Int32)reader["Lid"];
            Items.Parent = (Int32)reader["Parent"];
            Items.flag = (Int32)reader["flag"];

            if (Convert.IsDBNull(reader["LinkName"]))
                Items.LinkName = null;
            else
                Items.LinkName = (string)reader["LinkName"];

            return Items;
        }
        internal static UsersData UsersItemFactory(SqlDataReader reader)
        {
            UsersData Items = new UsersData();
            Items.uid = (Int32)reader["uid"];
            if (Convert.IsDBNull(reader["Username"]))
                Items.Username = null;
            else
                Items.Username = (string)reader["Username"];
            return Items;
        }
        internal static Userslogin GetUserLoginRptItemFactory(SqlDataReader reader)
        {
            Userslogin Items = new Userslogin();
            if (Convert.IsDBNull(reader["ipaddress"]))
                Items.ipaddress = null;
            else
                Items.ipaddress = (string)reader["ipaddress"];
            if (Convert.IsDBNull(reader["username"]))
                Items.username = null;
            else
                Items.username = (string)reader["username"];

            if (Convert.IsDBNull(reader["sesid"]))
                Items.sesid = null;
            else
                Items.sesid = (string)reader["sesid"];

            if (Convert.IsDBNull(reader["sesin"]))
                Items.sesin = null;
            else
                Items.sesin = (string)reader["sesin"];
            if (Convert.IsDBNull(reader["sesout"]))
                Items.sesout = null;
            else
                Items.sesout = (string)reader["sesout"];

            return Items;
        }
        internal static UserDetails DeleteUsersItemFactory(SqlDataReader reader)
        {
            UserDetails Items = new UserDetails();
            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            return Items;
        }
        internal static UserDetails EditUsersItemFactory(SqlDataReader reader)
        {
            UserDetails Items = new UserDetails();

            Items.Uid = (Int32)reader["Uid"];

            if (Convert.IsDBNull(reader["Flag"]))
                Items.Flag = null;
            else
                Items.Flag = (string)reader["Flag"];

            if (Convert.IsDBNull(reader["Name"]))
                Items.Name = null;
            else
                Items.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["PF"]))
                Items.PF = null;
            else
                Items.PF = (string)reader["PF"];
            if (Convert.IsDBNull(reader["ESI"]))
                Items.ESI = null;
            else
                Items.ESI = (string)reader["ESI"];

            if (Convert.IsDBNull(reader["PhoneNo"]))
                Items.PhoneNo = null;
            else
                Items.PhoneNo = (string)reader["PhoneNo"];

            if (Convert.IsDBNull(reader["Address"]))
                Items.Address = null;
            else
                Items.Address = (string)reader["Address"];

            if (Convert.IsDBNull(reader["Aadhar"]))
                Items.Aadhar = null;
            else
                Items.Aadhar = (string)reader["Aadhar"];

            if (Convert.IsDBNull(reader["EmailID"]))
                Items.EmailID = null;
            else
                Items.EmailID = (string)reader["EmailID"];

            if (Convert.IsDBNull(reader["UserName"]))
                Items.UserName = null;
            else
                Items.UserName = (string)reader["UserName"];


            if (Convert.IsDBNull(reader["InCharge"]))
                Items.InCharge = null;
            else
                Items.InCharge = (string)reader["InCharge"];

            if (Convert.IsDBNull(reader["IsAdmin"]))
                Items.IsAdmin = null;
            else
                Items.IsAdmin = (string)reader["IsAdmin"];

            return Items;
        }
        internal static UserDetails GetUsersItemFactory(SqlDataReader reader)
        {
            UserDetails Items = new UserDetails();
            Items.Uid = (Int32)reader["Uid"];
            if (Convert.IsDBNull(reader["Flag"]))
                Items.Flag = null;
            else
                Items.Flag = (string)reader["Flag"];

            if (Convert.IsDBNull(reader["UserName"]))
                Items.UserName = null;
            else
                Items.UserName = (string)reader["UserName"];

            if (Convert.IsDBNull(reader["Name"]))
                Items.Name = null;
            else
                Items.Name = (string)reader["Name"];

            if (Convert.IsDBNull(reader["PhoneNo"]))
                Items.PhoneNo = null;
            else
                Items.PhoneNo = (string)reader["PhoneNo"];

            if (Convert.IsDBNull(reader["EmailID"]))
                Items.EmailID = null;
            else
                Items.EmailID = (string)reader["EmailID"];

            if (Convert.IsDBNull(reader["Address"]))
                Items.Address = null;
            else
                Items.Address = (string)reader["Address"];

            if (Convert.IsDBNull(reader["PF"]))
                Items.PF = null;
            else
                Items.PF = (string)reader["PF"];

            if (Convert.IsDBNull(reader["ESI"]))
                Items.ESI = null;
            else
                Items.ESI = (string)reader["ESI"];

            if (Convert.IsDBNull(reader["Aadhar"]))
                Items.Aadhar = null;
            else
                Items.Aadhar = (string)reader["Aadhar"];

            if (Convert.IsDBNull(reader["InCharge"]))
                Items.InCharge = null;
            else
                Items.InCharge = (string)reader["InCharge"];

            if (Convert.IsDBNull(reader["IsAdmin"]))
                Items.IsAdmin = null;
            else
                Items.IsAdmin = (string)reader["IsAdmin"];
            return Items;
        }
        internal static CheckUserID CheckUserIDItemFactory(SqlDataReader reader)
        {
            CheckUserID Items = new CheckUserID();

            Items.regid = (Int32)reader["regid"];

            if (Convert.IsDBNull(reader["result"]))
                Items.result = null;
            else
                Items.result = (string)reader["result"];

            return Items;
        }
        #region "Unit"
        internal static Unit CreateUnitItemFactory(SqlDataReader reader)
        {
            Unit Items = new Unit();
            Items.cnt = (Int32)reader["cnt"];
            return Items;
        }

        internal static Unit GetUnitItemFactory(SqlDataReader reader)
        {
            Unit obj = new Unit();
            obj.Uid = (Int32)reader["Uid"];
            if (Convert.IsDBNull(reader["Flag"]))
                obj.Flag = null;
            else
                obj.Flag = (string)reader["Flag"];

            if (Convert.IsDBNull(reader["UnitID"]))
                obj.UnitID = 0;
            else
                obj.UnitID = (Int32)reader["UnitID"];

            if (Convert.IsDBNull(reader["UnitName"]))
                obj.UnitName = null;
            else
                obj.UnitName = (string)reader["UnitName"];

            if (Convert.IsDBNull(reader["UnitDescr"]))
                obj.UnitDescr = null;
            else
                obj.UnitDescr = (string)reader["UnitDescr"];

            return obj;
        }


        internal static Unit DeleteUnitItemFactory(SqlDataReader reader)
        {
            Unit obj = new Unit();
            if (Convert.IsDBNull(reader["result"]))
                obj.result = null;
            else
                obj.result = (string)reader["result"];

            return obj;
        }
        internal static Unit EditUnitItemFactory(SqlDataReader reader)
        {
            Unit obj = new Unit();
            obj.CreatedBy = (Int32)reader["CreatedBy"];
            obj.Uid = (Int32)reader["Uid"];

            if (Convert.IsDBNull(reader["Flag"]))
                obj.Flag = null;
            else
                obj.Flag = (string)reader["Flag"];

            if (Convert.IsDBNull(reader["UnitName"]))
                obj.UnitName = null;
            else
                obj.UnitName = (string)reader["UnitName"];
            if (Convert.IsDBNull(reader["UnitDescr"]))
                obj.UnitDescr = null;
            else
                obj.UnitDescr = (string)reader["UnitDescr"];

            return obj;
        }
        #endregion "Unit"

        #region Expense
        internal static Expense Insert_Update_Expense_Factory(SqlDataReader reader)
        {
            Expense objExpe = new Expense();
            objExpe.cnt = (Int32)reader["cnt"];
            return objExpe;
        }
        internal static Expense Get_Expense_Factory(SqlDataReader reader)
        {
            Expense objEntity = new Expense();

            if (!Convert.IsDBNull(reader["ExpID"]))
                objEntity.ExpID = (Int32)reader["ExpID"];

            if (!Convert.IsDBNull(reader["ExpenseType"]))
                objEntity.ExpenseType = (string)reader["ExpenseType"];

            if (!Convert.IsDBNull(reader["ExpenseDescr"]))
                objEntity.ExpenseDescr = (string)reader["ExpenseDescr"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }

        internal static Expense Delete_Expense_Factory(SqlDataReader reader)
        {
            Expense objEntity = new Expense();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Expense Edit_Expense_Factory(SqlDataReader reader)
        {
            Expense objEntity = new Expense();

            if (!Convert.IsDBNull(reader["ExpID"]))
                objEntity.ExpID = (Int32)reader["ExpID"];

            if (!Convert.IsDBNull(reader["ExpenseType"]))
                objEntity.ExpenseType = (string)reader["ExpenseType"];

            if (!Convert.IsDBNull(reader["ExpenseDescr"]))
                objEntity.ExpenseDescr = (string)reader["ExpenseDescr"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }
        #endregion Expense

        #region Sites
        internal static Sites Insert_Update_Sites_Factory(SqlDataReader reader)
        {
            Sites objSite = new Sites();
            objSite.cnt = (Int32)reader["cnt"];
            return objSite;
        }
        internal static Sites Get_Sites_Factory(SqlDataReader reader)
        {
            Sites objEntity = new Sites();

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["SiteName"]))
                objEntity.SiteName = (string)reader["SiteName"];

            if (!Convert.IsDBNull(reader["SiteDescr"]))
                objEntity.SiteDescr = (string)reader["SiteDescr"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["Incharge"]))
                objEntity.Incharge = (Int32)reader["Incharge"];

            if (!Convert.IsDBNull(reader["StartDate"]))
                objEntity.StartDate = (string)reader["StartDate"];

            if (!Convert.IsDBNull(reader["EndDate"]))
                objEntity.EndDate = (string)reader["EndDate"];

            if (!Convert.IsDBNull(reader["SiteAddress"]))
                objEntity.SiteAddress = (string)reader["SiteAddress"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["InchargeName"]))
                objEntity.InchargeName = (string)reader["InchargeName"];
            return objEntity;
        }

        internal static Sites Delete_Sites_Factory(SqlDataReader reader)
        {
            Sites objEntity = new Sites();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Sites Edit_Sites_Factory(SqlDataReader reader)
        {
            Sites objEntity = new Sites();

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["SiteName"]))
                objEntity.SiteName = (string)reader["SiteName"];

            if (!Convert.IsDBNull(reader["SiteDescr"]))
                objEntity.SiteDescr = (string)reader["SiteDescr"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["Incharge"]))
                objEntity.Incharge = (Int32)reader["Incharge"];

            if (!Convert.IsDBNull(reader["StartDate"]))
                objEntity.StartDate = (string)reader["StartDate"];

            if (!Convert.IsDBNull(reader["EndDate"]))
                objEntity.EndDate = (string)reader["EndDate"];

            if (!Convert.IsDBNull(reader["SiteAddress"]))
                objEntity.SiteAddress = (string)reader["SiteAddress"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            return objEntity;
        }
        #endregion Sites

        #region Daily_Labour_Miss
        internal static Daily_Labour_Miss Insert_Update_Daily_Labour_Miss_Factory(SqlDataReader reader)
        {
            Daily_Labour_Miss objDail = new Daily_Labour_Miss();
            objDail.cnt = (Int32)reader["cnt"];
            return objDail;
        }
        internal static Daily_Labour_Miss Get_Daily_Labour_Miss_Factory(SqlDataReader reader)
        {
            Daily_Labour_Miss objEntity = new Daily_Labour_Miss();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["ExpenseTypeID"]))
                objEntity.ExpenseTypeID = (Int32)reader["ExpenseTypeID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["NoofLabours"]))
                objEntity.NoofLabours = (Int32)reader["NoofLabours"];

            if (!Convert.IsDBNull(reader["Reason"]))
                objEntity.Reason = (string)reader["Reason"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Date"]))
                objEntity.Date = (string)reader["Date"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }

        internal static Daily_Labour_Miss Delete_Daily_Labour_Miss_Factory(SqlDataReader reader)
        {
            Daily_Labour_Miss objEntity = new Daily_Labour_Miss();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Daily_Labour_Miss Edit_Daily_Labour_Miss_Factory(SqlDataReader reader)
        {
            Daily_Labour_Miss objEntity = new Daily_Labour_Miss();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["ExpenseTypeID"]))
                objEntity.ExpenseTypeID = (Int32)reader["ExpenseTypeID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["NoofLabours"]))
                objEntity.NoofLabours = (Int32)reader["NoofLabours"];

            if (!Convert.IsDBNull(reader["Reason"]))
                objEntity.Reason = (string)reader["Reason"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount =Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Date"]))
                objEntity.Date = (string)reader["Date"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }
        #endregion Daily_Labour_Miss

        #region DailyPurchase
        internal static DailyPurchase Insert_Update_DailyPurchase_Factory(SqlDataReader reader)
        {
            DailyPurchase objDail = new DailyPurchase();
            objDail.cnt = (Int32)reader["cnt"];
            return objDail;
        }
        internal static DailyPurchase Get_DailyPurchase_Factory(SqlDataReader reader)
        {
            DailyPurchase objEntity = new DailyPurchase();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["ItemID"]))
                objEntity.ItemID = (Int32)reader["ItemID"];

            if (!Convert.IsDBNull(reader["InvoiceNo"]))
                objEntity.InvoiceNo = (string)reader["InvoiceNo"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Date"]))
                objEntity.Date = (string)reader["Date"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            return objEntity;
        }

        internal static DailyPurchase Delete_DailyPurchase_Factory(SqlDataReader reader)
        {
            DailyPurchase objEntity = new DailyPurchase();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static DailyPurchase Edit_DailyPurchase_Factory(SqlDataReader reader)
        {
            DailyPurchase objEntity = new DailyPurchase();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["ItemID"]))
                objEntity.ItemID = (Int32)reader["ItemID"];

            if (!Convert.IsDBNull(reader["Item_Type"]))
                objEntity.ItemType = (string)reader["Item_Type"];

            if (!Convert.IsDBNull(reader["InvoiceNo"]))
                objEntity.InvoiceNo = (string)reader["InvoiceNo"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Date"]))
                objEntity.Date = (string)reader["Date"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            return objEntity;
        }
        #endregion DailyPurchase
        #region Labour_Payments
        internal static Labour_Payments Insert_Update_Labour_Payments_Factory(SqlDataReader reader)
        {
            Labour_Payments objLabo = new Labour_Payments();
            objLabo.cnt = (Int32)reader["cnt"];
            return objLabo;
        }
        internal static Labour_Payments Get_Labour_Payments_Factory(SqlDataReader reader)
        {
            Labour_Payments objEntity = new Labour_Payments();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["EmpID"]))
                objEntity.EmpID = (Int32)reader["EmpID"];

            if (!Convert.IsDBNull(reader["PaymentFor"]))
                objEntity.PaymentFor = (string)reader["PaymentFor"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            return objEntity;
        }

        internal static Labour_Payments Delete_Labour_Payments_Factory(SqlDataReader reader)
        {
            Labour_Payments objEntity = new Labour_Payments();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Labour_Payments Edit_Labour_Payments_Factory(SqlDataReader reader)
        {
            Labour_Payments objEntity = new Labour_Payments();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["EmpID"]))
                objEntity.EmpID = (Int32)reader["EmpID"];

            if (!Convert.IsDBNull(reader["PaymentFor"]))
                objEntity.PaymentFor = (string)reader["PaymentFor"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["Dated"]))
                objEntity.Dated = (string)reader["Dated"];


            return objEntity;
        }
        #endregion Labour_Payments
        #region Req_Money
        internal static Req_Money Insert_Update_Req_Money_Factory(SqlDataReader reader)
        {
            Req_Money objReq_ = new Req_Money();
            objReq_.cnt = (Int32)reader["cnt"];
            return objReq_;
        }
        internal static Req_Money Get_Req_Money_Factory(SqlDataReader reader)
        {
            Req_Money objEntity = new Req_Money();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["ExpenseType"]))
                objEntity.ExpenseType = (Int32)reader["ExpenseType"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["IsApproved"]))
                objEntity.IsApproved = (Int32)reader["IsApproved"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["ApprovedBy"]))
                objEntity.ApprovedBy = (Int32)reader["ApprovedBy"];

            if (!Convert.IsDBNull(reader["ApprovedDate"]))
                objEntity.ApprovedDate = (string)reader["ApprovedDate"];

            return objEntity;
        }

        internal static Req_Money Delete_Req_Money_Factory(SqlDataReader reader)
        {
            Req_Money objEntity = new Req_Money();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Req_Money Edit_Req_Money_Factory(SqlDataReader reader)
        {
            Req_Money objEntity = new Req_Money();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["ExpenseType"]))
                objEntity.ExpenseType = (Int32)reader["ExpenseType"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = Convert.ToDecimal(reader["Amount"]);

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["IsApproved"]))
                objEntity.IsApproved = (Int32)reader["IsApproved"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["ApprovedBy"]))
                objEntity.ApprovedBy = (Int32)reader["ApprovedBy"];

            if (!Convert.IsDBNull(reader["ApprovedDate"]))
                objEntity.ApprovedDate = (string)reader["ApprovedDate"];

            return objEntity;
        }
        #endregion Req_Money
        #region Site_Progress
        internal static Site_Progress Insert_Update_Site_Progress_Factory(SqlDataReader reader)
        {
            Site_Progress objSite = new Site_Progress();
            objSite.cnt = (Int32)reader["cnt"];
            return objSite;
        }
        internal static Site_Progress Get_Site_Progress_Factory(SqlDataReader reader)
        {
            Site_Progress objEntity = new Site_Progress();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["Perm_Labours"]))
                objEntity.Perm_Labours = (Int32)reader["Perm_Labours"];

            if (!Convert.IsDBNull(reader["Cont_Labours"]))
                objEntity.Cont_Labours = (Int32)reader["Cont_Labours"];

            if (!Convert.IsDBNull(reader["Daily_Labours"]))
                objEntity.Daily_Labours = (Int32)reader["Daily_Labours"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            return objEntity;
        }

        internal static Site_Progress Delete_Site_Progress_Factory(SqlDataReader reader)
        {
            Site_Progress objEntity = new Site_Progress();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Site_Progress Edit_Site_Progress_Factory(SqlDataReader reader)
        {
            Site_Progress objEntity = new Site_Progress();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["SiteID"]))
                objEntity.SiteID = (Int32)reader["SiteID"];

            if (!Convert.IsDBNull(reader["Perm_Labours"]))
                objEntity.Perm_Labours = (Int32)reader["Perm_Labours"];

            if (!Convert.IsDBNull(reader["Cont_Labours"]))
                objEntity.Cont_Labours = (Int32)reader["Cont_Labours"];

            if (!Convert.IsDBNull(reader["Daily_Labours"]))
                objEntity.Daily_Labours = (Int32)reader["Daily_Labours"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["FileName"]))
                objEntity.FileName = (string)reader["FileName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["Dated"]))
                objEntity.Dated = (string)reader["Dated"];

            return objEntity;
        }
        #endregion Site_Progress

        #region PO
        internal static PO Insert_Update_PO_Factory(SqlDataReader reader)
        {
            PO objPO = new PO();
            objPO.cnt = (Int32)reader["cnt"];
            return objPO;
        }
        internal static PO Get_PO_Factory(SqlDataReader reader)
        {
            PO objEntity = new PO();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["MainRef"]))
                objEntity.MainRef = (string)reader["MainRef"];

            if (!Convert.IsDBNull(reader["Dated"]))
                objEntity.Dated = (string)reader["Dated"];

            if (!Convert.IsDBNull(reader["Name"]))
                objEntity.Name = (string)reader["Name"];

            if (!Convert.IsDBNull(reader["ShopNo"]))
                objEntity.ShopNo = (string)reader["ShopNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (string)reader["State"];

            if (!Convert.IsDBNull(reader["PinCode"]))
                objEntity.PinCode = (Int32)reader["PinCode"];

            if (!Convert.IsDBNull(reader["GSTINNO"]))
                objEntity.GSTINNO = (string)reader["GSTINNO"];

            if (!Convert.IsDBNull(reader["Subject"]))
                objEntity.Subject = (string)reader["Subject"];

            if (!Convert.IsDBNull(reader["RefNo"]))
                objEntity.RefNo = (string)reader["RefNo"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["ExpectedDeliveryDate"]))
                objEntity.ExpectedDeliveryDate = (string)reader["ExpectedDeliveryDate"];

            if (!Convert.IsDBNull(reader["MainContact"]))
                objEntity.MainContact = (string)reader["MainContact"];

            if (!Convert.IsDBNull(reader["Mobile"]))
                objEntity.Mobile = (string)reader["Mobile"];

            if (!Convert.IsDBNull(reader["EmailID"]))
                objEntity.EmailID = (string)reader["EmailID"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            if (!Convert.IsDBNull(reader["Status"]))
                objEntity.Status = (string)reader["Status"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }

        internal static PO Delete_PO_Factory(SqlDataReader reader)
        {
            PO objEntity = new PO();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static PO Edit_PO_Factory(SqlDataReader reader)
        {
            PO objEntity = new PO();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["MainRef"]))
                objEntity.MainRef = (string)reader["MainRef"];

            if (!Convert.IsDBNull(reader["Dated"]))
                objEntity.Dated = (string)reader["Dated"];

            if (!Convert.IsDBNull(reader["Name"]))
                objEntity.Name = (string)reader["Name"];

            if (!Convert.IsDBNull(reader["ShopNo"]))
                objEntity.ShopNo = (string)reader["ShopNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (string)reader["State"];

            if (!Convert.IsDBNull(reader["PinCode"]))
                objEntity.PinCode = (Int32)reader["PinCode"];

            if (!Convert.IsDBNull(reader["GSTINNO"]))
                objEntity.GSTINNO = (string)reader["GSTINNO"];

            if (!Convert.IsDBNull(reader["Subject"]))
                objEntity.Subject = (string)reader["Subject"];

            if (!Convert.IsDBNull(reader["RefNo"]))
                objEntity.RefNo = (string)reader["RefNo"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["ExpectedDeliveryDate"]))
                objEntity.ExpectedDeliveryDate = (string)reader["ExpectedDeliveryDate"];

            if (!Convert.IsDBNull(reader["MainContact"]))
                objEntity.MainContact = (string)reader["MainContact"];

            if (!Convert.IsDBNull(reader["Mobile"]))
                objEntity.Mobile = (string)reader["Mobile"];

            if (!Convert.IsDBNull(reader["EmailID"]))
                objEntity.EmailID = (string)reader["EmailID"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            if (!Convert.IsDBNull(reader["Status"]))
                objEntity.Status = (string)reader["Status"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }
        #endregion PO
        #region PO_Items
        internal static PO_Items Insert_Update_PO_Items_Factory(SqlDataReader reader)
        {
            PO_Items objPO_I = new PO_Items();
            objPO_I.cnt = (Int32)reader["cnt"];
            return objPO_I;
        }
        internal static PO_Items Get_PO_Items_Factory(SqlDataReader reader)
        {
            PO_Items objEntity = new PO_Items();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["Description"]))
                objEntity.Description = (string)reader["Description"];

            if (!Convert.IsDBNull(reader["Unit"]))
                objEntity.Unit = (string)reader["Unit"];

            if (!Convert.IsDBNull(reader["Qty"]))
                objEntity.Qty = (Int32)reader["Qty"];

            if (!Convert.IsDBNull(reader["Rate"]))
                objEntity.Rate = (Int32)reader["Rate"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }

        internal static PO_Items Delete_PO_Items_Factory(SqlDataReader reader)
        {
            PO_Items objEntity = new PO_Items();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static PO_Items Edit_PO_Items_Factory(SqlDataReader reader)
        {
            PO_Items objEntity = new PO_Items();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["Description"]))
                objEntity.Description = (string)reader["Description"];

            if (!Convert.IsDBNull(reader["Unit"]))
                objEntity.Unit = (string)reader["Unit"];

            if (!Convert.IsDBNull(reader["Qty"]))
                objEntity.Qty = (Int32)reader["Qty"];

            if (!Convert.IsDBNull(reader["Rate"]))
                objEntity.Rate = (Int32)reader["Rate"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }
        #endregion PO_Items
        #region PO_Term_Conditions
        internal static PO_Term_Conditions Insert_Update_PO_Term_Conditions_Factory(SqlDataReader reader)
        {
            PO_Term_Conditions objPO_T = new PO_Term_Conditions();
            objPO_T.cnt = (Int32)reader["cnt"];
            return objPO_T;
        }
        internal static PO_Term_Conditions Get_PO_Term_Conditions_Factory(SqlDataReader reader)
        {
            PO_Term_Conditions objEntity = new PO_Term_Conditions();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["Con_Type"]))
                objEntity.Con_Type = (string)reader["Con_Type"];

            if (!Convert.IsDBNull(reader["Con_Descr"]))
                objEntity.Con_Descr = (string)reader["Con_Descr"];

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }

        internal static PO_Term_Conditions Delete_PO_Term_Conditions_Factory(SqlDataReader reader)
        {
            PO_Term_Conditions objEntity = new PO_Term_Conditions();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static PO_Term_Conditions Edit_PO_Term_Conditions_Factory(SqlDataReader reader)
        {
            PO_Term_Conditions objEntity = new PO_Term_Conditions();

            if (!Convert.IsDBNull(reader["POID"]))
                objEntity.POID = (Int32)reader["POID"];

            if (!Convert.IsDBNull(reader["Con_Type"]))
                objEntity.Con_Type = (string)reader["Con_Type"];

            if (!Convert.IsDBNull(reader["Con_Descr"]))
                objEntity.Con_Descr = (string)reader["Con_Descr"];

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            return objEntity;
        }
        #endregion PO_Term_Conditions

        #region Project
        internal static Project Insert_Update_Project_Factory(SqlDataReader reader)
        {
            Project objProj = new Project();
            objProj.cnt = (Int32)reader["cnt"];
            return objProj;
        }
        internal static Project Get_Project_Factory(SqlDataReader reader)
        {
            Project objEntity = new Project();

            if (!Convert.IsDBNull(reader["ProjectCode"]))
                objEntity.ProjectCode = (string)reader["ProjectCode"];

            if (!Convert.IsDBNull(reader["ProjectName"]))
                objEntity.ProjectName = (string)reader["ProjectName"];

            if (!Convert.IsDBNull(reader["InCharge"]))
                objEntity.InCharge = (Int32)reader["InCharge"];

            if (!Convert.IsDBNull(reader["StartDate"]))
                objEntity.StartDate = (string)reader["StartDate"];

            if (!Convert.IsDBNull(reader["EndDate"]))
                objEntity.EndDate = (string)reader["EndDate"];

            if (!Convert.IsDBNull(reader["Orderingauthority"]))
                objEntity.Orderingauthority = (string)reader["Orderingauthority"];

            if (!Convert.IsDBNull(reader["ExpectedEndDate"]))
                objEntity.ExpectedEndDate = (string)reader["ExpectedEndDate"];

            if (!Convert.IsDBNull(reader["ProjectCost"]))
                objEntity.ProjectCost = (Int32)reader["ProjectCost"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }

        internal static Project Delete_Project_Factory(SqlDataReader reader)
        {
            Project objEntity = new Project();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Project Edit_Project_Factory(SqlDataReader reader)
        {
            Project objEntity = new Project();

            if (!Convert.IsDBNull(reader["ProjectCode"]))
                objEntity.ProjectCode = (string)reader["ProjectCode"];

            if (!Convert.IsDBNull(reader["ProjectName"]))
                objEntity.ProjectName = (string)reader["ProjectName"];

            if (!Convert.IsDBNull(reader["InCharge"]))
                objEntity.InCharge = (Int32)reader["InCharge"];

            if (!Convert.IsDBNull(reader["StartDate"]))
                objEntity.StartDate = (string)reader["StartDate"];

            if (!Convert.IsDBNull(reader["EndDate"]))
                objEntity.EndDate = (string)reader["EndDate"];

            if (!Convert.IsDBNull(reader["Orderingauthority"]))
                objEntity.Orderingauthority = (string)reader["Orderingauthority"];

            if (!Convert.IsDBNull(reader["ExpectedEndDate"]))
                objEntity.ExpectedEndDate = (string)reader["ExpectedEndDate"];

            if (!Convert.IsDBNull(reader["ProjectCost"]))
                objEntity.ProjectCost = (Int32)reader["ProjectCost"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }
        #endregion Project
        #region Bankers
        internal static Bankers Insert_Update_Bankers_Factory(SqlDataReader reader)
        {
            Bankers objBank = new Bankers();
            objBank.cnt = (Int32)reader["cnt"];
            return objBank;
        }
        internal static Bankers Get_Bankers_Factory(SqlDataReader reader)
        {
            Bankers objEntity = new Bankers();

            if (!Convert.IsDBNull(reader["IFSCCODE"]))
                objEntity.IFSCCODE = (string)reader["IFSCCODE"];

            if (!Convert.IsDBNull(reader["Designation"]))
                objEntity.Designation = (Int32)reader["Designation"];

            if (!Convert.IsDBNull(reader["BankName"]))
                objEntity.BankName = (string)reader["BankName"];

            if (!Convert.IsDBNull(reader["BranchName"]))
                objEntity.BranchName = (string)reader["BranchName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            return objEntity;
        }

        internal static Bankers Delete_Bankers_Factory(SqlDataReader reader)
        {
            Bankers objEntity = new Bankers();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Bankers Edit_Bankers_Factory(SqlDataReader reader)
        {
            Bankers objEntity = new Bankers();

            if (!Convert.IsDBNull(reader["IFSCCODE"]))
                objEntity.IFSCCODE = (string)reader["IFSCCODE"];

            if (!Convert.IsDBNull(reader["Designation"]))
                objEntity.Designation = (Int32)reader["Designation"];

            if (!Convert.IsDBNull(reader["BankName"]))
                objEntity.BankName = (string)reader["BankName"];

            if (!Convert.IsDBNull(reader["BranchName"]))
                objEntity.BranchName = (string)reader["BranchName"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            return objEntity;
        }
        #endregion Bankers
        #region Customers
        internal static Customers Insert_Update_Customers_Factory(SqlDataReader reader)
        {
            Customers objCust = new Customers();
            objCust.cnt = (Int32)reader["cnt"];
            return objCust;
        }
        internal static Customers Get_Customers_Factory(SqlDataReader reader)
        {
            Customers objEntity = new Customers();

            if (!Convert.IsDBNull(reader["CustCode"]))
                objEntity.CustCode = (string)reader["CustCode"];

            if (!Convert.IsDBNull(reader["CustDesignation"]))
                objEntity.CustDesignation = (string)reader["CustDesignation"];

            if (!Convert.IsDBNull(reader["Unit"]))
                objEntity.Unit = (string)reader["Unit"];

            if (!Convert.IsDBNull(reader["CustName"]))
                objEntity.CustName = (string)reader["CustName"];

            if (!Convert.IsDBNull(reader["StreetNo"]))
                objEntity.StreetNo = (string)reader["StreetNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (Int32)reader["State"];

            if (!Convert.IsDBNull(reader["PhoneNo"]))
                objEntity.PhoneNo = (string)reader["PhoneNo"];

            if (!Convert.IsDBNull(reader["EmailID"]))
                objEntity.EmailID = (string)reader["EmailID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }

        internal static Customers Delete_Customers_Factory(SqlDataReader reader)
        {
            Customers objEntity = new Customers();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Customers Edit_Customers_Factory(SqlDataReader reader)
        {
            Customers objEntity = new Customers();

            if (!Convert.IsDBNull(reader["CustCode"]))
                objEntity.CustCode = (string)reader["CustCode"];

            if (!Convert.IsDBNull(reader["CustDesignation"]))
                objEntity.CustDesignation = (string)reader["CustDesignation"];

            if (!Convert.IsDBNull(reader["Unit"]))
                objEntity.Unit = (string)reader["Unit"];

            if (!Convert.IsDBNull(reader["CustName"]))
                objEntity.CustName = (string)reader["CustName"];

            if (!Convert.IsDBNull(reader["StreetNo"]))
                objEntity.StreetNo = (string)reader["StreetNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (Int32)reader["State"];

            if (!Convert.IsDBNull(reader["PhoneNo"]))
                objEntity.PhoneNo = (string)reader["PhoneNo"];

            if (!Convert.IsDBNull(reader["EmailID"]))
                objEntity.EmailID = (string)reader["EmailID"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }
        #endregion Customers
        #region Import_Items
        internal static Import_Items Insert_Update_Import_Items_Factory(SqlDataReader reader)
        {
            Import_Items objImpo = new Import_Items();
            objImpo.cnt = (Int32)reader["cnt"];
            return objImpo;
        }
        internal static Import_Items Get_Import_Items_Factory(SqlDataReader reader)
        {
            Import_Items objEntity = new Import_Items();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["ProjectCode"]))
                objEntity.ProjectCode = (string)reader["ProjectCode"];

            if (!Convert.IsDBNull(reader["ScheduleNo"]))
                objEntity.ScheduleNo = (string)reader["ScheduleNo"];

            if (!Convert.IsDBNull(reader["SLNO"]))
                objEntity.SLNO = (string)reader["SLNO"];

            if (!Convert.IsDBNull(reader["ItemDesc"]))
                objEntity.ItemDesc = (string)reader["ItemDesc"];

            if (!Convert.IsDBNull(reader["ItemUnit"]))
                objEntity.ItemUnit = (string)reader["ItemUnit"];

            if (!Convert.IsDBNull(reader["Qty"]))
                objEntity.Qty = (Int32)reader["Qty"];

            if (!Convert.IsDBNull(reader["Rate"]))
                objEntity.Rate = (Int32)reader["Rate"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = (Int32)reader["Amount"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["POStatus"]))
                objEntity.POStatus = (Int32)reader["POStatus"];

            if (!Convert.IsDBNull(reader["DCStatus"]))
                objEntity.DCStatus = (Int32)reader["DCStatus"];

            if (!Convert.IsDBNull(reader["VendorCode"]))
                objEntity.VendorCode = (string)reader["VendorCode"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }

        internal static Import_Items Delete_Import_Items_Factory(SqlDataReader reader)
        {
            Import_Items objEntity = new Import_Items();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Import_Items Edit_Import_Items_Factory(SqlDataReader reader)
        {
            Import_Items objEntity = new Import_Items();

            if (!Convert.IsDBNull(reader["ID"]))
                objEntity.ID = (Int32)reader["ID"];

            if (!Convert.IsDBNull(reader["ProjectCode"]))
                objEntity.ProjectCode = (string)reader["ProjectCode"];

            if (!Convert.IsDBNull(reader["ScheduleNo"]))
                objEntity.ScheduleNo = (string)reader["ScheduleNo"];

            if (!Convert.IsDBNull(reader["SLNO"]))
                objEntity.SLNO = (string)reader["SLNO"];

            if (!Convert.IsDBNull(reader["ItemDesc"]))
                objEntity.ItemDesc = (string)reader["ItemDesc"];

            if (!Convert.IsDBNull(reader["ItemUnit"]))
                objEntity.ItemUnit = (string)reader["ItemUnit"];

            if (!Convert.IsDBNull(reader["Qty"]))
                objEntity.Qty = (Int32)reader["Qty"];

            if (!Convert.IsDBNull(reader["Rate"]))
                objEntity.Rate = (Int32)reader["Rate"];

            if (!Convert.IsDBNull(reader["Amount"]))
                objEntity.Amount = (Int32)reader["Amount"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["POStatus"]))
                objEntity.POStatus = (Int32)reader["POStatus"];

            if (!Convert.IsDBNull(reader["DCStatus"]))
                objEntity.DCStatus = (Int32)reader["DCStatus"];

            if (!Convert.IsDBNull(reader["VendorCode"]))
                objEntity.VendorCode = (string)reader["VendorCode"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }
        #endregion Import_Items
        #region Railways
        internal static Railways Insert_Update_Railways_Factory(SqlDataReader reader)
        {
            Railways objRail = new Railways();
            objRail.cnt = (Int32)reader["cnt"];
            return objRail;
        }
        internal static Railways Get_Railways_Factory(SqlDataReader reader)
        {
            Railways objEntity = new Railways();

            if (!Convert.IsDBNull(reader["RailwayCode"]))
                objEntity.RailwayCode = (string)reader["RailwayCode"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }

        internal static Railways Delete_Railways_Factory(SqlDataReader reader)
        {
            Railways objEntity = new Railways();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Railways Edit_Railways_Factory(SqlDataReader reader)
        {
            Railways objEntity = new Railways();

            if (!Convert.IsDBNull(reader["RailwayCode"]))
                objEntity.RailwayCode = (string)reader["RailwayCode"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["Comments"]))
                objEntity.Comments = (string)reader["Comments"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }
        #endregion Railways
        #region Vendors
        internal static Vendors Insert_Update_Vendors_Factory(SqlDataReader reader)
        {
            Vendors objVend = new Vendors();
            objVend.cnt = (Int32)reader["cnt"];
            return objVend;
        }
        internal static Vendors Get_Vendors_Factory(SqlDataReader reader)
        {
            Vendors objEntity = new Vendors();

            if (!Convert.IsDBNull(reader["VendorCode"]))
                objEntity.VendorCode = (string)reader["VendorCode"];

            if (!Convert.IsDBNull(reader["VendorName"]))
                objEntity.VendorName = (string)reader["VendorName"];

            if (!Convert.IsDBNull(reader["ContactPersion"]))
                objEntity.ContactPersion = (string)reader["ContactPersion"];

            if (!Convert.IsDBNull(reader["PhoneNo"]))
                objEntity.PhoneNo = (string)reader["PhoneNo"];

            if (!Convert.IsDBNull(reader["StreetNo"]))
                objEntity.StreetNo = (string)reader["StreetNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (Int32)reader["State"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }

        internal static Vendors Delete_Vendors_Factory(SqlDataReader reader)
        {
            Vendors objEntity = new Vendors();
            if (Convert.IsDBNull(reader["result"]))
                objEntity.result = null;
            else
                objEntity.result = (string)reader["result"];

            return objEntity;
        }

        internal static Vendors Edit_Vendors_Factory(SqlDataReader reader)
        {
            Vendors objEntity = new Vendors();

            if (!Convert.IsDBNull(reader["VendorCode"]))
                objEntity.VendorCode = (string)reader["VendorCode"];

            if (!Convert.IsDBNull(reader["VendorName"]))
                objEntity.VendorName = (string)reader["VendorName"];

            if (!Convert.IsDBNull(reader["ContactPersion"]))
                objEntity.ContactPersion = (string)reader["ContactPersion"];

            if (!Convert.IsDBNull(reader["PhoneNo"]))
                objEntity.PhoneNo = (string)reader["PhoneNo"];

            if (!Convert.IsDBNull(reader["StreetNo"]))
                objEntity.StreetNo = (string)reader["StreetNo"];

            if (!Convert.IsDBNull(reader["Area"]))
                objEntity.Area = (string)reader["Area"];

            if (!Convert.IsDBNull(reader["City"]))
                objEntity.City = (string)reader["City"];

            if (!Convert.IsDBNull(reader["State"]))
                objEntity.State = (Int32)reader["State"];

            if (!Convert.IsDBNull(reader["Flag"]))
                objEntity.Flag = (string)reader["Flag"];

            if (!Convert.IsDBNull(reader["CreatedBy"]))
                objEntity.CreatedBy = (Int32)reader["CreatedBy"];

            if (!Convert.IsDBNull(reader["CreatedDate"]))
                objEntity.CreatedDate = (string)reader["CreatedDate"];

            if (!Convert.IsDBNull(reader["UpdatedBy"]))
                objEntity.UpdatedBy = (Int32)reader["UpdatedBy"];

            if (!Convert.IsDBNull(reader["UpdatedDate"]))
                objEntity.UpdatedDate = (string)reader["UpdatedDate"];

            return objEntity;
        }
        #endregion Vendors



    }
}
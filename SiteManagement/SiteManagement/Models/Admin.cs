using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml;
using SQLHelper;
using SqlHelp.Library.DataAccessLayer;
using System.Text;
namespace SiteManagement
{
    public class Admin
    {
        private string oConnectionString = ConfigurationManager.AppSettings["ConnectionStringStag"].ToString();
        public static string CreatedUrl;
        public static string OzSurl;
        public static string Username;
        public static string password;
        public static string mobile;
        public static string send;
        public static string message;
        public static string ozSender;
        public static string ozCdmasender;

        public string GetRandomString(Random rnd, int length, string charPool)
        {
            var rs = new StringBuilder();
            while (length-- > 0)
                rs.Append(charPool[(int)(rnd.NextDouble() * charPool.Length)]);
            return rs.ToString();
        }

        public List<LoginOP> AdminLogin(string Info)
        {
            return SqlHelpers.GetObjects<LoginOP>(Util.Env, CommandFactory.AdminLogin(Info), LoginObjectFactory.LoginItemFactory);
        }
        public List<Util.Result> SessionsInOut(string Info)
        {
            return SqlHelpers.GetObjects<Util.Result>(Util.Env, CommandFactory.SessionsInOut(Info), CommonObjectFactory.resultItemFactory);
        }
        public List<GetLinks> MainLinks(string Info)
        {
            return SqlHelpers.GetObjects<GetLinks>(Util.Env, CommandFactory.MainLinks(Info), CommonObjectFactory.MenuItemFactory);
        }
        public List<UserCreation> CreateOrUpdateUser(Int32 Uid, String Action, string Name, string Mobile, string PF, string ESI,
            string Aadhar, string Email, string Address, string IsInCharge, string IsAdmin, string UserName, string Password, 
            int CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            return SqlHelpers.GetObjects<UserCreation>(Util.Env, CommandFactory.CreateOrUpdateUser(Uid, Action, Name, Mobile, PF, ESI, Aadhar, Email, Address, IsInCharge,IsAdmin, UserName, Password, CreatedBy, Flag, LastUpdatedBy, DeletedBy, sesid), AdminObjectFactory.CreateUserItemFactory);
        }
        public List<UserDetails> GetUsers(Int32 Uid, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<UserDetails>(Util.Env, CommandFactory.GetUsers(Uid, Action, DeletedBy), AdminObjectFactory.DeleteUsersItemFactory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<UserDetails>(Util.Env, CommandFactory.GetUsers(Uid, Action, DeletedBy), AdminObjectFactory.EditUsersItemFactory);
            else
                return SqlHelpers.GetObjects<UserDetails>(Util.Env, CommandFactory.GetUsers(Uid, Action, DeletedBy), AdminObjectFactory.GetUsersItemFactory);
        }
        public List<LinksPremission> LinksPremission(string Info)
        {
            return SqlHelpers.GetObjects<LinksPremission>(Util.Env, CommandFactory.LinksPremission(Info), AdminObjectFactory.LinksPremissionItemFactory);
        }
        public List<Util.Result> UpdateLinksPremission(string Info)
        {
            return SqlHelpers.GetObjects<Util.Result>(Util.Env, CommandFactory.UpdateLinksPremission(Info), CommonObjectFactory.resultItemFactory);
        }
        public List<UsersData> UsersData(string Info)
        {
            return SqlHelpers.GetObjects<UsersData>(Util.Env, CommandFactory.UsersData(Info), AdminObjectFactory.UsersItemFactory);
        }
        public List<Userslogin> UserLoginRpt(string Info)
        {
            return SqlHelpers.GetObjects<Userslogin>(Util.Env, CommandFactory.UserLoginRpt(Info), AdminObjectFactory.GetUserLoginRptItemFactory);
        }

        public List<CheckUserID> CheckUserID(string Info)
        {
            return SqlHelpers.GetObjects<CheckUserID>(Util.Env, CommandFactory.CheckUserID(Info), AdminObjectFactory.CheckUserIDItemFactory);
        }

        public List<Util.Result> ChangePassword(string action, string regid, string thru, string oldpwd, string newpwd)
        {
            return SqlHelpers.GetObjects<Util.Result>(Util.Env, CommandFactory.ChangePassword(action, regid, thru, oldpwd, newpwd), CommonObjectFactory.resultItemFactory);
        }

        public List<Util.Result> UserLogin(string Info)
        {
            return SqlHelpers.GetObjects<Util.Result>(Util.Env, CommandFactory.UserLogin(Info), CommonObjectFactory.resultItemFactory);
        }

      
        #region "Unit"
        public List<Unit> CreateOrUpdateUnit(Int32 Unitid, string Action, string UnitName, string UnitDescr, Int32 CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            return SqlHelpers.GetObjects<Unit>(Util.Env, CommandFactory.CreateOrUpdateUnit(Unitid, Action, UnitName, UnitDescr, CreatedBy, Flag, LastUpdatedBy, DeletedBy, sesid), AdminObjectFactory.CreateUnitItemFactory);
        }


        public List<Unit> GetUnits(Int32 Unitid, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Unit>(Util.Env, CommandFactory.GetUnits(Unitid, Action, DeletedBy), AdminObjectFactory.DeleteUnitItemFactory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Unit>(Util.Env, CommandFactory.GetUnits(Unitid, Action, DeletedBy), AdminObjectFactory.EditUnitItemFactory);
            else
                return SqlHelpers.GetObjects<Unit>(Util.Env, CommandFactory.GetUnits(Unitid, Action, DeletedBy), AdminObjectFactory.GetUnitItemFactory);
        }

        #endregion "Unit"

        #region "Items"
        public string Insert_Item(string Info)
        {
            Items_IP obj = new Items_IP(Info);
            string ID = string.Empty;
            try
            {
                SqlParameter[] mSQLPrm = new SqlParameter[7];
                mSQLPrm[0] = new SqlParameter("@Item_Type", SqlDbType.VarChar, 250);
                mSQLPrm[0].Value = obj.Item_Type;
                mSQLPrm[1] = new SqlParameter("@Item_Descr", SqlDbType.VarChar, 250);
                mSQLPrm[1].Value = obj.Item_Descr;
                mSQLPrm[2] = new SqlParameter("@Unit", SqlDbType.VarChar, 250);
                mSQLPrm[2].Value = obj.Unit;
                mSQLPrm[3] = new SqlParameter("@CreatedBy", SqlDbType.VarChar, 250);
                mSQLPrm[3].Value = obj.CreatedBy;
                mSQLPrm[4] = new SqlParameter("@IsActive", SqlDbType.VarChar, 250);
                mSQLPrm[4].Value = obj.IsActive;
                mSQLPrm[5] = new SqlParameter("@Item_Name", SqlDbType.VarChar, 250);
                mSQLPrm[5].Value = obj.ItemName;
                mSQLPrm[6] = new SqlParameter("@Type", SqlDbType.VarChar, 250);
                mSQLPrm[6].Value = obj.Type;

                ID = SqlHelper.ExecuteScalar(oConnectionString, "InsertItem", mSQLPrm).ToString();
            }
            catch (Exception sqlEx)
            {


            }

            return ID;
        }

       

        public List<Items> GetItems(string BranchId, string ID, string Action)
        {
            DataSet ds = new DataSet();
            SqlParameter[] mSQLPrm = new SqlParameter[3];
            mSQLPrm[0] = new SqlParameter("@BranchId", SqlDbType.VarChar, 150);
            mSQLPrm[0].Value = BranchId;
            mSQLPrm[1] = new SqlParameter("@ID", SqlDbType.VarChar, 50);
            mSQLPrm[1].Value = ID;
            mSQLPrm[2] = new SqlParameter("@Action", SqlDbType.VarChar, 50);
            mSQLPrm[2].Value = Action;
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "GetItemDetails", ds, new string[] { "tbl" }, mSQLPrm);

            Items obj = new Items();
            List<Items> objList = new List<Items>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                objList.Add(new Items
                {
                    ID = Convert.ToString(dr["ID"]),
                    Item_Type = Convert.ToString(dr["Item_Type"]),
                    Item_Descr = Convert.ToString(dr["Item_Descr"]),
                    Unit = Convert.ToString(dr["Unit"]),
                    ItemName = Convert.ToString(dr["Item_Name"]),
                    IsActive = Convert.ToString(dr["IsActive"])

                });
            }

            return objList;
        }

        #endregion "Items"



        #region Expense
        public List<Expense> Insert_Update_Expense(Expense objEntity)
        {
            return SqlHelpers.GetObjects<Expense>(Util.Env, CommandFactory.Insert_Update_Expense(objEntity), AdminObjectFactory.Insert_Update_Expense_Factory);
        }


        public List<Expense> Get_Expense(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Expense>(Util.Env, CommandFactory.Get_Expense(ID, Action, DeletedBy), AdminObjectFactory.Delete_Expense_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Expense>(Util.Env, CommandFactory.Get_Expense(ID, Action, DeletedBy), AdminObjectFactory.Edit_Expense_Factory);
            else
                return SqlHelpers.GetObjects<Expense>(Util.Env, CommandFactory.Get_Expense(ID, Action, DeletedBy), AdminObjectFactory.Get_Expense_Factory);
        }
        #endregion Expense

        #region Sites
        public List<Sites> Insert_Update_Sites(Sites objEntity)
        {
            return SqlHelpers.GetObjects<Sites>(Util.Env, CommandFactory.Insert_Update_Sites(objEntity), AdminObjectFactory.Insert_Update_Sites_Factory);
        }


        public List<Sites> Get_Sites(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Sites>(Util.Env, CommandFactory.Get_Sites(ID, Action, DeletedBy), AdminObjectFactory.Delete_Sites_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Sites>(Util.Env, CommandFactory.Get_Sites(ID, Action, DeletedBy), AdminObjectFactory.Edit_Sites_Factory);
            else
                return SqlHelpers.GetObjects<Sites>(Util.Env, CommandFactory.Get_Sites(ID, Action, DeletedBy), AdminObjectFactory.Get_Sites_Factory);
        }
        #endregion Sites


        #region Daily_Labour_Miss
        public List<Daily_Labour_Miss> Insert_Update_Daily_Labour_Miss(Daily_Labour_Miss objEntity)
        {
            return SqlHelpers.GetObjects<Daily_Labour_Miss>(Util.Env, CommandFactory.Insert_Update_Daily_Labour_Miss(objEntity), AdminObjectFactory.Insert_Update_Daily_Labour_Miss_Factory);
        }


        public List<Daily_Labour_Miss> Get_Daily_Labour_Miss(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Daily_Labour_Miss>(Util.Env, CommandFactory.Get_Daily_Labour_Miss(ID, Action, DeletedBy), AdminObjectFactory.Delete_Daily_Labour_Miss_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Daily_Labour_Miss>(Util.Env, CommandFactory.Get_Daily_Labour_Miss(ID, Action, DeletedBy), AdminObjectFactory.Edit_Daily_Labour_Miss_Factory);
            else
                return SqlHelpers.GetObjects<Daily_Labour_Miss>(Util.Env, CommandFactory.Get_Daily_Labour_Miss(ID, Action, DeletedBy), AdminObjectFactory.Get_Daily_Labour_Miss_Factory);
        }

        public List<Daily_Labour_Miss> Get_Daily_Labour_MissRpt(string fromdate, string todate, string EmpID)
        {
            List<Daily_Labour_Miss> objList = new List<Daily_Labour_Miss>();
            
                DataSet dsItems = new DataSet();
                SqlParameter[] mSQLPrm1 = new SqlParameter[3];
                mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
                mSQLPrm1[0].Value = fromdate;
                mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
                mSQLPrm1[1].Value = todate;
                mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
                mSQLPrm1[2].Value =Convert.ToInt32(EmpID);
                SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_Daily_Labour_MissRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
                foreach (DataRow row1 in dsItems.Tables[0].Rows)
                {
                    Daily_Labour_Miss objRecord = new Daily_Labour_Miss();
                    objRecord.ID =Convert.ToInt32(row1["ID"]);
                    objRecord.ExpenseType = row1["ExpenseType"].ToString();
                    objRecord.SiteName = row1["SiteName"].ToString();
                    if (row1["NoofLabours"] != DBNull.Value)
                    objRecord.NoofLabours =Convert.ToInt32(row1["NoofLabours"]);
                    objRecord.Reason = row1["Reason"].ToString();
                    objRecord.Amount =Convert.ToDecimal(row1["Amount"]);
                    objRecord.Date = row1["Dated"].ToString();
                    objRecord.Comments = row1["Comments"].ToString();
                    objRecord.FileName = row1["FileName"].ToString();
                    objRecord.CreatedByName = row1["CreatedByName"].ToString();
                    objList.Add(objRecord);
                }

                return objList;
        }

        #endregion Daily_Labour_Miss


        #region DailyPurchase
        public List<DailyPurchase> Insert_Update_DailyPurchase(DailyPurchase objEntity)
        {
            return SqlHelpers.GetObjects<DailyPurchase>(Util.Env, CommandFactory.Insert_Update_DailyPurchase(objEntity), AdminObjectFactory.Insert_Update_DailyPurchase_Factory);
        }


        public List<DailyPurchase> Get_DailyPurchase(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<DailyPurchase>(Util.Env, CommandFactory.Get_DailyPurchase(ID, Action, DeletedBy), AdminObjectFactory.Delete_DailyPurchase_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<DailyPurchase>(Util.Env, CommandFactory.Get_DailyPurchase(ID, Action, DeletedBy), AdminObjectFactory.Edit_DailyPurchase_Factory);
            else
                return SqlHelpers.GetObjects<DailyPurchase>(Util.Env, CommandFactory.Get_DailyPurchase(ID, Action, DeletedBy), AdminObjectFactory.Get_DailyPurchase_Factory);
        }

        public List<DailyPurchase> Get_DailyPurchaseRpt(string fromdate, string todate, string EmpID)
        {
            List<DailyPurchase> objList = new List<DailyPurchase>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[3];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_DailyPurchaseRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                DailyPurchase objRecord = new DailyPurchase();
                objRecord.ID = Convert.ToInt32(row1["ID"]);
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.ItemType = row1["Item_Type"].ToString();
                objRecord.InvoiceNo = Convert.ToString(row1["InvoiceNo"]);
                objRecord.ItemName = row1["Item_Name"].ToString();
                objRecord.Amount = Convert.ToDecimal(row1["Amount"]);
                objRecord.Date = row1["Dated"].ToString();
                objRecord.Comments = row1["Comments"].ToString();
                objRecord.FileName = row1["FileName"].ToString();
                objRecord.CreatedByName = row1["CreatedByName"].ToString();
                objList.Add(objRecord);
            }

            return objList;
        }

        #endregion DailyPurchase



        #region Labour_Payments
        public List<Labour_Payments> Insert_Update_Labour_Payments(Labour_Payments objEntity)
        {
            return SqlHelpers.GetObjects<Labour_Payments>(Util.Env, CommandFactory.Insert_Update_Labour_Payments(objEntity), AdminObjectFactory.Insert_Update_Labour_Payments_Factory);
        }


        public List<Labour_Payments> Get_Labour_Payments(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Labour_Payments>(Util.Env, CommandFactory.Get_Labour_Payments(ID, Action, DeletedBy), AdminObjectFactory.Delete_Labour_Payments_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Labour_Payments>(Util.Env, CommandFactory.Get_Labour_Payments(ID, Action, DeletedBy), AdminObjectFactory.Edit_Labour_Payments_Factory);
            else
                return SqlHelpers.GetObjects<Labour_Payments>(Util.Env, CommandFactory.Get_Labour_Payments(ID, Action, DeletedBy), AdminObjectFactory.Get_Labour_Payments_Factory);
        }

        public List<Labour_Payments> Get_Labour_PaymentsRpt(string fromdate, string todate, string EmpID)
        {
            List<Labour_Payments> objList = new List<Labour_Payments>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[3];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_Labour_PaymentsRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                Labour_Payments objRecord = new Labour_Payments();
                objRecord.ID = Convert.ToInt32(row1["ID"]);
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.EmpName = row1["EmpName"].ToString();
                objRecord.PaymentFor = Convert.ToString(row1["PaymentFor"]);
                objRecord.Amount = Convert.ToDecimal(row1["Amount"]);
                objRecord.Dated = row1["Dated"].ToString();
                objRecord.Comments = row1["Comments"].ToString();
                objRecord.CreatedByName = row1["CreatedByName"].ToString();
                objList.Add(objRecord);
            }

            return objList;
        }
        #endregion Labour_Payments


        #region Req_Money
        public List<Req_Money> Insert_Update_Req_Money(Req_Money objEntity)
        {
            return SqlHelpers.GetObjects<Req_Money>(Util.Env, CommandFactory.Insert_Update_Req_Money(objEntity), AdminObjectFactory.Insert_Update_Req_Money_Factory);
        }


        public List<Req_Money> Get_Req_Money(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Req_Money>(Util.Env, CommandFactory.Get_Req_Money(ID, Action, DeletedBy), AdminObjectFactory.Delete_Req_Money_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Req_Money>(Util.Env, CommandFactory.Get_Req_Money(ID, Action, DeletedBy), AdminObjectFactory.Edit_Req_Money_Factory);
            else
                return SqlHelpers.GetObjects<Req_Money>(Util.Env, CommandFactory.Get_Req_Money(ID, Action, DeletedBy), AdminObjectFactory.Get_Req_Money_Factory);
        }

        public List<Req_Money> Get_Req_MoneyRpt(string fromdate, string todate, string EmpID)
        {
            List<Req_Money> objList = new List<Req_Money>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[3];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_Req_MoneyRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                Req_Money objRecord = new Req_Money();
                objRecord.ID = Convert.ToInt32(row1["ID"]);
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.Expense_Type = row1["Expense_Type"].ToString();
                objRecord.ApprovedStatus = Convert.ToString(row1["ApprovedStatus"]);
                objRecord.Amount = Convert.ToDecimal(row1["Amount"]);
                objRecord.CreatedDate = row1["CreatedDate"].ToString();
                objRecord.Comments = row1["Comments"].ToString();
                objRecord.CreatedByName = row1["CreatedByName"].ToString();
                objList.Add(objRecord);
            }

            return objList;
        }
        #endregion Req_Money


        #region Site_Progress
        public List<Site_Progress> Insert_Update_Site_Progress(Site_Progress objEntity)
        {
            return SqlHelpers.GetObjects<Site_Progress>(Util.Env, CommandFactory.Insert_Update_Site_Progress(objEntity), AdminObjectFactory.Insert_Update_Site_Progress_Factory);
        }


        public List<Site_Progress> Get_Site_Progress(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Site_Progress>(Util.Env, CommandFactory.Get_Site_Progress(ID, Action, DeletedBy), AdminObjectFactory.Delete_Site_Progress_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Site_Progress>(Util.Env, CommandFactory.Get_Site_Progress(ID, Action, DeletedBy), AdminObjectFactory.Edit_Site_Progress_Factory);
            else
                return SqlHelpers.GetObjects<Site_Progress>(Util.Env, CommandFactory.Get_Site_Progress(ID, Action, DeletedBy), AdminObjectFactory.Get_Site_Progress_Factory);
        }

        public List<Site_Progress> Get_Site_ProgressRpt(string fromdate, string todate, string EmpID)
        {
            List<Site_Progress> objList = new List<Site_Progress>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[3];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_Site_ProgressRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                Site_Progress objRecord = new Site_Progress();
                objRecord.ID = Convert.ToInt32(row1["ID"]);
                objRecord.SiteID =Convert.ToInt32(row1["SiteID"]);
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.Perm_Labours = Convert.ToInt32(row1["Perm_Labours"]);
                objRecord.Cont_Labours = Convert.ToInt32(row1["Cont_Labours"]);
                objRecord.Daily_Labours = Convert.ToInt32(row1["Daily_Labours"]);
                objRecord.Dated = row1["Dated"].ToString();
                objRecord.Comments = row1["Comments"].ToString();
                objRecord.FileName = row1["FileName"].ToString();
                objRecord.CreatedByName = row1["CreatedByName"].ToString();
                objList.Add(objRecord);
            }

            return objList;
        }

        #endregion Site_Progress

        #region Dashboard

        public List<DB_SitePogress> DB_SitePogressRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            List<DB_SitePogress> objList = new List<DB_SitePogress>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[4];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            mSQLPrm1[3] = new SqlParameter("@SiteID", SqlDbType.Int, 10);
            mSQLPrm1[3].Value = Convert.ToInt32(SiteID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "DB_SitePogressRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                DB_SitePogress objRecord = new DB_SitePogress();
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.Permanent = Convert.ToString(row1["Permanent"]);
                objRecord.Contract = Convert.ToString(row1["Contract"]);
                objRecord.Daily = Convert.ToString(row1["Daily"]);
                objList.Add(objRecord);
            }

            return objList;
        }

        public List<DB_SiteExpenses> DB_SiteExpensesRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            List<DB_SiteExpenses> objList = new List<DB_SiteExpenses>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[4];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            mSQLPrm1[3] = new SqlParameter("@SiteID", SqlDbType.Int, 10);
            mSQLPrm1[3].Value = Convert.ToInt32(SiteID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "DB_SiteExpensesRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                DB_SiteExpenses objRecord = new DB_SiteExpenses();
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.Purchase = Convert.ToString(row1["Purchase"]);
                objRecord.Miscellaneous = Convert.ToString(row1["Miscellaneous"]);
                objRecord.Labour = Convert.ToString(row1["Labour"]);
                objList.Add(objRecord);
            }

            return objList;
        }

        public List<DB_LabourPayments> DB_LabourPaymentsRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            List<DB_LabourPayments> objList = new List<DB_LabourPayments>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[4];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            mSQLPrm1[3] = new SqlParameter("@SiteID", SqlDbType.Int, 10);
            mSQLPrm1[3].Value = Convert.ToInt32(SiteID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "DB_LabourPaymentsRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                DB_LabourPayments objRecord = new DB_LabourPayments();
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.EmployeesCnt = Convert.ToString(row1["EmployeesCnt"]);
                objRecord.PayemtAmount = Convert.ToString(row1["PayemtAmount"]);
                objList.Add(objRecord);
            }

            return objList;
        }

        public List<DB_PendingRequests> DB_PendingRequestsRpt(string fromdate, string todate, string EmpID, string SiteID)
        {
            List<DB_PendingRequests> objList = new List<DB_PendingRequests>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[4];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            mSQLPrm1[3] = new SqlParameter("@SiteID", SqlDbType.Int, 10);
            mSQLPrm1[3].Value = Convert.ToInt32(SiteID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "DB_PendingRequestsRpt", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                DB_PendingRequests objRecord = new DB_PendingRequests();
                objRecord.SiteName = row1["SiteName"].ToString();
                objRecord.RequestedBy = Convert.ToString(row1["RequestedBy"]);
                objRecord.RequestedDate = Convert.ToString(row1["RequestedDate"]);
                objRecord.Amount = Convert.ToString(row1["Amount"]);
                objList.Add(objRecord);
            }

            return objList;
        }


        #endregion Dashboard


        #region PO
        public List<PO> Insert_Update_PO(PO objEntity)
        {
            return SqlHelpers.GetObjects<PO>(Util.Env, CommandFactory.Insert_Update_PO(objEntity), AdminObjectFactory.Insert_Update_PO_Factory);
        }


        public List<PO> Get_PO(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<PO>(Util.Env, CommandFactory.Get_PO(ID, Action, DeletedBy), AdminObjectFactory.Delete_PO_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<PO>(Util.Env, CommandFactory.Get_PO(ID, Action, DeletedBy), AdminObjectFactory.Edit_PO_Factory);
            else
                return SqlHelpers.GetObjects<PO>(Util.Env, CommandFactory.Get_PO(ID, Action, DeletedBy), AdminObjectFactory.Get_PO_Factory);
        }

        public List<PO> Get_PORpt(string fromdate, string todate, string EmpID)
        {
            List<PO> objList = new List<PO>();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[3];
            mSQLPrm1[0] = new SqlParameter("@fromdate", SqlDbType.VarChar, 100);
            mSQLPrm1[0].Value = fromdate;
            mSQLPrm1[1] = new SqlParameter("@todate", SqlDbType.VarChar, 100);
            mSQLPrm1[1].Value = todate;
            mSQLPrm1[2] = new SqlParameter("@EmpID", SqlDbType.Int, 10);
            mSQLPrm1[2].Value = Convert.ToInt32(EmpID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_PORptGrid", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                PO objRecord = new PO();
                objRecord.POID = Convert.ToInt32(row1["POID"]);
                objRecord.MainRef = Convert.ToString(row1["MainRef"]);
                objRecord.Dated = row1["Dated"].ToString();
                objRecord.ExpectedDeliveryDate = row1["ExpectedDeliveryDate"].ToString();
                objRecord.MainContact = Convert.ToString(row1["MainContact"]);
                objRecord.Mobile = Convert.ToString(row1["Mobile"]);
                objRecord.EmailID = row1["EmailID"].ToString();
                objRecord.Subject = row1["Subject"].ToString();
                objRecord.CreatedByName = row1["CreatedByName"].ToString();
                objList.Add(objRecord);
            }

            return objList;
        }

        public PO Get_PORptByID(string POID)
        {
            PO objList = new PO();

            DataSet dsItems = new DataSet();
            SqlParameter[] mSQLPrm1 = new SqlParameter[1];
            mSQLPrm1[0] = new SqlParameter("@POID", SqlDbType.Int, 100);
            mSQLPrm1[0].Value =Convert.ToInt32(POID);
            SqlHelper.FillDataset(oConnectionString, CommandType.StoredProcedure, "Get_POBYID", dsItems, new string[] { "tbl" }, mSQLPrm1);
            foreach (DataRow row1 in dsItems.Tables[0].Rows)
            {
                
                objList.MainRef = Convert.ToString(row1["MainRef"]);
                objList.Dated = row1["Dated"].ToString();
                objList.Name = row1["Name"].ToString();
                objList.ShopNo = row1["ShopNo"].ToString();
                objList.Area = row1["Area"].ToString();
                objList.City = row1["City"].ToString();
                objList.State = row1["State"].ToString();
                objList.PinCode =Convert.ToInt32(row1["PinCode"]);
                objList.GSTINNO = row1["GSTINNO"].ToString();
                objList.Subject = row1["Subject"].ToString();
                objList.RefNo = row1["RefNo"].ToString();
                objList.Comments = row1["Comments"].ToString();
                
            }

            return objList;
        }

        #endregion PO


        #region PO_Items
        public List<PO_Items> Insert_Update_PO_Items(PO_Items objEntity)
        {
            return SqlHelpers.GetObjects<PO_Items>(Util.Env, CommandFactory.Insert_Update_PO_Items(objEntity), AdminObjectFactory.Insert_Update_PO_Items_Factory);
        }


        public List<PO_Items> Get_PO_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<PO_Items>(Util.Env, CommandFactory.Get_PO_Items(ID, Action, DeletedBy), AdminObjectFactory.Delete_PO_Items_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<PO_Items>(Util.Env, CommandFactory.Get_PO_Items(ID, Action, DeletedBy), AdminObjectFactory.Edit_PO_Items_Factory);
            else
                return SqlHelpers.GetObjects<PO_Items>(Util.Env, CommandFactory.Get_PO_Items(ID, Action, DeletedBy), AdminObjectFactory.Get_PO_Items_Factory);
        }
        #endregion PO_Items


        #region PO_Term_Conditions
        public List<PO_Term_Conditions> Insert_Update_PO_Term_Conditions(PO_Term_Conditions objEntity)
        {
            return SqlHelpers.GetObjects<PO_Term_Conditions>(Util.Env, CommandFactory.Insert_Update_PO_Term_Conditions(objEntity), AdminObjectFactory.Insert_Update_PO_Term_Conditions_Factory);
        }


        public List<PO_Term_Conditions> Get_PO_Term_Conditions(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<PO_Term_Conditions>(Util.Env, CommandFactory.Get_PO_Term_Conditions(ID, Action, DeletedBy), AdminObjectFactory.Delete_PO_Term_Conditions_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<PO_Term_Conditions>(Util.Env, CommandFactory.Get_PO_Term_Conditions(ID, Action, DeletedBy), AdminObjectFactory.Edit_PO_Term_Conditions_Factory);
            else
                return SqlHelpers.GetObjects<PO_Term_Conditions>(Util.Env, CommandFactory.Get_PO_Term_Conditions(ID, Action, DeletedBy), AdminObjectFactory.Get_PO_Term_Conditions_Factory);
        }
        #endregion PO_Term_Conditions


        #region Bankers
        public List<Bankers> Insert_Update_Bankers(Bankers objEntity)
        {
            return SqlHelpers.GetObjects<Bankers>(Util.Env, CommandFactory.Insert_Update_Bankers(objEntity), AdminObjectFactory.Insert_Update_Bankers_Factory);
        }


        public List<Bankers> Get_Bankers(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Bankers>(Util.Env, CommandFactory.Get_Bankers(ID, Action, DeletedBy), AdminObjectFactory.Delete_Bankers_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Bankers>(Util.Env, CommandFactory.Get_Bankers(ID, Action, DeletedBy), AdminObjectFactory.Edit_Bankers_Factory);
            else
                return SqlHelpers.GetObjects<Bankers>(Util.Env, CommandFactory.Get_Bankers(ID, Action, DeletedBy), AdminObjectFactory.Get_Bankers_Factory);
        }
        #endregion Bankers


        #region Customers
        public List<Customers> Insert_Update_Customers(Customers objEntity)
        {
            return SqlHelpers.GetObjects<Customers>(Util.Env, CommandFactory.Insert_Update_Customers(objEntity), AdminObjectFactory.Insert_Update_Customers_Factory);
        }


        public List<Customers> Get_Customers(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Customers>(Util.Env, CommandFactory.Get_Customers(ID, Action, DeletedBy), AdminObjectFactory.Delete_Customers_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Customers>(Util.Env, CommandFactory.Get_Customers(ID, Action, DeletedBy), AdminObjectFactory.Edit_Customers_Factory);
            else
                return SqlHelpers.GetObjects<Customers>(Util.Env, CommandFactory.Get_Customers(ID, Action, DeletedBy), AdminObjectFactory.Get_Customers_Factory);
        }
        #endregion Customers


        #region Import_Items
        public List<Import_Items> Insert_Update_Import_Items(Import_Items objEntity)
        {
            return SqlHelpers.GetObjects<Import_Items>(Util.Env, CommandFactory.Insert_Update_Import_Items(objEntity), AdminObjectFactory.Insert_Update_Import_Items_Factory);
        }


        public List<Import_Items> Get_Import_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Import_Items>(Util.Env, CommandFactory.Get_Import_Items(ID, Action, DeletedBy), AdminObjectFactory.Delete_Import_Items_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Import_Items>(Util.Env, CommandFactory.Get_Import_Items(ID, Action, DeletedBy), AdminObjectFactory.Edit_Import_Items_Factory);
            else
                return SqlHelpers.GetObjects<Import_Items>(Util.Env, CommandFactory.Get_Import_Items(ID, Action, DeletedBy), AdminObjectFactory.Get_Import_Items_Factory);
        }
        #endregion Import_Items


        #region Project
        public List<Project> Insert_Update_Project(Project objEntity)
        {
            return SqlHelpers.GetObjects<Project>(Util.Env, CommandFactory.Insert_Update_Project(objEntity), AdminObjectFactory.Insert_Update_Project_Factory);
        }


        public List<Project> Get_Project(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Project>(Util.Env, CommandFactory.Get_Project(ID, Action, DeletedBy), AdminObjectFactory.Delete_Project_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Project>(Util.Env, CommandFactory.Get_Project(ID, Action, DeletedBy), AdminObjectFactory.Edit_Project_Factory);
            else
                return SqlHelpers.GetObjects<Project>(Util.Env, CommandFactory.Get_Project(ID, Action, DeletedBy), AdminObjectFactory.Get_Project_Factory);
        }
        #endregion Project


        #region Railways
        public List<Railways> Insert_Update_Railways(Railways objEntity)
        {
            return SqlHelpers.GetObjects<Railways>(Util.Env, CommandFactory.Insert_Update_Railways(objEntity), AdminObjectFactory.Insert_Update_Railways_Factory);
        }


        public List<Railways> Get_Railways(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Railways>(Util.Env, CommandFactory.Get_Railways(ID, Action, DeletedBy), AdminObjectFactory.Delete_Railways_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Railways>(Util.Env, CommandFactory.Get_Railways(ID, Action, DeletedBy), AdminObjectFactory.Edit_Railways_Factory);
            else
                return SqlHelpers.GetObjects<Railways>(Util.Env, CommandFactory.Get_Railways(ID, Action, DeletedBy), AdminObjectFactory.Get_Railways_Factory);
        }
        #endregion Railways

        #region Vendors
        public List<Vendors> Insert_Update_Vendors(Vendors objEntity)
        {
            return SqlHelpers.GetObjects<Vendors>(Util.Env, CommandFactory.Insert_Update_Vendors(objEntity), AdminObjectFactory.Insert_Update_Vendors_Factory);
        }


        public List<Vendors> Get_Vendors(Int32 ID, string Action, Int32 DeletedBy)
        {
            if (Action == "Delete" || Action == "Delete1")
                return SqlHelpers.GetObjects<Vendors>(Util.Env, CommandFactory.Get_Vendors(ID, Action, DeletedBy), AdminObjectFactory.Delete_Vendors_Factory);
            else if (Action == "Edit" || Action == "Edit1")
                return SqlHelpers.GetObjects<Vendors>(Util.Env, CommandFactory.Get_Vendors(ID, Action, DeletedBy), AdminObjectFactory.Edit_Vendors_Factory);
            else
                return SqlHelpers.GetObjects<Vendors>(Util.Env, CommandFactory.Get_Vendors(ID, Action, DeletedBy), AdminObjectFactory.Get_Vendors_Factory);
        }
        #endregion Vendors


    }
     
}
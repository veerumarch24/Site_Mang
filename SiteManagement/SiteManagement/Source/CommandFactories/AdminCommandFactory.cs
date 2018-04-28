using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;

namespace SiteManagement
{
    public partial class CommandFactory
    {
        internal static SqlCommand AdminLogin(string Info)
        {
            LoginIP login = new LoginIP(Info);
            var parameters = new[] 
            {
                CreateParameter("@username", SqlDbType.VarChar, login.username),   
                CreateParameter("@password", SqlDbType.VarChar, Util.Encrypt(login.password))                                
            };
            return CreateCommand("AdminLogin_SP", parameters);
        }
        internal static SqlCommand SessionsInOut(string Info)
        {
            SessionsInOutIP sessions = new SessionsInOutIP(Info);
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            // Get the IP
            string myIP = Util.GetIPAddress();//Dns.GetHostByName(hostName).AddressList[0].ToString();
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, sessions.action),
                CreateParameter("@loginid", SqlDbType.Int, sessions.loginid),
                CreateParameter("@sesid", SqlDbType.VarChar, sessions.sesid),
                CreateParameter("@ipaddress", SqlDbType.VarChar, myIP),
                CreateParameter("@systemname", SqlDbType.VarChar, hostName),
                CreateParameter("@usertype", SqlDbType.VarChar, sessions.usertype),                                           
            };

            return CreateCommand("SessionsInOut_SP", parameters);
        }
        internal static SqlCommand MainLinks(string Info)
        {
            GetLinksIP getlinks = new GetLinksIP(Info);
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, getlinks.action) ,               
                CreateParameter("@Id", SqlDbType.VarChar, getlinks.Id)                
            };
            return CreateCommand("GetLinks_SP", parameters);
        }
        internal static SqlCommand CreateOrUpdateUser(Int32 Uid, String Action, string Name, string Mobile, string PF, string ESI,
            string Aadhar, string Email, string Address, string IsInCharge, string IsAdmin, string UserName, string Password,
            int CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
            {  
                CreateParameter("@Uid", SqlDbType.Int,Convert.ToInt32(Uid)),
                CreateParameter("@Action", SqlDbType.VarChar,Action),                             
                CreateParameter("@Name", SqlDbType.VarChar,Name) ,     
                CreateParameter("@Mobile", SqlDbType.VarChar,Mobile),
                CreateParameter("@PF", SqlDbType.VarChar,PF),
                CreateParameter("@ESI", SqlDbType.VarChar,ESI),
                CreateParameter("@Aadhar", SqlDbType.VarChar,Aadhar),
                CreateParameter("@Email", SqlDbType.VarChar, Email),
                CreateParameter("@Address", SqlDbType.VarChar, Address),
                CreateParameter("@IsInCharge", SqlDbType.VarChar, IsInCharge),
                CreateParameter("@IsAdmin", SqlDbType.VarChar, IsAdmin),
                CreateParameter("@UserName", SqlDbType.VarChar, UserName),
                CreateParameter("@PassWord", SqlDbType.VarChar, Password),
                CreateParameter("@CreatedBy", SqlDbType.Int, Convert.ToInt32(CreatedBy)),                
                CreateParameter("@sesid",SqlDbType.VarChar, sesid),
                CreateParameter("@Ipaddress",SqlDbType.VarChar,ip),
                CreateParameter("@Flag",SqlDbType.VarChar,Flag),
                CreateParameter("@LastUpdatedby",SqlDbType.Int,Convert.ToInt32(LastUpdatedBy)),
                CreateParameter("@Deletedby",SqlDbType.Int,Convert.ToInt32(DeletedBy))

                
            };
            return CreateCommand("INUPDATEUsers_SP", parameters);
        }


        internal static SqlCommand GetUsers(Int32 Uid, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
            {
                 CreateParameter("@Uid", SqlDbType.VarChar, Uid) ,
                 CreateParameter("@Action", SqlDbType.VarChar, Action),
                 CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
            };
            return CreateCommand("UsersReport_Sp", parameters);
        }

        internal static SqlCommand LinksPremission(string Info)
        {
            LinksPremissionIP linksPremission = new LinksPremissionIP(Info);
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, linksPremission.action ) ,             
                CreateParameter("@uid", SqlDbType.VarChar, linksPremission.uid),
                CreateParameter("@usertype", SqlDbType.VarChar, linksPremission.usertype )               
            };
            return CreateCommand("LinksPremission_SP", parameters);
        }
        internal static SqlCommand UpdateLinksPremission(string Info)
        {
            UPLinksPremissionIP upLinksPremission = new UPLinksPremissionIP(Info);
            var parameters = new[]
            {
                CreateParameter("@uid", SqlDbType.VarChar, upLinksPremission.uid),
                CreateParameter("@usertype", SqlDbType.VarChar, upLinksPremission.usertype ) ,
                CreateParameter("@lids", SqlDbType.VarChar, upLinksPremission.lids ) ,
                CreateParameter("@Updatedby", SqlDbType.VarChar, upLinksPremission.Updatedby ) ,
                CreateParameter("@sessid", SqlDbType.VarChar, upLinksPremission.sessid )            
            };
            return CreateCommand("UpdateLinksPremission_SP", parameters);
        }
        internal static SqlCommand UsersData(string Info)
        {
            UsersDataIP usersData = new UsersDataIP(Info);
            var parameters = new[]
            {
                CreateParameter("@UserType", SqlDbType.VarChar, usersData.UserType),
            };
            return CreateCommand("GetUserByUsertype_Sp", parameters);
        }
        internal static SqlCommand UserLoginRpt(string Info)
        {
            UsersloginIP userslogin = new UsersloginIP(Info);
            var parameters = new[]
            {
                CreateParameter("@utype", SqlDbType.VarChar, userslogin.utype),
                CreateParameter("@fromdate", SqlDbType.VarChar, userslogin.fromdate),
                CreateParameter("@todate", SqlDbType.VarChar, userslogin.todate),
                CreateParameter("@uid", SqlDbType.Int, userslogin.uid)              
            };
            return CreateCommand("GetUsersLogin_Sp", parameters);
        }
        internal static SqlCommand CheckUserID(string Info)
        {
            CheckUserIDIP CheckUserID = new CheckUserIDIP(Info);
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, CheckUserID.action) ,               
                CreateParameter("@idno", SqlDbType.VarChar, CheckUserID.idno)                
            };
            return CreateCommand("CheckUserID_Sp", parameters);
        }
        internal static SqlCommand UserLogin(string Info)
        {
            UserLoginIP UserLogin = new UserLoginIP(Info);
            string hostName = Dns.GetHostName(); // Retrive the Name of HOST
            // Get the IP
            string myIP = GetIPAddress();//Dns.GetHostByName(hostName).AddressList[0].ToString();
            var parameters = new[]
            {
                CreateParameter("@action", SqlDbType.VarChar, UserLogin.action),
                CreateParameter("@uid", SqlDbType.Int, UserLogin.uid),
                CreateParameter("@sesid", SqlDbType.VarChar, UserLogin.sesid),
                CreateParameter("@ipaddress", SqlDbType.VarChar, UserLogin.myIP),
                CreateParameter("@systemname", SqlDbType.VarChar, UserLogin.hostName),
                CreateParameter("@usertype", SqlDbType.VarChar, UserLogin.usertype),                                           
            };

            return CreateCommand("Userlogin_SP", parameters);
        }

        private static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string ipAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipAddress))
            {
                string[] addresses = ipAddress.Split(',');
                if (addresses.Length != 0)
                {
                    return addresses[0];
                }
            }
            return context.Request.ServerVariables["REMOTE_ADDR"];
        }

        internal static SqlCommand CreateOrUpdateUnit(Int32 Unitid, string Action, string UnitName, string UnitDescr, Int32 CreatedBy, String Flag, Int32 LastUpdatedBy, Int32 DeletedBy, string sesid)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
            {  
                CreateParameter("@Unitid", SqlDbType.Int,Convert.ToInt32(Unitid)),
                CreateParameter("@Action", SqlDbType.VarChar,Action),  
                CreateParameter("@UnitName", SqlDbType.VarChar,UnitName),                             
                CreateParameter("@UnitDescr", SqlDbType.VarChar,UnitDescr) ,              
                CreateParameter("@CreatedBy", SqlDbType.Int, Convert.ToInt32(CreatedBy)),                
                CreateParameter("@sesid",SqlDbType.VarChar, sesid),
                CreateParameter("@Ipaddress",SqlDbType.VarChar,ip),
                CreateParameter("@Flag",SqlDbType.VarChar,Flag),
                CreateParameter("@LastUpdatedby",SqlDbType.Int,Convert.ToInt32(LastUpdatedBy)),
                CreateParameter("@Deletedby",SqlDbType.Int,Convert.ToInt32(DeletedBy))
            };
            return CreateCommand("INUPDATE_Unit_SP", parameters);
        }


        internal static SqlCommand GetUnits(Int32 Unitid, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
            {
                 CreateParameter("@Unitid", SqlDbType.Int, Unitid) ,
                 CreateParameter("@Action", SqlDbType.VarChar, Action),
                 CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
            };
            return CreateCommand("UnitsReport_Sp", parameters);
        }
        
        #region Expense
        internal static SqlCommand Insert_Update_Expense(Expense objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),

					CreateParameter("@ExpID",SqlDbType.Int, Convert.ToInt32(objEntity.ExpID)),
					CreateParameter("@ExpenseType",SqlDbType.VarChar, objEntity.ExpenseType),
					CreateParameter("@ExpenseDescr",SqlDbType.VarChar, objEntity.ExpenseDescr),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
			};
            return CreateCommand("ins_Expense", parameters);
        }

        internal static SqlCommand Get_Expense(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Expense_Rpt", parameters);
        }
        #endregion Expense


        #region Sites
        internal static SqlCommand Insert_Update_Sites(Sites objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@SiteID",SqlDbType.Int, Convert.ToInt32(objEntity.SiteID)),
					CreateParameter("@SiteName",SqlDbType.VarChar, objEntity.SiteName),
					CreateParameter("@SiteDescr",SqlDbType.VarChar, objEntity.SiteDescr),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@Incharge",SqlDbType.Int, Convert.ToInt32(objEntity.Incharge)),
					CreateParameter("@StartDate",SqlDbType.VarChar, objEntity.StartDate),
					CreateParameter("@EndDate",SqlDbType.VarChar, objEntity.EndDate),
					CreateParameter("@SiteAddress",SqlDbType.VarChar, objEntity.SiteAddress),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
			};
            return CreateCommand("ins_Sites", parameters);
        }

        internal static SqlCommand Get_Sites(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Sites_Rpt", parameters);
        }
        #endregion Sites

        #region Daily_Labour_Miss
        internal static SqlCommand Insert_Update_Daily_Labour_Miss(Daily_Labour_Miss objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@ExpenseTypeID",SqlDbType.Int, objEntity.ExpenseTypeID),
					CreateParameter("@SiteID",SqlDbType.Int, objEntity.SiteID),             
					CreateParameter("@NoofLabours",SqlDbType.Int,objEntity.NoofLabours),
					CreateParameter("@Reason",SqlDbType.VarChar, objEntity.Reason),
					CreateParameter("@Amount",SqlDbType.Decimal, objEntity.Amount),
					CreateParameter("@Date",SqlDbType.VarChar, objEntity.Date),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@FileName",SqlDbType.VarChar, objEntity.FileName),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
			};
            return CreateCommand("ins_Daily_Labour_Miss", parameters);
        }

        internal static SqlCommand Get_Daily_Labour_Miss(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Daily_Labour_Miss_Rpt", parameters);
        }
        #endregion Daily_Labour_Miss


        #region DailyPurchase
        internal static SqlCommand Insert_Update_DailyPurchase(DailyPurchase objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@SiteID",SqlDbType.Int, Convert.ToInt32(objEntity.SiteID)),
					CreateParameter("@ItemID",SqlDbType.Int, Convert.ToInt32(objEntity.ItemID)),
					CreateParameter("@InvoiceNo",SqlDbType.VarChar, objEntity.InvoiceNo),
					CreateParameter("@Amount",SqlDbType.Decimal, objEntity.Amount),
					CreateParameter("@Date",SqlDbType.VarChar, objEntity.Date),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@FileName",SqlDbType.VarChar, objEntity.FileName),
			};
            return CreateCommand("ins_DailyPurchase", parameters);
        }

        internal static SqlCommand Get_DailyPurchase(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_DailyPurchase_Rpt", parameters);
        }
        #endregion DailyPurchase


        #region Labour_Payments
        internal static SqlCommand Insert_Update_Labour_Payments(Labour_Payments objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@SiteID",SqlDbType.Int, Convert.ToInt32(objEntity.SiteID)),
					CreateParameter("@EmpID",SqlDbType.Int, Convert.ToInt32(objEntity.EmpID)),
					CreateParameter("@PaymentFor",SqlDbType.VarChar, objEntity.PaymentFor),
					CreateParameter("@Amount",SqlDbType.Decimal, objEntity.Amount),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
                    CreateParameter("@Dated",SqlDbType.VarChar, objEntity.Dated),
			};
            return CreateCommand("ins_Labour_Payments", parameters);
        }

        internal static SqlCommand Get_Labour_Payments(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Labour_Payments_Rpt", parameters);
        }
        #endregion Labour_Payments


        #region Req_Money
        internal static SqlCommand Insert_Update_Req_Money(Req_Money objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@SiteID",SqlDbType.Int, Convert.ToInt32(objEntity.SiteID)),
					CreateParameter("@ExpenseType",SqlDbType.Int, Convert.ToInt32(objEntity.ExpenseType)),
					CreateParameter("@Amount",SqlDbType.Decimal, objEntity.Amount),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@IsApproved",SqlDbType.Int, Convert.ToInt32(objEntity.IsApproved)),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@ApprovedBy",SqlDbType.Int, Convert.ToInt32(objEntity.ApprovedBy)),
					CreateParameter("@ApprovedDate",SqlDbType.VarChar, objEntity.ApprovedDate),
			};
            return CreateCommand("ins_Req_Money", parameters);
        }

        internal static SqlCommand Get_Req_Money(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Req_Money_Rpt", parameters);
        }
        #endregion Req_Money


        #region Site_Progress
        internal static SqlCommand Insert_Update_Site_Progress(Site_Progress objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@SiteID",SqlDbType.Int, Convert.ToInt32(objEntity.SiteID)),
					CreateParameter("@Perm_Labours",SqlDbType.Int, Convert.ToInt32(objEntity.Perm_Labours)),
					CreateParameter("@Cont_Labours",SqlDbType.Int, Convert.ToInt32(objEntity.Cont_Labours)),
					CreateParameter("@Daily_Labours",SqlDbType.Int, Convert.ToInt32(objEntity.Daily_Labours)),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@FileName",SqlDbType.VarChar, objEntity.FileName),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
                    CreateParameter("@Dated",SqlDbType.VarChar, objEntity.Dated),
			};
            return CreateCommand("ins_Site_Progress", parameters);
        }

        internal static SqlCommand Get_Site_Progress(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Site_Progress_Rpt", parameters);
        }
        #endregion Site_Progress


        #region PO
        internal static SqlCommand Insert_Update_PO(PO objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@POID",SqlDbType.Int, Convert.ToInt32(objEntity.POID)),
					CreateParameter("@MainRef",SqlDbType.VarChar, objEntity.MainRef),
					CreateParameter("@Dated",SqlDbType.VarChar, objEntity.Dated),
					CreateParameter("@Name",SqlDbType.VarChar, objEntity.Name),
					CreateParameter("@ShopNo",SqlDbType.VarChar, objEntity.ShopNo),
					CreateParameter("@Area",SqlDbType.VarChar, objEntity.Area),
					CreateParameter("@City",SqlDbType.VarChar, objEntity.City),
					CreateParameter("@State",SqlDbType.VarChar, objEntity.State),
					CreateParameter("@PinCode",SqlDbType.Int, Convert.ToInt32(objEntity.PinCode)),
					CreateParameter("@GSTINNO",SqlDbType.VarChar, objEntity.GSTINNO),
					CreateParameter("@Subject",SqlDbType.VarChar, objEntity.Subject),
					CreateParameter("@RefNo",SqlDbType.VarChar, objEntity.RefNo),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@ExpectedDeliveryDate",SqlDbType.VarChar, objEntity.ExpectedDeliveryDate),
					CreateParameter("@MainContact",SqlDbType.VarChar, objEntity.MainContact),
					CreateParameter("@Mobile",SqlDbType.VarChar, objEntity.Mobile),
					CreateParameter("@EmailID",SqlDbType.VarChar, objEntity.EmailID),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
					CreateParameter("@Status",SqlDbType.VarChar, objEntity.Status),
			};
            return CreateCommand("ins_PO", parameters);
        }

        internal static SqlCommand Get_PO(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_PO_Rpt", parameters);
        }
        #endregion PO


        #region PO_Items
        internal static SqlCommand Insert_Update_PO_Items(PO_Items objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@POID",SqlDbType.Int, Convert.ToInt32(objEntity.POID)),
					CreateParameter("@Description",SqlDbType.VarChar, objEntity.Description),
					CreateParameter("@Unit",SqlDbType.VarChar, objEntity.Unit),
					CreateParameter("@Qty",SqlDbType.Int, Convert.ToInt32(objEntity.Qty)),
					CreateParameter("@Rate",SqlDbType.Decimal, objEntity.Rate),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
			};
            return CreateCommand("ins_PO_Items", parameters);
        }

        internal static SqlCommand Get_PO_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_PO_Items_Rpt", parameters);
        }
        #endregion PO_Items

        #region PO_Term_Conditions
        internal static SqlCommand Insert_Update_PO_Term_Conditions(PO_Term_Conditions objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@POID",SqlDbType.Int, Convert.ToInt32(objEntity.POID)),
					CreateParameter("@Con_Type",SqlDbType.VarChar, objEntity.Con_Type),
					CreateParameter("@Con_Descr",SqlDbType.VarChar, objEntity.Con_Descr),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
			};
            return CreateCommand("ins_PO_Term_Conditions", parameters);
        }

        internal static SqlCommand Get_PO_Term_Conditions(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_PO_Term_Conditions_Rpt", parameters);
        }
        #endregion PO_Term_Conditions



        #region Bankers
        internal static SqlCommand Insert_Update_Bankers(Bankers objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@IFSCCODE",SqlDbType.VarChar, objEntity.IFSCCODE),
					CreateParameter("@Designation",SqlDbType.Int, Convert.ToInt32(objEntity.Designation)),
					CreateParameter("@BankName",SqlDbType.VarChar, objEntity.BankName),
					CreateParameter("@BranchName",SqlDbType.VarChar, objEntity.BranchName),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
			};
            return CreateCommand("ins_Bankers", parameters);
        }

        internal static SqlCommand Get_Bankers(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Bankers_Rpt", parameters);
        }
        #endregion Bankers


        #region Customers
        internal static SqlCommand Insert_Update_Customers(Customers objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@CustCode",SqlDbType.VarChar, objEntity.CustCode),
					CreateParameter("@CustDesignation",SqlDbType.VarChar, objEntity.CustDesignation),
					CreateParameter("@Unit",SqlDbType.VarChar, objEntity.Unit),
					CreateParameter("@CustName",SqlDbType.VarChar, objEntity.CustName),
					CreateParameter("@StreetNo",SqlDbType.VarChar, objEntity.StreetNo),
					CreateParameter("@Area",SqlDbType.VarChar, objEntity.Area),
					CreateParameter("@City",SqlDbType.VarChar, objEntity.City),
					CreateParameter("@State",SqlDbType.Int, Convert.ToInt32(objEntity.State)),
					CreateParameter("@PhoneNo",SqlDbType.VarChar, objEntity.PhoneNo),
					CreateParameter("@EmailID",SqlDbType.VarChar, objEntity.EmailID),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
			};
            return CreateCommand("ins_Customers", parameters);
        }

        internal static SqlCommand Get_Customers(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Customers_Rpt", parameters);
        }
        #endregion Customers


        #region Import_Items
        internal static SqlCommand Insert_Update_Import_Items(Import_Items objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ID",SqlDbType.Int, Convert.ToInt32(objEntity.ID)),
					CreateParameter("@ProjectCode",SqlDbType.VarChar, objEntity.ProjectCode),
					CreateParameter("@ScheduleNo",SqlDbType.VarChar, objEntity.ScheduleNo),
					CreateParameter("@SLNO",SqlDbType.VarChar, objEntity.SLNO),
					CreateParameter("@ItemDesc",SqlDbType.VarChar, objEntity.ItemDesc),
					CreateParameter("@ItemUnit",SqlDbType.VarChar, objEntity.ItemUnit),
					CreateParameter("@Qty",SqlDbType.Int, Convert.ToInt32(objEntity.Qty)),
					CreateParameter("@Rate",SqlDbType.Decimal, objEntity.Rate),
					CreateParameter("@Amount",SqlDbType.Decimal, objEntity.Amount),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@POStatus",SqlDbType.Int, Convert.ToInt32(objEntity.POStatus)),
					CreateParameter("@DCStatus",SqlDbType.Int, Convert.ToInt32(objEntity.DCStatus)),
					CreateParameter("@VendorCode",SqlDbType.VarChar, objEntity.VendorCode),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
			};
            return CreateCommand("ins_Import_Items", parameters);
        }

        internal static SqlCommand Get_Import_Items(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Import_Items_Rpt", parameters);
        }
        #endregion Import_Items


        #region Project
        internal static SqlCommand Insert_Update_Project(Project objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@ProjectCode",SqlDbType.VarChar, objEntity.ProjectCode),
					CreateParameter("@ProjectName",SqlDbType.VarChar, objEntity.ProjectName),
					CreateParameter("@InCharge",SqlDbType.Int, Convert.ToInt32(objEntity.InCharge)),
					CreateParameter("@StartDate",SqlDbType.VarChar, objEntity.StartDate),
					CreateParameter("@EndDate",SqlDbType.VarChar, objEntity.EndDate),
					CreateParameter("@Orderingauthority",SqlDbType.VarChar, objEntity.Orderingauthority),
					CreateParameter("@ExpectedEndDate",SqlDbType.VarChar, objEntity.ExpectedEndDate),
					CreateParameter("@ProjectCost",SqlDbType.Decimal, objEntity.ProjectCost),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
			};
            return CreateCommand("ins_Project", parameters);
        }

        internal static SqlCommand Get_Project(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Project_Rpt", parameters);
        }
        #endregion Project


        #region Railways
        internal static SqlCommand Insert_Update_Railways(Railways objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@RailwayCode",SqlDbType.VarChar, objEntity.RailwayCode),
					CreateParameter("@Area",SqlDbType.VarChar, objEntity.Area),
					CreateParameter("@City",SqlDbType.VarChar, objEntity.City),
					CreateParameter("@Comments",SqlDbType.VarChar, objEntity.Comments),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
			};
            return CreateCommand("ins_Railways", parameters);
        }

        internal static SqlCommand Get_Railways(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Railways_Rpt", parameters);
        }
        #endregion Railways


        #region Vendors
        internal static SqlCommand Insert_Update_Vendors(Vendors objEntity)
        {
            string ip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ip))
            {
                ip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            var parameters = new[]
			{
					CreateParameter("@action",SqlDbType.VarChar, objEntity.action),
					CreateParameter("@VendorCode",SqlDbType.VarChar, objEntity.VendorCode),
					CreateParameter("@VendorName",SqlDbType.VarChar, objEntity.VendorName),
					CreateParameter("@ContactPersion",SqlDbType.VarChar, objEntity.ContactPersion),
					CreateParameter("@PhoneNo",SqlDbType.VarChar, objEntity.PhoneNo),
                    CreateParameter("@EmailID",SqlDbType.VarChar, objEntity.EmailID),
					CreateParameter("@StreetNo",SqlDbType.VarChar, objEntity.StreetNo),
					CreateParameter("@Area",SqlDbType.VarChar, objEntity.Area),
					CreateParameter("@City",SqlDbType.VarChar, objEntity.City),
					CreateParameter("@State",SqlDbType.Int, Convert.ToInt32(objEntity.State)),
					CreateParameter("@Flag",SqlDbType.Int, Convert.ToInt32(objEntity.Flag)),
					CreateParameter("@CreatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.CreatedBy)),
					CreateParameter("@CreatedDate",SqlDbType.VarChar, objEntity.CreatedDate),
					CreateParameter("@UpdatedBy",SqlDbType.Int, Convert.ToInt32(objEntity.UpdatedBy)),
					CreateParameter("@UpdatedDate",SqlDbType.VarChar, objEntity.UpdatedDate),
			};
            return CreateCommand("ins_Vendors", parameters);
        }

        internal static SqlCommand Get_Vendors(Int32 ID, string Action, Int32 DeletedBy)
        {
            var parameters = new[]
			{
					CreateParameter("@ID", SqlDbType.Int, ID) ,
					CreateParameter("@Action", SqlDbType.VarChar, Action),
					CreateParameter("@DeletedBy", SqlDbType.Int,Convert.ToInt32(DeletedBy)),
			};
            return CreateCommand("Get_Vendors_Rpt", parameters);
        }
        #endregion Vendors

    }
}
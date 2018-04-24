using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Xml;
using SQLHelper;
using SqlHelp.Library.DataAccessLayer;
using System.Data.SqlClient;
using System.Configuration;
namespace SiteManagement
{
    public class Stores
    {
        private string oConnectionString = ConfigurationManager.AppSettings["ConnectionStringStag"].ToString();
      
    }
}
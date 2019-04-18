using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Tiexue.UI.Common;
using System.Net;
using GetAppVersions.Models;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Text;
using System.IO;

namespace GetAppVersions.Controllers
{
    public class HomeController : Controller
    {

        string _ConnectionString=@"Data Source=bds275550199.my3w.com;Initial Catalog=bds275550199_db;User Id=bds275550199;Password=Dfhiou9o74ntx";

        public ActionResult Index(string appName="")
        {
            bool isZzk = appName.ToLower() == "zzk";
            ViewBag.isZzk = isZzk;
            return View(GetDataFromDateBase(true,isZzk));
        }
         

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }


        public ActionResult StoreInfo()
        {
            return View(GetDataFromDateBase(false,false));   
        }


        private List<AppVersionInfo> GetDataFromDateBase(bool isIncludeVersion,bool isZzkApp)
        {
            List<AppVersionInfo> lstAppVersionInfo = new List<AppVersionInfo>(8);
            using(SqlConnection con=new SqlConnection())
            {
                con.ConnectionString = _ConnectionString;
                con.Open();
                using(SqlCommand cmd=new SqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText =string.Concat("select Id, StoreName, ",isZzkApp?"ZzkUrl":"Url",", Pattern from AppVersion");
                    SqlDataReader reader =  cmd.ExecuteReader();
                    if(reader.HasRows)
                    {
                        using (WebClient wb = new WebClient())
                        {
                            wb.Encoding = Encoding.UTF8;
                            while (reader.Read())
                            {
                                lstAppVersionInfo.Add(new AppVersionInfo()
                                {
                                    Id = reader.GetInt32(0),
                                    StoreName = reader.GetString(1),
                                    Url =reader.GetString(2),
                                    Version = isIncludeVersion? GetVersion(reader.GetString(2), reader.GetString(3), wb):String.Empty,
                                    Pattern = !isIncludeVersion?reader.GetString(3):String.Empty
                                });
                            }
                        }
                    }
                }
            }
            return lstAppVersionInfo;
        }



        private string GetVersion(string url,string pattern,WebClient wb)
        {
            if(url.IsNullOrEmpty())
            {
                return String.Empty;
            }
            string strHtml=String.Empty;
            try
            {

                strHtml = Encoding.UTF8.GetString(wb.DownloadData(url));

            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("Error.txt",string.Concat(ex.Message,"\r\n\r\n"));
            }
            return Regex.Match(strHtml,pattern).Groups[1].Value;
        }




    }
}

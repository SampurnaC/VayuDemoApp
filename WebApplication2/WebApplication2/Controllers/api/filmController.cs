using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;
using WebApplication2.Models;

namespace WebApplication2.Controllers.api
{
    public class filmController : ApiController
    {

        public Film GetData()
        {
            string filepath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Film.xlsx"); 
            string sqlquery = "SELECT * FROM [70dc0593-3f6f-4c39-87d4-5de4d22$]";
            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbConnection con = new OleDbConnection(constring + "");
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            DataTable dt = ds.Tables[0];

            //get random row
            Random rnd = new Random();
            int index = rnd.Next(0, dt.Rows.Count);

            var test = dt.Rows[index];
            Film film = new Film()
            {
                Title = test["Title"].ToString(),
                Year = Convert.ToInt32(test["Year"]),
                Time = Convert.ToInt32(test["Time"]),
                Cast = Convert.ToInt32(test["Cast"]),
                Rating = Convert.ToDecimal(test["Rating"]),
                Description = test["Description"].ToString(),
                Origin = Convert.ToInt32(test["Origin"]),
                Time_code =test["Time_code"].ToString(),
                Good = Convert.ToInt32(test["Good"]),
            };
            return film;
        }




        [HttpGet]
        public HttpResponseMessage json()
        {
            var data = GetData();
            return new HttpResponseMessage()
            {
                Content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")
            };
        }

        

    }
}

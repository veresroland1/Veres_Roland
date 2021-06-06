using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class MunkasokController : ApiController
    { 
          public HttpResponseMessage Get()
        {
            string query = @" 
                    select MunkasID,MunkasNeve,MunkasSzakkepzettseg,MunkasOraber from
                    dbo.Munkasok
                    ";
            DataTable table = new DataTable();
            using(var con= new SqlConnection(ConfigurationManager.
                ConnectionStrings["VRUzemAppDB"].ConnectionString))
                using(var cmd= new SqlCommand(query,con))
                using(var da= new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Munkasok mun)

            {
                try
                {
                    string query = @"
                        insert into dbo.Munkasok values
                        (
                        '" + mun.MunkasNeve+ @"'
                        ,'" + mun.MunkasSzakkepzettseg + @"'
                        ,'" + mun.MunkasOraber + @"'
                        )
                       ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["VRUzemAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!";
            }
                catch (Exception)
                {
                return "Failed to Add!";
                }
            }




        public string Put(Munkasok mun)

        {
            try
            {
                string query = @"
                        update dbo.Munkasok set 
                        MunkasNeve='" + mun.MunkasNeve + @"'
                        ,MunkasSzakkepzettseg='" + mun.MunkasSzakkepzettseg + @"'
                        ,MunkasOraber='" + mun.MunkasOraber + @"'
                        where MunkasID=" + mun.MunkasID+@" 
                       ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["VRUzemAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Update!";
            }
        }




        public string Delete(int id)

        {
            try
            {
                string query = @"
                        delete from dbo.Munkasok 
                        where MunkasID=" + id + @"
                       ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["VRUzemAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!";
            }
            catch (Exception)
            {
                return "Failed to Delete!";
            }
        }
    }
}

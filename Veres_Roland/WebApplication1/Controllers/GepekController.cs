using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class GepekController : ApiController
    {

        public HttpResponseMessage Get()
        {
            string query = @" 
                    select GepId,GepNev from
                    dbo.Gepek
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

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Gepek gk)

        {
            try
            {
                string query = @"
                        insert into dbo.Gepek values
                        (
                        '" + gk.GepNev + @"'

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




        public string Put(Gepek gk)

        {
            try
            {
                string query = @"
                        update dbo.Gepek set GepNev=
                        '" + gk.GepNev + @"'
                        where GepId=" + gk.GepId + @"
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
                        delete from dbo.Gepek 
                        where GepId=" + id + @"
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

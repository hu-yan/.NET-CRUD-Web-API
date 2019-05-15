using iBlog.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace iBlog.Controllers
{
    public class RegisterController : ApiController
    {
        [HttpPost]
        [Route("api/login/register")]
        public object Register([FromBody]Register register)
        {
            using (var entities = new iBlogEntities())
            {
                SqlConnection conn = new SqlConnection("data source=47.101.173.71;initial catalog=iBlog;persist security info=True;user id=sa;password=Password123;MultipleActiveResultSets=True");
                conn.Open();
                SqlCommand sql = new SqlCommand("INSERT INTO [user] (user_name) VALUES('" + register.userName + "')", conn);
                sql.ExecuteNonQuery();
                sql = new SqlCommand("SELECT * FROM [user] where user_name = '" + register.userName + "'", conn);
                SqlDataReader idReader = sql.ExecuteReader();
                while (idReader.Read())
                {
                    long id = (long)idReader["user_id"];
                    sql = new SqlCommand("INSERT INTO [user_login] VALUES(" + id + ", '" + register.password + "')", conn);
                    sql.ExecuteNonQuery();
                }
                conn.Close();
                return "Success";                                                                            
            }

        }

    }
}

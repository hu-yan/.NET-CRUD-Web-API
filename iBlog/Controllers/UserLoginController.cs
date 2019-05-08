using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using iBlog.Models;

namespace iBlog.Controllers
{
    public class UserLoginController : ApiController
    {
        [HttpPost]
        [Route("api/login/verify")]
        public object PostLoginInfo([FromBody]user_login userLogin)
        {
            using (var entities = new iBlogEntities())
            {
                var idEntity = entities.user_login.SqlQuery("SELECT *  FROM user_login where user_id = "+ userLogin.user_id);
                var isNUllCount = idEntity.ToList().Count;
                if (isNUllCount == 0) return "User ID Do Not Exist";
                var check = userLogin.password.Equals(idEntity.ToArray()[0].password);
                if (check)
                {
                    return "Verified";
                }
            }

            return "User ID Do Not Exist or Wrong Password";
        }
    }
}

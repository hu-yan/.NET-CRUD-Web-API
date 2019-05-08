using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Http;
using iBlog.Models;


namespace iBlog.Controllers
{
    public class PassageController : ApiController
    {
        [HttpGet]
        [Route("api/passage/download/{id}")]
        public HttpResponseMessage GetDocFile(long id)
        {
            var rs = new HttpResponseMessage(HttpStatusCode.OK);
            using (iBlogEntities entities = new iBlogEntities())
            {
                entities.passage.SqlQuery("SELECT title FROM Passage WHERE id = " + id);
                string title = entities.passage.ToArray()[0].title;
                string fileName = title + ".md";
                var filePath = HttpContext.Current.Server.MapPath($"~/App_Data/{fileName}");
                var fileBytes = File.ReadAllBytes(filePath);
                var fileMemStream = new MemoryStream(fileBytes);
                rs.Content = new StreamContent(fileMemStream);
                var headers = rs.Content.Headers;
                headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
                headers.ContentDisposition.FileName = fileName;
                headers.ContentLength = fileMemStream.Length;
            }

            return rs;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
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
            using (var entities = new iBlogEntities())
            {
                entities.passage.SqlQuery("SELECT title FROM Passage WHERE passage_id = " + id);
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

        [HttpGet]
        [Route("api/passage/search/by_ID/{id:long:length(4)}")]
        public object GetPassageById(long id)
        {
            using (var entities = new iBlogEntities())
                {
                    var rs = entities.passage.SqlQuery("SELECT * FROM Passage WHERE passage_id = " + id);
                    var isNUllCount = rs.ToList().Count;
                    if (isNUllCount == 0)
                    {
                        return "No Such Passage";

                    }
                try
                    {
                        return rs.ToArray()[0];
                    }
                    catch (Exception e)
                    {
                        return "Input Format Error";
                    }
                }


        }

        [HttpGet]
        [Route("api/passage/search/by_Title/{title:length(1,50)}")]
        public object GetPassageByTitle(string title)
        {
            using (var entities = new iBlogEntities())
            {
                var rs = entities.passage.SqlQuery("SELECT * FROM Passage WHERE title like '%" + title + "%'");
                var isNUllCount = rs.ToList().Count;
                if (isNUllCount == 0)
                {
                    return "No Such Passage";

                }
                try
                {
                   return rs.ToList();
                }
                catch (Exception e)
                {
                    return "Input Format Error";
                }
            }
        }

        [HttpGet]
        [Route("api/passage/search/draft")]
        public object GetDraft()
        {
            using (var entities = new iBlogEntities())
            {
                var rs = entities.passage.SqlQuery("SELECT * FROM Passage WHERE is_draft = 1");
                var isNUllCount = rs.ToList().Count;
                if (isNUllCount == 0)
                {
                    return "No Such Passage";

                }
                    return rs.ToList();
            }


        }
    }
}



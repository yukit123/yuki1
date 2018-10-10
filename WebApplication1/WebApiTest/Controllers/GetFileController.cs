using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApiTest.Controllers
{
    public class GetFileController : ApiController
    {
        // GET: GetFile
        public HttpResponseMessage GetFile(string id)
        {

            string fileName;
            string localFilePath;
            int fileSize;

            localFilePath = @"D:\test.pdf";

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = "pdf";
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return response;

        }
      
      
    }
}
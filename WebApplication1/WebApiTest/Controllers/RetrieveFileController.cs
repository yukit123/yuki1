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
    public class RetrieveFileController : ApiController
    {
        // GET: RetrieveFile
        [System.Web.Http.Route("api/DiagnosticDetail/RetrieveFile/{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage RetrieveFile(string id)
        {

            string fileName;
            string localFilePath;
            int fileSize;
            localFilePath = @"D:\test.pdf";
            //HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            //response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            //response.Content.Headers.ContentDisposition.FileName = "pdf";
            //response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            //return response;

            //DiagnosticDetailModel diagnosticDetailModel = GetFileList(id);
            //byte[] img = diagnosticDetailModel.FileContent.ToArray();
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
            //result.Content = new ByteArrayContent(img);
            result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            result.Content.Headers.ContentDisposition.FileName = "pdf";
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            return result;
        }
        //private DiagnosticDetailModel GetFileList(int id)
        //{
        //    var DetList = db.DiagnosticDetailModels.Where(p => p.InpatientCodeId == id).FirstOrDefault();
        //    return DetList;
        //}
    }
}
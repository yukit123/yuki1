using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using ClosedXML.Excel;

namespace WebApiTest.Controllers
{
    public class RetrieveFileController : ApiController//https://forums.asp.net/p/2147783/6233305.aspx?p=True&t=636747388089911547
    {
        //https://goosedotnet.wordpress.com/2014/09/29/generate-and-export-a-string-only-csv-file-from-webapi/
        //https://stackoverflow.com/questions/4668906/export-to-csv-using-mvc-c-sharp-and-jquery
        // GET: RetrieveFile
        [System.Web.Http.Route("api/DiagnosticDetail/RetrieveFile/{id}")]
        [System.Web.Http.HttpGet]
        public HttpResponseMessage RetrieveFile(string id)
        {
            #region download file
            //string fileName;
            //string localFilePath;
            //int fileSize;
            //localFilePath = @"D:\test.pdf";
            ////HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            ////response.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            ////response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
            ////response.Content.Headers.ContentDisposition.FileName = "pdf";
            ////response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            ////return response;

            ////DiagnosticDetailModel diagnosticDetailModel = GetFileList(id);
            ////byte[] img = diagnosticDetailModel.FileContent.ToArray();
            //HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
            ////result.Content = new ByteArrayContent(img);
            //result.Content = new StreamContent(new FileStream(localFilePath, FileMode.Open, FileAccess.Read));
            //result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("inline");
            //result.Content.Headers.ContentDisposition.FileName = "pdf";
            //result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");

            //return result;
            #endregion
            #region download  excel file with ClosedXML with data
            var data = new[]{
                               new{ Name="Ram", Email="ram@techbrij.com", Phone="111-222-3333" },
                               new{ Name="Shyam", Email="shyam@techbrij.com", Phone="159-222-1596" },
                               new{ Name="Mohan", Email="mohan@techbrij.com", Phone="456-222-4569" },
                               new{ Name="Sohan", Email="sohan@techbrij.com", Phone="789-456-3333" },
                               new{ Name="Karan", Email="karan@techbrij.com", Phone="111-222-1234" },
                               new{ Name="Brij", Email="brij@techbrij.com", Phone="111-222-3333" }
                      };

            HttpResponseMessage result = new HttpResponseMessage(HttpStatusCode.OK);




            result.Content = new StringContent(WriteTsv(data));
            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/vnd.ms-excel");
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment"); //attachment will force download
            result.Content.Headers.ContentDisposition.FileName = "RecordExport.xls";




            return result;
            #endregion
        }


        public string WriteTsv<T>(IEnumerable<T> data)
        {
            StringBuilder output = new StringBuilder();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            foreach (PropertyDescriptor prop in props)
            {
                output.Append(prop.DisplayName); // header
                output.Append("\t");
            }
            output.AppendLine();
            foreach (T item in data)
            {
                foreach (PropertyDescriptor prop in props)
                {
                    output.Append(prop.Converter.ConvertToString(
                         prop.GetValue(item)));
                    output.Append("\t");
                }
                output.AppendLine();
            }
            return output.ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class EncryptedActionParameterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.ActionName.IsNormalized())
            {
                Dictionary<string, object> decryptedParameters = new Dictionary<string, object>();
                if (HttpContext.Current.Request.QueryString.Get("parameter") != null)
                {
                    string url = HttpContext.Current.Request.QueryString.Get("parameter");
                    if (url.IndexOf('q') != -1)
                    {
                        var value1 = url.Split('q')[0];
                        string[] splitvalue1 = value1.Split('?');
                        for (int i = 0; i < splitvalue1.Length - 1; i++)
                        {
                            string[] paramArr = splitvalue1[i].Split('=');
                            decryptedParameters.Add(paramArr[0], Convert.ToString(paramArr[1]));
                        }
                        var value2 = url.Split('q')[1];
                        var value = value2.Substring(1, value2.Length - 1);
                        string decrptedString = Decrypt(value.ToString());
                        string[] splitvalue2 = decrptedString.Split('?');
                        for (int i = 0; i < splitvalue2.Length; i++)
                        {
                            string[] paramArr = splitvalue2[i].Split('=');
                            decryptedParameters.Add(paramArr[0], Convert.ToString(paramArr[1]));
                        }
                    }
                    else
                    {
                        var value1 = url.Split('q')[0];
                        string[] splitvalue1 = value1.Split('?');
                        for (int i = 0; i < splitvalue1.Length - 1; i++)
                        {
                            string[] paramArr = splitvalue1[i].Split('=');
                            decryptedParameters.Add(paramArr[0], Convert.ToString(paramArr[1]));
                        }
                    }
                }
                else if (HttpContext.Current.Request.QueryString.Get("q") != null)
                {
                    // Just have token, don't have routevalue
                }
                for (int i = 0; i < decryptedParameters.Count; i++)
                {
                    filterContext.ActionParameters[decryptedParameters.Keys.ElementAt(i)] = decryptedParameters.Values.ElementAt(i);
                }
                base.OnActionExecuting(filterContext);
            }
            else
            {
                throw new ArgumentNullException("HttpContext");
            }
        }
        private string Decrypt(string encryptedText)
        {
            string key = "jdsg432387#";
            byte[] DecryptKey = { };
            byte[] IV = { 55, 34, 87, 64, 87, 195, 54, 21 };
            byte[] inputByte = new byte[encryptedText.Length];
            DecryptKey = System.Text.Encoding.UTF8.GetBytes(key.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByte = Convert.FromBase64String(encryptedText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(DecryptKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByte, 0, inputByte.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
    }
    public class DeleteFileAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Flush();

            //convert the current filter context to file and get the file path
            string filePath = (filterContext.Result as FilePathResult).FileName;

            //delete the file after download
            System.IO.File.Delete(filePath);
        }
    }
    public class ProjectAndStudentModels
    {
        public Project project { get; set; }
        public List<VStudent> StudentsAndID { get; set; }

    }

    public class Project
    {
        public int Id { get; set; }
        public int PName { get; set; }

    }

    [MetadataType(metadataClassType: typeof(StudentMetaData))]
    public partial class VStudent
    {
        public int Id { get; set; }

        public string SName { get; set; }

        public string Username { get; set; }
    }
    class StudentMetaData
    {
        [Remote("IsStudentExists", "Home", ErrorMessage = "Id already exists", HttpMethod = "post")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter student name.")]
        public string SName { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Remote("UserNameAlreadyExistsAsync", "Home", ErrorMessage = "User with this Username already exists", HttpMethod = "post")]
        public string Username { get; set; }

    }

    public class CreateCustomerModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [Remote("UserNameAlreadyExistsAsync", "Home", ErrorMessage = "User with this Username already exists", HttpMethod = "post")]
        public string Username { get; set; }
    }

}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Controllers;

namespace WebApplication1.Models
{
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
    }
    class StudentMetaData
    {
        [Remote("IsStudentExists", "Home", ErrorMessage = "Id already exists", HttpMethod = "post")]
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter student name.")]
        public string SName { get; set; }

    }
}
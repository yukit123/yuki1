using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiTest.Models;

namespace WebApiTest.Controllers
{
    public class ResourceController : ApiController
    {
        List<ResourceModel> resources;

        public ResourceController()
        {
            resources = new List<ResourceModel>();
            resources.Add(new ResourceModel { ResourceID = "A", LongName = "Allan", Office = "CHN" });
            resources.Add(new ResourceModel { ResourceID = "B", LongName = "Blake", Office = "CHN" });
            resources.Add(new ResourceModel { ResourceID = "B", LongName = "Blake", Office = "STLHO" });
            resources.Add(new ResourceModel { ResourceID = "C", LongName = "Chris", Office = "STLHO" });
            resources.Add(new ResourceModel { ResourceID = "D", LongName = "Dan", Office = "STLHO" });
        }
        [Route("api/Resource/{ResourceID}")]
        [HttpGet]
        public IEnumerable<ResourceModel> GetResources(string ResourceID)
        {
            try
            {
                IEnumerable<ResourceModel> foundresources = resources.FindAll(r => r.ResourceID.Equals(ResourceID));
                return foundresources;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}

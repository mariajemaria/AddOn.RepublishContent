using System.Linq;
using System.Web.Http;
using EPiServer.DataAbstraction;
using EPiServer.ServiceLocation;
using GetaCommerce.Web.Infrastructure.Admin.Tools.Models;
using Newtonsoft.Json;

namespace RepublishContentAlloy.Admin.Tools.Controllers.Api
{
    //[RoutePrefix("api/republish")]
    public class RepublishContentApiController : ApiController
    {

        private readonly IContentTypeRepository _typerepo = ServiceLocator.Current.GetInstance<IContentTypeRepository>();

        // GET api/<controller>
        public IHttpActionResult GetContentTypes()
        {
            var contentTypeDtos = _typerepo.List().Select(ct => new ContentTypeDto
                {ID = ct.ID, Name = ct.FullName}).ToList();


            if (contentTypeDtos.Any())
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };

                settings.NullValueHandling = NullValueHandling.Ignore;

                var contentTypesJson = JsonConvert.SerializeObject(contentTypeDtos, settings);

                return Ok(contentTypesJson);
            }
            else
            {
                return BadRequest("No content types available");
            }
        }
    }
}

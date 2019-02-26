using EPiServer.Framework.Localization;
using EPiServer.Shell;
using System.Web.Mvc;

namespace AddOn.RepublishContent.Controllers
{
    public class RepublishContentController : Controller
    {
        public ActionResult Index()
        {
            var path = Paths.ToResource(GetType(), "Views/RepublishContent/Index.cshtml");
            var model = new RepublishModel
            {
                Heading = LocalizationService.Current.GetString("/addon.republishcontent/heading")
            };

            return View(path, model);
        }
    }

    public class RepublishModel
    {
        public string Heading { get; set; }
    }
}

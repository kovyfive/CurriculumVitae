namespace CurriculumVitae.Areas.HelpPage.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;

    using CurriculumVitae.Areas.HelpPage.ModelDescriptions;

    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        private const string ErrorViewName = "Error";

        public HelpController()
            : this(GlobalConfiguration.Configuration)
        {
        }

        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        public HttpConfiguration Configuration { get; }

        public ActionResult Api(string apiId)
        {
            if (string.IsNullOrEmpty(apiId))
            {
                return this.View(ErrorViewName);
            }

            var apiModel = this.Configuration.GetHelpPageApiModel(apiId);

            return apiModel != null ? this.View(apiModel) : this.View(ErrorViewName);
        }

        public ActionResult Index()
        {
            this.ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();

            return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return this.View(ErrorViewName);
            }

            var modelDescriptionGenerator = this.Configuration.GetModelDescriptionGenerator();

            ModelDescription modelDescription;
            return modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription)
                       ? this.View(modelDescription)
                       : this.View(ErrorViewName);
        }
    }
}